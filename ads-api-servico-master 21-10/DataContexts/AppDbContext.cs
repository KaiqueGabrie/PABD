using ApiServico.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiServico.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Chamado> Chamados { get; set; }

        public DbSet<Prioridade> Prioridades { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // muitos para muitos configuração
        {
            modelBuilder.Entity<Chamado>()
                .HasMany(c => c.Usuarios) // Chamados tem muitos usuários
                .WithMany(u => u.chamados) //usuários tem chamado
                .UsingEntity<Dictionary<string, object>>(
                "chamado_usuario",
                f => f.HasOne<Usuario>().WithMany().HasForeignKey("id_usu_fk"), // Chave estrangeira para Usuário
                f => f.HasOne<Chamado>().WithMany().HasForeignKey("id_cha_fk"), // Chave estrangeira para Chamado
                f => f.ToTable("chamado_usuario") // Nome da tabela de junção (terceira tabela)
                );
        }

    }
}
