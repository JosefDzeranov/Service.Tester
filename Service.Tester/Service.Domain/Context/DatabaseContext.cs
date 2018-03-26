using Microsoft.EntityFrameworkCore;
using Service.Domain.Entities;

namespace Service.Domain.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProblemType> ProblemTypes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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