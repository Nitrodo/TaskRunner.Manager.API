using Microsoft.EntityFrameworkCore;
using TaskRunner.Manager.Domain.Entities;

namespace TaskRunner.Manager.Infrastructure.Persitence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskDefinition> TaskDefinitions { get; set; }

        public DbSet<ProcessDefinition> ProcessDefinitions { get; set; }

        //public DbSet<TaskProgress> TaskProgresses { get; set; }

        //public DbSet<ProcessProgress> ProcessProgresses { get; set; }
    }
}
