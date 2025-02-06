using Microsoft.EntityFrameworkCore;
using TodoApi.Entity;
using TodoApi.Models;

namespace TodoApi.DBContext
{

     public class AppDBContext : DbContext
     {
          protected IConfiguration Configuration { get; }

          public AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration configuration) : base(options)
          {
               Configuration = configuration;
          }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               var connectionString = Configuration["ConnectionStrings:PostgresConnection"];
               optionsBuilder.UseNpgsql(connectionString);
          }

          public DbSet<Todo> TodoItems { get; set; }
          public DbSet<TodoDetail> TodoDetails { get; set; }
     }
}