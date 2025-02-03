using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using TodoApi.DBContext;
using TodoApi.Services;

namespace TodoApi.Extensions
{
  /// <summary>
  /// Provides extension methods for adding services to the IServiceCollection.
  /// </summary>
  public static class Services
  {
    /// <summary>
    /// Adds services to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      // Adding another service
      services.AddControllers().AddNewtonsoftJson(options =>
      {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      });
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
      // Mapping services
      services.AddScoped<ITodoService, TodoService>();

      return services;
    }
  }
}