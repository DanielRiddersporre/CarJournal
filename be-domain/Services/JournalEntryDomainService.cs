using be_domain.Entities;
using be_domain.Interfaces.Repositories;

namespace be_domain.Services;

public class JournalEntryDomainService
{
    private readonly IJournalEntryRepository _journalEntryRepository;

    public JournalEntryDomainService(IJournalEntryRepository journalEntryRepository)
    {
        _journalEntryRepository = journalEntryRepository;
    }

    public async Task<IEnumerable<JournalEntry>> GetAllJournalEntriesAsync()
    {
        return await _journalEntryRepository.GetAllJournalEntriesAsync();
    }

    public void AddJournalEntry(JournalEntry journalEntry)
    {
        if (journalEntry.Id == Guid.Empty)
        {
            journalEntry.Id = Guid.NewGuid();
        }
        
        _journalEntryRepository.AddJournalEntry(journalEntry);
    }

    public void UpdateJournalEntry(JournalEntry journalEntry)
    {
        _journalEntryRepository.UpdateJournalEntry(journalEntry);
    }

    public void DeleteJournalEntry(Guid journalEntryId)
    {
        _journalEntryRepository.DeleteJournalEntry(journalEntryId);
    }

    public async Task<int> GetTotalFuelCostsAsync()
    {
        return await _journalEntryRepository.GetTotalFuelCostsAsync();
    }
}