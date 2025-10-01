using Atividade_23_09_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividade_23_09_API.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Empresa> dadosEmpresas { get; set; }
    }
}
