﻿// <auto-generated />
using System;
using Assessment_MS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assessment_MS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230318162803_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assessment_MS.Models.SurveyRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("BrightnessAcceptance")
                        .HasColumnType("bit");

                    b.Property<int?>("BrightnessLevel")
                        .HasColumnType("int");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SurveyRecord", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2",
                            AddressLine1 = "3 the lane",
                            AddressLine2 = "",
                            BrightnessAcceptance = true,
                            BrightnessLevel = 5,
                            County = "Cambs",
                            EmailAddress = "Billy.Nomates@notsure.com",
                            FullName = "Billy Nomates",
                            Postcode = "PE01 8PE",
                            Town = "Peterborough"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
