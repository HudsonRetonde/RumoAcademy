using Microsoft.EntityFrameworkCore;
using BotAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BotAPI.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
