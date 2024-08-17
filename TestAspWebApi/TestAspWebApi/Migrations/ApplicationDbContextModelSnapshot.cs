﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TestAspWebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CatgegoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Models.CongViec", b =>
                {
                    b.Property<int>("MaCongViec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCongViec"), 1L, 1);

                    b.Property<int?>("DonHangMaDonHang")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenCongViec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCongViec");

                    b.HasIndex("DonHangMaDonHang");

                    b.ToTable("congViecs");
                });

            modelBuilder.Entity("Core.Models.DonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"), 1L, 1);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaDonHang");

                    b.HasIndex("ProductId");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("Core.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Core.Models.CongViec", b =>
                {
                    b.HasOne("Core.Models.DonHang", "DonHang")
                        .WithMany("CongViec")
                        .HasForeignKey("DonHangMaDonHang");

                    b.Navigation("DonHang");
                });

            modelBuilder.Entity("Core.Models.DonHang", b =>
                {
                    b.HasOne("Core.Models.Product", "Product")
                        .WithMany("DonHang")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Models.Product", b =>
                {
                    b.HasOne("Core.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Models.DonHang", b =>
                {
                    b.Navigation("CongViec");
                });

            modelBuilder.Entity("Core.Models.Product", b =>
                {
                    b.Navigation("DonHang");
                });
#pragma warning restore 612, 618
        }
    }
}
