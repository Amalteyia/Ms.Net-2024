using DinoPark.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DinoPark.DataAccess;

public class DinoParkDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DinoEntity> Dinos { get; set; }
    public DbSet<AreaEntity> Areas { get; set; }

    public DinoParkDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.UserName).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.PhoneNumber).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Email).IsUnique();
        
        modelBuilder.Entity<DinoEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<DinoEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<DinoEntity>().HasIndex(x => x.Name).IsUnique();
        
        modelBuilder.Entity<AreaEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AreaEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<AreaEntity>().HasIndex(x => x.Name).IsUnique();

        modelBuilder.Entity<UserEntity>().HasMany(x => x.Dinos).WithMany(y => y.Employees);
        modelBuilder.Entity<DinoEntity>().HasMany(x => x.Areas).WithMany(y => y.Dinos);
    }
}