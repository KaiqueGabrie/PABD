using APIservico.Models;
using Microsoft.EntityFrameworkCore;

namespace APIservico.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Chamado> Chamados { get; set; }
    }
}
