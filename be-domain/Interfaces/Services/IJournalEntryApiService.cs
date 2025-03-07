using be_domain.Entities;

namespace be_domain.Interfaces.Services;

public interface IJournalEntryApiService
{
    public Task<IEnumerable<JournalEntry>> GetAllJournalEntriesAsync();
    Task<JournalEntry> GetJournalEntryById(Guid id);
    Task<JournalEntry> AddJournalEntry(JournalEntry journalEntryDto);
    Task UpdateJournalEntry(JournalEntry existingJournalEntry);
    Task DeleteJournalEntry(Guid id);
    Task<int> GetTotalFuelCostsAsync();
}
