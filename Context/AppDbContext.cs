using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;

namespace MusicAPI.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Singer> Singers { get; set; }
        public DbSet<Musica> Musicas { get; set; }
    }
}
