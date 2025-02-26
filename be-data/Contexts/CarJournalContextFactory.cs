using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace be_data.contexts;

public class CarJournalContextFactory : IDesignTimeDbContextFactory<CarJournalContext>
{
    public CarJournalContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarJournalContext>();
        optionsBuilder.UseSqlServer(
            "Server=127.17.0.2,1433;Database=CarJournal;User=SA;Password=MniDR1986!;Encrypt=True;TrustServerCertificate=True;");
        
        return new CarJournalContext(optionsBuilder.Options);
    }
}