using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

public class CourseContextFactory : IDesignTimeDbContextFactory<CourseContext>
{
    public CourseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CourseContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\source\repos\Silicon\Infrastructure\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30;");
        return new CourseContext(optionsBuilder.Options);
    }
}
