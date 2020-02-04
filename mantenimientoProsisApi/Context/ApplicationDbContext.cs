using mantenimientoProsisApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mantenimientoProsisApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SparePartsCatalog> SparePartsCatalogs { get; set; }
        public DbSet<SquaresCatalog> SquaresCatalogs { get; set; }
        public DbSet<LanesCatalog> LanesCatalogs { get; set; }
        public DbSet<DTCHeader> DTCHeaders { get; set; }
        public DbSet<DTCMovement> DTCMovements { get; set; }
        public DbSet<DTCTechnical> DTCTechnicians { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTCTechnical>(db =>
            {
                db.HasKey(x => x.ReferenceNum);
                db.Property(x => x.ReferenceNum).HasMaxLength(10);
            });

            //modelBuilder.Entity<DTCMovement>(db =>
            //{
            //    db.HasKey(x => x.DTCTechnicianId);
            //    db.Property(x => x.DTCTechnicianId).HasMaxLength(10);
            //    db.HasOne(x => x.DTCTechnician).WithMany(x => x.DTCMovements).IsRequired();


            //});

        }
    }
}
