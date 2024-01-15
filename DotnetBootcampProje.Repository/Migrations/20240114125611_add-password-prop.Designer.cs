﻿// <auto-generated />
using System;
using DotnetBootcampProje.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotnetBootcampProje.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240114125611_add-password-prop")]
    partial class addpasswordprop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DotnetBootcampProje.Core.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Classes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(233),
                            Name = "1.Sınıf"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(255),
                            Name = "2.Sınıf"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(258),
                            Name = "3.Sınıf"
                        });
                });

            modelBuilder.Entity("DotnetBootcampProje.Core.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(849),
                            Name = "Seher Selin",
                            Number = "290",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(855),
                            Name = "Şevval Özdemir",
                            Number = "100",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(859),
                            Name = "Ceren Soysal",
                            Number = "100",
                            TeacherId = 2
                        });
                });

            modelBuilder.Entity("DotnetBootcampProje.Core.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Teachers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(1198),
                            Email = "ali@test.com",
                            Name = "Ali Yılmaz",
                            Password = "12345",
                            Phone = "5555555"
                        },
                        new
                        {
                            Id = 2,
                            ClassId = 2,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(1204),
                            Email = "gizem@test.com",
                            Name = "Gizem Tosun",
                            Password = "12345",
                            Phone = "5555555"
                        },
                        new
                        {
                            Id = 3,
                            ClassId = 3,
                            CreatedDate = new DateTime(2024, 1, 14, 15, 56, 10, 482, DateTimeKind.Local).AddTicks(1209),
                            Email = "ayse@test.com",
                            Name = "Ayşe kaya",
                            Password = "12345",
                            Phone = "5555555"
                        });
                });

            modelBuilder.Entity("DotnetBootcampProje.Core.Models.Student", b =>
                {
                    b.HasOne("DotnetBootcampProje.Core.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DotnetBootcampProje.Core.Models.Teacher", b =>
                {
                    b.HasOne("DotnetBootcampProje.Core.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("DotnetBootcampProje.Core.Models.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}