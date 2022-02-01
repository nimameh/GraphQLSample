using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(
                entity =>
                {
                    entity.HasMany(p => p.Reviews).WithOne(a => a.Course).HasForeignKey(b => b.CourseId);
                }
                );
        }


        public DbSet<Course> Course { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
