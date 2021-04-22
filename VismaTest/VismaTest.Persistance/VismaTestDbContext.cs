using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using VismaTest.Domain.Entities;

namespace VismaTest.Persistance
{
    [ExcludeFromCodeCoverage]
    public partial class VismaTestDbContext : DbContext
    {
        public VismaTestDbContext(DbContextOptions<VismaTestDbContext> options)
            : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(o => new { o.UserId, o.RolId });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VismaTestDbContext).Assembly);

        }

    }
}
