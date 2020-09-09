using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.Project.Model
{
    public class TMSContext : DbContext
    {
        public TMSContext(DbContextOptions<TMSContext> options) : base(options)
        {

        }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<ClassBatch> ClassBatches { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ClassAdmin> ClassAdmins { get; set; }
        public DbSet<TrainerClassBatch> TrainerClassBatches { get; set; }
        public DbSet<ClassAdminBatch> ClassAdminBatches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainerClassBatch>().HasKey(sc => new { sc.TrainerId, sc.ClassId });
            modelBuilder.Entity<ClassAdminBatch>().HasKey(sc => new { sc.ClassAdminId ,sc.ClassId});
        }
    }
}
