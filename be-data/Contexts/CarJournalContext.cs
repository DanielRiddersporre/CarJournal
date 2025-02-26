using be_data.Models;
using be_domain.Entities;

namespace be_data.contexts;

using Microsoft.EntityFrameworkCore;

public class CarJournalContext : DbContext
{
    public CarJournalContext(DbContextOptions<CarJournalContext> options) : base(options)
    {
        
    }
    public virtual DbSet<JournalEntryModel> JournalEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=127.17.0.2,1433;Database=CarJournal;User=SA;Password=MniDR1986!;Encrypt=True;TrustServerCertificate=True;");
    }
}