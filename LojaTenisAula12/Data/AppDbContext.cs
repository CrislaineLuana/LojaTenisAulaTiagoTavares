using LojaTenisAula12.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaTenisAula12.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {          
        }

        public DbSet<TenisModel> Tenis { get; set; }
    }
}
