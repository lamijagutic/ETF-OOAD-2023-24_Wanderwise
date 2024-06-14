﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WDWS.Data;

#nullable disable

namespace WDWS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<string>", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Korisnik", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pozicija")
                        .HasColumnType("int");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("wdws.Models.Lokacija", b =>
                {
                    b.Property<string>("postanskiBroj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazivMjesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("postanskiBroj");

                    b.ToTable("Lokacije", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Pasos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("clientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("datumIsteka")
                        .HasColumnType("date");

                    b.Property<string>("drzavaKojaIzdaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nacionalnost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("napomene")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("clientID");

                    b.ToTable("Pasosi", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Putovanje", b =>
                {
                    b.Property<int>("travelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("travelId"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpisPutovanja")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<double>("cijenaPoOsobi")
                        .HasColumnType("float");

                    b.Property<DateTime>("datumDolaska")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumPolaska")
                        .HasColumnType("datetime2");

                    b.Property<int>("duzinaPutovanja")
                        .HasColumnType("int");

                    b.Property<string>("guideID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("mjestoDolaskaID")
                        .HasColumnType("int");

                    b.Property<int>("mjestoPolaskaID")
                        .HasColumnType("int");

                    b.Property<string>("nazivPutovanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prijevoz")
                        .HasColumnType("int");

                    b.Property<int?>("smjestajID")
                        .HasColumnType("int");

                    b.HasKey("travelId");

                    b.HasIndex("guideID");

                    b.HasIndex("smjestajID");

                    b.ToTable("Putovanja", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Recenzija", b =>
                {
                    b.Property<int>("reviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reviewID"));

                    b.Property<string>("clientID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("klijentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("putID")
                        .HasColumnType("int");

                    b.Property<string>("tekstRecenzije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reviewID");

                    b.HasIndex("klijentId");

                    b.HasIndex("putID");

                    b.ToTable("Recenzije", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Rezervacija", b =>
                {
                    b.Property<int>("reservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reservationID"));

                    b.Property<int>("MilesBodovi")
                        .HasColumnType("int");

                    b.Property<bool>("VodicUkljucen")
                        .HasColumnType("bit");

                    b.Property<int>("brojPutnika")
                        .HasColumnType("int");

                    b.Property<string>("klijentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("putovanjeID")
                        .HasColumnType("int");

                    b.Property<int>("rezervisanaSobaID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("ukupnaCijena")
                        .HasColumnType("float");

                    b.HasKey("reservationID");

                    b.HasIndex("klijentID");

                    b.HasIndex("putovanjeID");

                    b.ToTable("Rezervacije", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Smjestaj", b =>
                {
                    b.Property<int>("lodgingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lodgingID"));

                    b.Property<double>("CijenaSmjestaja")
                        .HasColumnType("float");

                    b.Property<string>("KontaktEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxKapacitet")
                        .HasColumnType("int");

                    b.Property<int>("VrstaSmjestaja")
                        .HasColumnType("int");

                    b.Property<int>("lokacijaID")
                        .HasColumnType("int");

                    b.Property<string>("lokacijapostanskiBroj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("lodgingID");

                    b.HasIndex("lokacijapostanskiBroj");

                    b.ToTable("Smjestaji", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Soba", b =>
                {
                    b.Property<int>("roomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roomID"));

                    b.Property<double>("cijena")
                        .HasColumnType("float");

                    b.Property<int>("kapacitetSobe")
                        .HasColumnType("int");

                    b.Property<int>("smjestajID")
                        .HasColumnType("int");

                    b.Property<int>("tipSobe")
                        .HasColumnType("int");

                    b.HasKey("roomID");

                    b.HasIndex("smjestajID");

                    b.ToTable("Sobe", (string)null);
                });

            modelBuilder.Entity("wdws.Models.Klijent", b =>
                {
                    b.HasBaseType("wdws.Models.Korisnik");

                    b.Property<string>("kontaktZaHitneSlucajeve")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nagradniBodovi")
                        .HasColumnType("int");

                    b.Property<string>("napomene")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Klijenti", (string)null);
                });

            modelBuilder.Entity("wdws.Models.TuristickiVodic", b =>
                {
                    b.HasBaseType("wdws.Models.Korisnik");

                    b.Property<bool>("dostupnost")
                        .HasColumnType("bit");

                    b.Property<string>("jezici")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Turisticki vodici", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<string>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("wdws.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("wdws.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<string>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wdws.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("wdws.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wdws.Models.Pasos", b =>
                {
                    b.HasOne("wdws.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("clientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klijent");
                });

            modelBuilder.Entity("wdws.Models.Putovanje", b =>
                {
                    b.HasOne("wdws.Models.TuristickiVodic", "TuristickiVodic")
                        .WithMany()
                        .HasForeignKey("guideID");

                    b.HasOne("wdws.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("smjestajID");

                    b.Navigation("Smjestaj");

                    b.Navigation("TuristickiVodic");
                });

            modelBuilder.Entity("wdws.Models.Recenzija", b =>
                {
                    b.HasOne("wdws.Models.Klijent", "klijent")
                        .WithMany()
                        .HasForeignKey("klijentId");

                    b.HasOne("wdws.Models.Putovanje", "Putovanje")
                        .WithMany("recenzije")
                        .HasForeignKey("putID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Putovanje");

                    b.Navigation("klijent");
                });

            modelBuilder.Entity("wdws.Models.Rezervacija", b =>
                {
                    b.HasOne("wdws.Models.Klijent", "Klijent")
                        .WithMany()
                        .HasForeignKey("klijentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wdws.Models.Putovanje", "Putovanje")
                        .WithMany()
                        .HasForeignKey("putovanjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klijent");

                    b.Navigation("Putovanje");
                });

            modelBuilder.Entity("wdws.Models.Smjestaj", b =>
                {
                    b.HasOne("wdws.Models.Lokacija", "lokacija")
                        .WithMany()
                        .HasForeignKey("lokacijapostanskiBroj");

                    b.Navigation("lokacija");
                });

            modelBuilder.Entity("wdws.Models.Soba", b =>
                {
                    b.HasOne("wdws.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("smjestajID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Smjestaj");
                });

            modelBuilder.Entity("wdws.Models.Klijent", b =>
                {
                    b.HasOne("wdws.Models.Korisnik", null)
                        .WithOne()
                        .HasForeignKey("wdws.Models.Klijent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wdws.Models.TuristickiVodic", b =>
                {
                    b.HasOne("wdws.Models.Korisnik", null)
                        .WithOne()
                        .HasForeignKey("wdws.Models.TuristickiVodic", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wdws.Models.Putovanje", b =>
                {
                    b.Navigation("recenzije");
                });
#pragma warning restore 612, 618
        }
    }
}
