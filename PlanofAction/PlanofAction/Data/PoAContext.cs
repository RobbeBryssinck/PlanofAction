using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanofAction.Models;
using Microsoft.EntityFrameworkCore;

namespace PlanofAction.Data
{
    public class PoAContext : DbContext
    {
        public PoAContext(DbContextOptions<PoAContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ActionPlan> ActionPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Thread>().ToTable("Thread");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<ActionPlan>().ToTable("ActionPlan");
        }
    }
}
