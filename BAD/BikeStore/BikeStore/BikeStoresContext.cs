using Microsoft.EntityFrameworkCore;

namespace BikeStore;

public class BikeStoresContext : DbContext
{
    protected override void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;" +
                                    "Database=master;" +
                                    "User Id=sa;" +
                                    "Password=HM8yg5EYJ8V8Hz;" +
                                    "TrustServerCertificate=True;");
    }
}