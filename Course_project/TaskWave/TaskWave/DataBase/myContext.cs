using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Classes;

namespace TaskWave.DataBase
{
    public class myContext : DbContext
    {
        public DbSet<User> userIdentify { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<ReadyTask> readyTasks { get; set; }
        public DbSet<SendTasks> sendTasks { get; set; }
        public DbSet<PrPhoto> prPhotos { get; set; }
        public DbSet<TaskPhoto> taskPhotos { get; set; }
        public DbSet<TaskReadyPh> taskReadyPhs { get; set; }
        public DbSet<DocumentTask> documentTasks { get; set; }
        public DbSet <Notifications> notification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myContext"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.id);

            modelBuilder.Entity<Notifications>().HasKey(e => e.id);

            modelBuilder.Entity<Projects>()
             .HasMany(p => p.images)
             .WithOne()
             .HasForeignKey(i => i.PrId);

            modelBuilder.Entity<Tasks>()
            .HasMany(t => t.img)
            .WithOne()
            .HasForeignKey(p => p.TaskId);

            modelBuilder.Entity<ReadyTask>()
            .HasMany(t => t.img)
            .WithOne()
            .HasForeignKey(p => p.TaskReadyId);

            modelBuilder.Entity<SendTasks>()
            .HasMany(t => t.img)
            .WithOne()
            .HasForeignKey(p => p.TaskReadyId);

        }

        public void SaveAll()
        {
            SaveChanges();
        }

        public void AddEl<T>(T obj) where T : class
        {
            Set<T>().Add(obj);
            SaveAll();
        }

        public void RemoveEl<T>(T obj) where T : class
        {
            Set<T>().Remove(obj);
            SaveAll();
        }

        
    }
}
