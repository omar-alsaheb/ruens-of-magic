﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Db;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(ROM_Account))]
    [Migration("20220502210115_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Models.PlayerAccount", b =>
                {
                    b.Property<string>("Account_ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAutoConvertMd5")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMd5Password")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Account_ID");

                    b.ToTable("PlayerAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
