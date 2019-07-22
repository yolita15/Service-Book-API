﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceBook.API.Entities;

namespace ServiceBook.API.Migrations
{
    [DbContext(typeof(ServiceBookContext))]
    [Migration("20190722110412_ChangeName")]
    partial class ChangeName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceBook.API.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OrganizationNumber")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Website")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("ProviderId");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Object", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ObjectIdentifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("ParentId");

                    b.Property<Guid>("TfmId");

                    b.Property<Guid>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TfmId");

                    b.HasIndex("TypeId");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.ObjectDepartment", b =>
                {
                    b.Property<Guid>("ObjectId");

                    b.Property<Guid>("DepartmentId");

                    b.HasKey("ObjectId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("ObjectDepartments");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.ObjectType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ObjectTypes");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.ObjectUser", b =>
                {
                    b.Property<Guid>("ObjectId");

                    b.Property<Guid>("UserId");

                    b.HasKey("ObjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ObjectUsers");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Tfm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Tfms");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Company", b =>
                {
                    b.HasOne("ServiceBook.API.Entities.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Department", b =>
                {
                    b.HasOne("ServiceBook.API.Entities.Provider", "Provider")
                        .WithMany("Departments")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Object", b =>
                {
                    b.HasOne("ServiceBook.API.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceBook.API.Entities.Tfm", "Tfm")
                        .WithMany()
                        .HasForeignKey("TfmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceBook.API.Entities.ObjectType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceBook.API.Entities.ObjectDepartment", b =>
                {
                    b.HasOne("ServiceBook.API.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceBook.API.Entities.Object", "Object")
                        .WithMany("ObjectDepartments")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceBook.API.Entities.ObjectUser", b =>
                {
                    b.HasOne("ServiceBook.API.Entities.Object", "Object")
                        .WithMany("ObjectUsers")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ServiceBook.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceBook.API.Entities.Provider", b =>
                {
                    b.HasOne("ServiceBook.API.Entities.Company")
                        .WithMany("Providers")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("ServiceBook.API.Entities.User", b =>
                {
                    b.HasOne("ServiceBook.API.Entities.UserType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
