using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Contexts;

    public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
        var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\source\repos\Silicon\Infrastructure\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30;");
        return new ApiContext(optionsBuilder.Options);
        }
    }

//@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\source\repos\Silicon\Infrastructure\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30;"
//@Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Skola\\Asp.Net1\\SiliconWebApp\\Infrastructure\\Data\\local_database.mdf;Integrated Security=True
