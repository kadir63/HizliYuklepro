using HizliYukle.BOL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliYukle.DAL.Contexts
{
   public class MyContext:DbContext
    {
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Mahalle> Mahalle { get; set; }
        public DbSet<Sokak> Sokak { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<AracBilgi> AracBilgi { get; set; }
        public DbSet<Nakliyeci> Nakliyeci { get; set; }
        public DbSet<YukBilgi> YukBilgi { get; set; }
        public DbSet<YukVeren> YukVeren { get; set; }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Student & StudentAddress entity
            modelBuilder.Entity<Nakliyeci>()
                        .HasOptional(s => s.AracBilgi) // Mark Address property optional in Student entity
                        .WithRequired(ad => ad.Nakliyeci); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
        }
    }

}
