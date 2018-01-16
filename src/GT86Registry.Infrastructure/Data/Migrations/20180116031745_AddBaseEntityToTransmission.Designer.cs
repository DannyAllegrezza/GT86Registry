﻿// <auto-generated />
using GT86Registry.Core.Entities;
using GT86Registry.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GT86Registry.Infrastructure.Data.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20180116031745_AddBaseEntityToTransmission")]
    partial class AddBaseEntityToTransmission
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GT86Registry.Core.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.ColorsModelYears", b =>
                {
                    b.Property<int>("ColorId");

                    b.Property<int>("ModelYearId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.HasKey("ColorId", "ModelYearId");

                    b.HasIndex("ModelYearId");

                    b.ToTable("Model_Color");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Uri")
                        .IsRequired();

                    b.Property<string>("UserIdentityGuid");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ActiveEndDate");

                    b.Property<DateTime>("ActiveStartDate");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<int>("ManufacturerId");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.ModelTransmissions", b =>
                {
                    b.Property<int>("ModelYearId");

                    b.Property<int>("TransmissionId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.HasKey("ModelYearId", "TransmissionId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("Model_Transmission");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.ModelYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<int>("ModelId");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Model_Year");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Transmission");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.Vehicle", b =>
                {
                    b.Property<string>("VIN")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(17);

                    b.Property<int>("ColorId");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("FacebookUri");

                    b.Property<string>("InstagramUri");

                    b.Property<int>("Mileage");

                    b.Property<int>("ModelYearId");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<int>("ProfilePhotoId");

                    b.Property<int>("StatusId");

                    b.Property<int>("TransmissionId");

                    b.Property<string>("UserIdentityGuid");

                    b.Property<int>("VehicleLocationId");

                    b.Property<int>("ViewCount");

                    b.HasKey("VIN");

                    b.HasIndex("ColorId");

                    b.HasIndex("ModelYearId");

                    b.HasIndex("ProfilePhotoId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TransmissionId");

                    b.HasIndex("VehicleLocationId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.VehicleLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<DateTimeOffset>("ModifiedDate");

                    b.Property<DateTimeOffset>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.VehiclesImages", b =>
                {
                    b.Property<string>("VehicleVIN");

                    b.Property<int>("ImageId");

                    b.HasKey("VehicleVIN", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("Vehicle_Image");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.VehicleStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("StatusCode");

                    b.HasKey("Id");

                    b.ToTable("VehicleStatus");
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.ColorsModelYears", b =>
                {
                    b.HasOne("GT86Registry.Core.Entities.Color", "Color")
                        .WithMany("ModelColors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GT86Registry.Core.Entities.ModelYear", "ModelYear")
                        .WithMany("ModelColors")
                        .HasForeignKey("ModelYearId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.Model", b =>
                {
                    b.HasOne("GT86Registry.Core.Entities.Manufacturer", "Manufacturer")
                        .WithMany("VehicleModels")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.ModelTransmissions", b =>
                {
                    b.HasOne("GT86Registry.Core.Entities.ModelYear", "ModelYear")
                        .WithMany("ModelTransmissions")
                        .HasForeignKey("ModelYearId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GT86Registry.Core.Entities.Transmission", "Transmission")
                        .WithMany("ModelTransmissions")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.ModelYear", b =>
                {
                    b.HasOne("GT86Registry.Core.Entities.Model", "Model")
                        .WithMany("ModelYears")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.Vehicle", b =>
                {
                    b.HasOne("GT86Registry.Core.Entities.Color", "Color")
                        .WithMany("Vehicles")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GT86Registry.Core.Entities.ModelYear", "ModelYear")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelYearId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GT86Registry.Core.Entities.Image", "Image")
                        .WithMany("Vehicles")
                        .HasForeignKey("ProfilePhotoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GT86Registry.Core.Entities.VehicleStatus", "Status")
                        .WithMany("Vehicles")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GT86Registry.Core.Entities.Transmission", "Transmission")
                        .WithMany()
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GT86Registry.Core.Entities.VehicleLocation", "VehicleLocation")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleLocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GT86Registry.Core.Entities.VehiclesImages", b =>
                {
                    b.HasOne("GT86Registry.Core.Entities.Image", "Image")
                        .WithMany("VehicleImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GT86Registry.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("VehicleImages")
                        .HasForeignKey("VehicleVIN")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
