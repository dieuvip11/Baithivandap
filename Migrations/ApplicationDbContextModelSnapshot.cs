﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranHoangDieu_131.Data;

#nullable disable

namespace TranHoangDieu_131.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("TranHoangDieu_131.Lophoc", b =>
                {
                    b.Property<string>("MaLop")
                        .HasColumnType("TEXT");

                    b.Property<double>("SoTT")
                        .HasColumnType("REAL");

                    b.Property<int>("TenLop")
                        .HasColumnType("INTEGER");

                    b.HasKey("MaLop");

                    b.ToTable("Lophocs");
                });

            modelBuilder.Entity("TranHoangDieu_131.Sinhvien", b =>
                {
                    b.Property<double>("Masinhvien")
                        .HasColumnType("REAL");

                    b.Property<string>("MaLop")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tensinhvien")
                        .HasColumnType("INTEGER");

                    b.HasKey("Masinhvien");

                    b.HasIndex("MaLop");

                    b.ToTable("Sinhviens");
                });

            modelBuilder.Entity("TranHoangDieu_131.Sinhvien", b =>
                {
                    b.HasOne("TranHoangDieu_131.Lophoc", "Lophoc")
                        .WithMany("Sinhvien")
                        .HasForeignKey("MaLop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lophoc");
                });

            modelBuilder.Entity("TranHoangDieu_131.Lophoc", b =>
                {
                    b.Navigation("Sinhvien");
                });
#pragma warning restore 612, 618
        }
    }
}
