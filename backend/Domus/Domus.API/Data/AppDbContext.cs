using Domus.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Domus.API.Data;

public class AppDbContext : DbContext {

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tables
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>(entity => {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Username).IsRequired().HasMaxLength(255);
            entity.HasIndex(u => u.Username).IsUnique();
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(255);
            entity.Property(u => u.Password).IsRequired();
        });

        modelBuilder.Entity<Property>(entity => {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(255);
            entity.Property(p => p.Description).IsRequired();
            entity.Property(p => p.Location).IsRequired();
            entity.Property(p => p.Price).IsRequired();
            entity.Property(p => p.NumberRooms).IsRequired();
            entity.Property(p => p.Status).IsRequired();
            entity.Property(p => p.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<Property>()
            .HasOne(p => p.User)
            .WithMany(u => u.Properties)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}