using Microsoft.EntityFrameworkCore;
using Service.Storage.Entities;

namespace Service.Storage.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProblemType> ProblemTypes { get; set; }
        public DbSet<Solution> Solutions { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DatabaseContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Problem>()
                .HasKey(u => u.Id);

            // Код для связи многие ко многим
            modelBuilder.Entity<ProblemTag>()
                .HasOne(pt => pt.Problem)
                .WithMany(t => t.Tags)
                .HasForeignKey(pt => pt.ProblemId);

            modelBuilder.Entity<ProblemTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.Problems)
                .HasForeignKey(pt => pt.ProblemId);
        }
    }
}