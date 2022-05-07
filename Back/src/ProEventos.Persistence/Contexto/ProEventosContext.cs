using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contexto
{
    public class ProEventosContext : DbContext
    {
<<<<<<< HEAD
        
=======
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }

        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                        .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<Evento>()
                        .HasMany(e => e.RedesSociais)
                        .WithOne(rs => rs.Evento)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                        .HasMany(e => e.RedesSociais)
                        .WithOne(rs => rs.Palestrante)
                        .OnDelete(DeleteBehavior.Cascade);
        }

    }
}