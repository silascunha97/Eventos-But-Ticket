using Microsoft.EntityFrameworkCore;
using Eventos.Models;
using Microsoft.AspNetCore.Identity;

namespace Eventos.Data
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options)
            : base(options)
        {
        }

        // Define a propriedade DbSet para a entidade Evento
        public DbSet<Evento> Eventos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configurações adicionais para o modelo (opcional)
        //    base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
          modelBuilder.Entity<IdentityUser>()
              .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
      }
    }
}
