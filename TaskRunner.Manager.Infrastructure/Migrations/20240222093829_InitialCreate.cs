using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskRunner.Manager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDefinitions",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDefinitions", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "ProcessDefinitions",
                columns: table => new
                {
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FunctionName = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    IsRetryAllowed = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessDefinitions", x => x.ProcessId);
                    table.ForeignKey(
                        name: "FK_ProcessDefinitions_TaskDefinitions_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskDefinitions",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDefinitions_TaskId",
                table: "ProcessDefinitions",
                column: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessDefinitions");

            migrationBuilder.DropTable(
                name: "TaskDefinitions");
        }
    }
}
