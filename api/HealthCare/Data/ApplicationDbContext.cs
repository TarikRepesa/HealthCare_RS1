using HealthCare.Models;
using HealthCare.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Nalaz>()
               .HasOne(p => p.Pacijent)
               .WithMany(n => n.Nalazi)
               .HasForeignKey(p => p.PacijentId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Uputnica>()
                .HasOne(p => p.Pacijent)
                .WithMany(u => u.Uputnice)
                .HasForeignKey(p => p.PacijentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Termin>()
                .HasOne(p => p.Pacijent)
                .WithMany(t => t.Termini)
                .HasForeignKey(p => p.PacijentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recept>()
                .HasOne(p => p.Pacijent)
                .WithMany(r => r.Recepti)
                .HasForeignKey(p => p.PacijentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pacijent>()
                .HasOne(p => p.ZdravstvenaLegitimacija)
                .WithOne(c => c.Pacijent)
                .HasForeignKey<ZdravstvenaLegitimacija>(c => c.PacijentId);

            modelBuilder.Entity<Pacijent>()
                .HasOne(p => p.Karton)
                .WithOne(c => c.Pacijent)
                .HasForeignKey<Karton>(c => c.PacijentId);
        }

        public DbSet<AuthToken> AuthToken { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Osoblje> Osoblje { get; set; }
        public DbSet<Pacijent> Pacijent { get; set; }
        public DbSet<Asistent> Asistent { get; set; }
        public DbSet<Ljekar> Ljekar { get; set; }
        public DbSet<Tehnicar> Tehnicar { get; set; }
        public DbSet<Farmaceut> Farmaceut { get; set; }
        public DbSet<ZdravstvenaLegitimacija> ZdravstvenaLegitimacija { get; set; }
        public DbSet<Uloga> Uloga { get; set; }
        public DbSet<Karton> Karton { get; set; }
        public DbSet<Nalaz> Nalaz { get; set; }
        public DbSet<Uputnica> Uputnica { get; set; }
        public DbSet<Recept> Recept { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<Lijek> Lijek { get; set; }
        public DbSet<Ambulanta> Ambulanta { get; set; }
        public DbSet<Termin> Termin { get; set; }
        public DbSet<Bolnica> Bolnica { get; set; }
        public DbSet<Menadzment> Menadzment { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<Odjeljenje> Odjeljenje { get; set; }
        public DbSet<Odsjek> Odsjek { get; set; }
        public DbSet<SifraBolesti> SifraBolesti { get; set; }
        public DbSet<UputnicaSifraBolesti> UputnicaSifraBolesti { get; set; }
        public DbSet<Apoteka> Apoteka { get; set; }
        public DbSet<Obavijesti> Obavijesti { get; set; }
        public DbSet<ZahtjevLijek> ZahtjevLijekovi { get; set; }        
    }
}
