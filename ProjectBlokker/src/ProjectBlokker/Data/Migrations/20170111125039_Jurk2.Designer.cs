﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectBlokker.Data;

namespace ProjectBlokker.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170111125039_Jurk2")]
    partial class Jurk2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Afspraak", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AfspraakDatum");

                    b.Property<DateTime>("AfspraakTijd");

                    b.HasKey("ID");

                    b.ToTable("Afspraak");
                });

            modelBuilder.Entity("ProjectBlokker.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Artikel", b =>
                {
                    b.Property<int>("ArtikelID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("ArtikelID");

                    b.ToTable("Artikel");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("CategorieID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Jurk", b =>
                {
                    b.Property<int>("JurkID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategorieID");

                    b.Property<int?>("KleurID");

                    b.Property<int?>("MerkID");

                    b.Property<int?>("NeklijnID");

                    b.Property<string>("Omschrijving");

                    b.Property<int>("Prijs");

                    b.Property<int?>("SilhouetteID");

                    b.Property<int?>("StijlID");

                    b.HasKey("JurkID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("KleurID");

                    b.HasIndex("MerkID");

                    b.HasIndex("NeklijnID");

                    b.HasIndex("SilhouetteID");

                    b.HasIndex("StijlID");

                    b.ToTable("Jurk");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Kleur", b =>
                {
                    b.Property<int>("KleurID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("KleurID");

                    b.ToTable("Kleur");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Merk", b =>
                {
                    b.Property<int>("MerkID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("MerkID");

                    b.ToTable("Merk");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Neklijn", b =>
                {
                    b.Property<int>("NeklijnID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("NeklijnID");

                    b.ToTable("Neklijn");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Silhouette", b =>
                {
                    b.Property<int>("SilhouetteID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("SilhouetteID");

                    b.ToTable("Silhouette");
                });

            modelBuilder.Entity("ProjectBlokker.Models.Stijl", b =>
                {
                    b.Property<int>("StijlID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam");

                    b.HasKey("StijlID");

                    b.ToTable("Stijl");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProjectBlokker.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjectBlokker.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectBlokker.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectBlokker.Models.Jurk", b =>
                {
                    b.HasOne("ProjectBlokker.Models.Categorie", "categorie")
                        .WithMany("Jurken")
                        .HasForeignKey("CategorieID");

                    b.HasOne("ProjectBlokker.Models.Kleur", "kleur")
                        .WithMany()
                        .HasForeignKey("KleurID");

                    b.HasOne("ProjectBlokker.Models.Merk", "merk")
                        .WithMany("Jurken")
                        .HasForeignKey("MerkID");

                    b.HasOne("ProjectBlokker.Models.Neklijn", "neklijn")
                        .WithMany("Jurken")
                        .HasForeignKey("NeklijnID");

                    b.HasOne("ProjectBlokker.Models.Silhouette", "silhouette")
                        .WithMany("Jurken")
                        .HasForeignKey("SilhouetteID");

                    b.HasOne("ProjectBlokker.Models.Stijl", "stijl")
                        .WithMany("Jurken")
                        .HasForeignKey("StijlID");
                });
        }
    }
}