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
               optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PostgresConnection"));
          }

          public DbSet<Todo> TodoItems { get; set; }
          public DbSet<TodoDetail> TodoDetails { get; set; }
     }
}