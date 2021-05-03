﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using inventoryApi.Models;

namespace inventoryApi.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("inventoryApi.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("francistrinh");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 5, 2, 12, 35, 31, 474, DateTimeKind.Local).AddTicks(2500));

                    b.Property<DateTime?>("Last_Updated_Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Car", "challenge");
                });

            modelBuilder.Entity("inventoryApi.Models.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Address_Line1")
                        .HasColumnType("text");

                    b.Property<string>("Address_Line2")
                        .HasColumnType("text");

                    b.Property<int?>("Address_Postcode")
                        .HasColumnType("integer");

                    b.Property<string>("Address_State")
                        .HasColumnType("text");

                    b.Property<string>("Address_Suburb")
                        .HasColumnType("text");

                    b.Property<string>("Contact_Number")
                        .HasColumnType("text");

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("francistrinh");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 5, 2, 12, 35, 31, 459, DateTimeKind.Local).AddTicks(5400));

                    b.Property<string>("Dealer_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Last_Updated_Date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Dealer", "challenge");
                });

            modelBuilder.Entity("inventoryApi.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("francistrinh");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 5, 2, 12, 35, 31, 474, DateTimeKind.Local).AddTicks(9570));

                    b.Property<int>("DealerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Last_Updated_Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DealerId");

                    b.ToTable("Inventory", "challenge");
                });

            modelBuilder.Entity("inventoryApi.Models.InventoryTransactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("francistrinh");

                    b.Property<DateTime>("Created_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 5, 2, 12, 35, 31, 475, DateTimeKind.Local).AddTicks(5470));

                    b.Property<int>("DealerId")
                        .HasColumnType("integer");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DealerId");

                    b.ToTable("InventoryTransactions", "challenge");
                });

            modelBuilder.Entity("inventoryApi.Models.Inventory", b =>
                {
                    b.HasOne("inventoryApi.Models.Car", "Car")
                        .WithMany("Inventory")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__CarDealer__Car")
                        .IsRequired();

                    b.HasOne("inventoryApi.Models.Dealer", "Dealer")
                        .WithMany("Inventory")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("FK__CarDealer__Dealer")
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("inventoryApi.Models.InventoryTransactions", b =>
                {
                    b.HasOne("inventoryApi.Models.Car", "Car")
                        .WithMany("InventoryTransactions")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__InventoryTransactions__Car")
                        .IsRequired();

                    b.HasOne("inventoryApi.Models.Dealer", "Dealer")
                        .WithMany("InventoryTransactions")
                        .HasForeignKey("DealerId")
                        .HasConstraintName("FK__InventoryTransactions__Dealer")
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("inventoryApi.Models.Car", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("InventoryTransactions");
                });

            modelBuilder.Entity("inventoryApi.Models.Dealer", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("InventoryTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
