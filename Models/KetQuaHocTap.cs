using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_Hocsinh.Models
{
    public class KetQuaHocTap : DbContext
    {
        public KetQuaHocTap(DbContextOptions<KetQuaHocTap> options) : base(options)
        {

        }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<LopHocPhan> LopHocPhans { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=QL_HocSinh;Integrated Security=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>().HasKey(e => e.ID); //set key

            //modelBuilder.Entity<Post>(b =>
            //{
            //    b.HasKey(e => e.ID);
            //    b.Property(e => e.ID).ValueGeneratedOnAdd();
            //});//key tự động tăng

            modelBuilder.Entity<LopHocPhan>().HasKey(e => e.ID);
            modelBuilder.Entity<SinhVien>().HasKey(e => e.ID);
            modelBuilder.Entity<MonHoc>().HasKey(e => e.ID);
           

            modelBuilder.Entity<Khoa>()
                .HasMany(e => e.LopHocPhans)//1 Khoa có nhiều Lop
                .WithOne(e => e.Khoa);//Trong 1 Lop đó sẽ có duy nhất 1 Khoa
            modelBuilder.Entity<LopHocPhan>()
                .HasMany(e => e.SinhViens)
                .WithOne(e => e.LopHocPhan);
            modelBuilder.Entity<MonHoc>()
               .HasMany(e => e.LopHocPhans)
               .WithOne(e => e.MonHoc);

            //modelBuilder.Entity<Post>()
            //    .Property(e => e.ViewCount)
            //    .HasDefaultValue(0);//xét ViewCount = 0




        }
    }
}
