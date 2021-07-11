using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ScribbleBoard.Models
{
  public class ScribbleBoardContextFactory : IDesignTimeDbContextFactory<ScribbleBoardContext>
  {

    ScribbleBoardContext IDesignTimeDbContextFactory<ScribbleBoardContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<ScribbleBoardContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new ScribbleBoardContext(builder.Options);
    }
  }
}