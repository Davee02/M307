﻿// <auto-generated />
using System;
using M307_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace M307_Project.Migrations
{
    [DbContext(typeof(RepairsContext))]
    [Migration("20190416085151_AddDateTimeField")]
    partial class AddDateTimeField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("M307_Project.Models.RepairOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Phone")
                        .HasMaxLength(200);

                    b.Property<DateTime>("RepairStartDateTime");

                    b.Property<int>("RepairState");

                    b.Property<int>("Severety");

                    b.Property<int>("ToolId");

                    b.HasKey("Id");

                    b.HasIndex("ToolId");

                    b.ToTable("RepairOrders");
                });

            modelBuilder.Entity("M307_Project.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ToolName")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("M307_Project.Models.RepairOrder", b =>
                {
                    b.HasOne("M307_Project.Models.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
