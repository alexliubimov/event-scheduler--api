using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Test.EventScheduler.DataAccess.Configurations;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.DataAccess
{
    public class EventSchedulerContext : DbContext, IDataContext
    {
        private readonly string _connectionString;
        private IDbContextTransaction _transaction;

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        public EventSchedulerContext(DbContextOptions options) : base(options)
        {
           //Database.Migrate();
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Save() => SaveChanges();

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EventEntityTypeConfiguration());
        }
    }
}
