using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using wdws.Models;
using WDWS.Models;

namespace WDWS.Data;

public class ApplicationDbContext : IdentityDbContext<Korisnik, IdentityRole<String>, String>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Korisnik> Korisnici { get; set; }
    public DbSet<Klijent> Klijenti { get; set; }
    public DbSet<Putovanje> Putovanja { get; set; }
    public DbSet<Rezervacija> Rezervacije { get; set; }
    public DbSet<TuristickiVodic> TuristickiVodici { get; set; }
    public DbSet<Pasos> Pasosi { get; set; }
    public DbSet<Recenzija> Recenzije { get; set; }
    public DbSet<Smjestaj> Smjestaji { get; set; }
    public DbSet<Soba> Sobe { get; set; }
    public DbSet<Lokacija> Lokacije { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Korisnik>().ToTable("Korisnici");
        modelBuilder.Entity<Klijent>().ToTable("Klijenti");
        modelBuilder.Entity<Lokacija>().ToTable("Lokacije");
        modelBuilder.Entity<Soba>().ToTable("Sobe");
        modelBuilder.Entity<Smjestaj>().ToTable("Smjestaji");
        modelBuilder.Entity<Pasos>().ToTable("Pasosi");
        modelBuilder.Entity<Recenzija>().ToTable("Recenzije");
        modelBuilder.Entity<TuristickiVodic>().ToTable("Turisticki vodici");
        modelBuilder.Entity<Putovanje>().ToTable("Putovanja");
        modelBuilder.Entity<Rezervacija>().ToTable("Rezervacije");
        
        modelBuilder.Entity<Klijent>().HasBaseType<Korisnik>();
        modelBuilder.Entity<TuristickiVodic>().HasBaseType<Korisnik>();
        base.OnModelCreating(modelBuilder);
    }
} 
