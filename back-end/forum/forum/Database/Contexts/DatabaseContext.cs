using Forum.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Database.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("User")
                .Property(u => u.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Topic>()
                .ToTable("Topic")
                .Property(t => t.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Message>()
                .ToTable("Message")
                .Property(m => m.Id).HasDefaultValueSql("NEWID()");
        }

    }
}
