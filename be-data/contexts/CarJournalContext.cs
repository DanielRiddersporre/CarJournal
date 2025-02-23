using be_data.entities;

namespace be_data.contexts;

using Microsoft.EntityFrameworkCore;

public class CarJournalContext : DbContext
{
    public DbSet<JournalEntryEntity> JournalEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=127.17.0.2,1433;Database=CarJournal;User=SA;Password=MniDR1986!;Encrypt=True;TrustServerCertificate=True;");
    }
}