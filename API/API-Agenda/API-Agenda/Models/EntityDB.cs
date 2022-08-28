using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API_Agenda.Models
{
    public class EntityDB : DbContext
    {
        public EntityDB(DbContextOptions options) : base(options)
        {
        }
        public System.Data.Entity.DbSet<Evento> Eventos { get; set; }
    }
}
