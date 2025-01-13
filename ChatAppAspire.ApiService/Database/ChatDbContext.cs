using ChatAppAspire.ApiService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChatAppAspire.ApiService.Database
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options) { }

        public DbSet<WeatherRecord> WeatherRecords { get; set; }
    }
}
