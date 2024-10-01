﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPages.Data;

#nullable disable

namespace RazorPages.Migrations
{
    [DbContext(typeof(ApplicationDB))]
    partial class ApplicationDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RazorPages.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("categoryRazor");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action",
                            DisplayOrder = 1
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Horror",
                            DisplayOrder = 2
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Adevnture",
                            DisplayOrder = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
