using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entities;

namespace ProAgil.Repository.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options) {}
      
        public DbSet<Evento> Evento { get; set; }
        public DbSet<EventoPalestrante> EventoPalestrante { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventoPalestrante>()
            .HasKey(PE => new {PE.PalestranteId, PE.EventoId});
        }
        
    }
}