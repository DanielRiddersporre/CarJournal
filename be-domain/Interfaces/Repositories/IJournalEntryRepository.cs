using be_domain.Entities;

namespace be_domain.Interfaces.Repositories;

public interface IJournalEntryRepository
{
    Task<IEnumerable<JournalEntry>> GetAllJournalEntriesAsync();
    void AddJournalEntry(JournalEntry journalEntry);
    void UpdateJournalEntry(JournalEntry journalEntry);
    Task DeleteJournalEntry(Guid journalEntryId);
}