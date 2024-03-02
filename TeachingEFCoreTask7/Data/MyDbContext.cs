using Microsoft.EntityFrameworkCore;
using SweeftStage2Tasks.TeachingEFCoreTask7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SweeftStage2Tasks.TeachingEFCoreTask7.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Teaching> Teachings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pupil>().ToTable("Pupils");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");

            modelBuilder.Entity<Teaching>()
                .HasKey(t => new { t.TeacherId, t.PupilId });

            modelBuilder.Entity<Teaching>()
                .HasOne(t => t.Teacher)
                .WithMany(t => t.Teachings)
                .HasForeignKey(t => t.TeacherId);

            modelBuilder.Entity<Teaching>()
                .HasOne(t => t.Pupil)
                .WithMany(p => p.Teachings)
                .HasForeignKey(t => t.PupilId);
        }
    }
}
