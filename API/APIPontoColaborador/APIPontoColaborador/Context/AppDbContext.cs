using APIPontoColaborador.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIPontoColaborador.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {}

        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<Funcionario>? Funcionarios { get; set; }
        public DbSet<Ponto>? Pontos { get; set; }
        public DbSet<Lideranca>? Liderancas { get; set; }
        public DbSet<Equipe>? Equipes { get; set; }

    }
    
}
