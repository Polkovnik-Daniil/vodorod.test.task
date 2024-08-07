﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vodorod.test.task.data.access;

#nullable disable

namespace vodorod.test.task.data.access.Migrations
{
    [DbContext(typeof(VodorotTestTaskDbContext))]
    [Migration("20240806101028_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("vodorod.test.task.data.access.Entities.RateEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cur_Abbreviation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Cur_OfficialRate")
                        .HasColumnType("numeric");

                    b.Property<int>("Cur_Scale")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp(6)");

                    b.HasKey("Id");

                    b.ToTable("RateEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
