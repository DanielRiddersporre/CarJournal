using be_domain.Entities;

namespace be_domain.Interfaces.IServices;

public interface IJournalEntryApiService
{
    public IEnumerable<JournalEntry> GetAllJournalEntries();
    Task<JournalEntry> GetJournalEntryById(Guid id);
}