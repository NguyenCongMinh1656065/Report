﻿// <auto-generated />
using Hello_World.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hello_World.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hello_World.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("Hello_World.Models.BillOwner", b =>
                {
                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("BillId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("BillOwner");
                });

            modelBuilder.Entity("Hello_World.Models.BillStatus", b =>
                {
                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("BillId", "StatusId");

                    b.HasIndex("StatusId");

                    b.ToTable("BillStatus");
                });

            modelBuilder.Entity("Hello_World.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Hello_World.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Hello_World.Models.BillOwner", b =>
                {
                    b.HasOne("Hello_World.Models.Bill", "Bill")
                        .WithMany("BillOwner")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hello_World.Models.Owner", "Owner")
                        .WithMany("BillOwner")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Hello_World.Models.BillStatus", b =>
                {
                    b.HasOne("Hello_World.Models.Bill", "Bill")
                        .WithMany("BillStatus")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hello_World.Models.Status", "Status")
                        .WithMany("BillStatus")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Hello_World.Models.Bill", b =>
                {
                    b.Navigation("BillOwner");

                    b.Navigation("BillStatus");
                });

            modelBuilder.Entity("Hello_World.Models.Owner", b =>
                {
                    b.Navigation("BillOwner");
                });

            modelBuilder.Entity("Hello_World.Models.Status", b =>
                {
                    b.Navigation("BillStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
