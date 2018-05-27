﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Service.Storage.Context;
using Service.Storage.ExtraModels;
using System;

namespace Service.Storage.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Service.Storage.Entities.Problem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("GeneratorType");

                    b.Property<DateTime>("LastModifiedTime");

                    b.Property<int>("MemoryLimit");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<string>("SpecificData");

                    b.Property<double>("TimeLimit");

                    b.Property<Guid?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("Service.Storage.Entities.ProblemTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProblemId");

                    b.Property<Guid>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("ProblemId");

                    b.ToTable("ProblemTag");
                });

            modelBuilder.Entity("Service.Storage.Entities.ProblemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("ProblemTypes");
                });

            modelBuilder.Entity("Service.Storage.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Service.Storage.Entities.Problem", b =>
                {
                    b.HasOne("Service.Storage.Entities.ProblemType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Service.Storage.Entities.ProblemTag", b =>
                {
                    b.HasOne("Service.Storage.Entities.Problem", "Problem")
                        .WithMany("Tags")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Service.Storage.Entities.Tag", "Tag")
                        .WithMany("Problems")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
