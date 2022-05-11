﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using demo.DAL;

namespace demo.DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220510064243_MyMigration")]
    partial class MyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("demo.Models.ProductType", b =>
                {
                    b.Property<int>("PTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PTName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PTID");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("demo.Models.Products", b =>
                {
                    b.Property<int>("ProID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PTID")
                        .HasColumnType("int");

                    b.Property<string>("PorName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("ProPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProID");

                    b.HasIndex("PTID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("demo.Models.Products", b =>
                {
                    b.HasOne("demo.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("PTID")
                        .HasConstraintName("FK_Products_ProductType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("demo.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}