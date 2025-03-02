using be_data.contexts;
using be_data.Mappers;
using be_domain.Entities;
using be_domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace be_data.repositories;

public class JournalEntryRepository : IJournalEntryRepository
{
    private readonly CarJournalContext _carJournalContext;
    private readonly JournalEntryDataMapper _journalEntryDataMapper;

    public JournalEntryRepository(
        CarJournalContext carJournalContext,
        JournalEntryDataMapper journalEntryDataMapper
    )
    {
        _carJournalContext = carJournalContext;
        _journalEntryDataMapper = journalEntryDataMapper;
    }

    public async Task<IEnumerable<JournalEntry>> GetAllJournalEntriesAsync()
    {
        var journalEntries = await _carJournalContext.JournalEntries.ToListAsync();
        return _journalEntryDataMapper.ToDomainEntities(journalEntries);
    }

    public async Task<JournalEntry?> GetJournalEntryByIdAsync(Guid id)
    {
        var journalEntryModel = await _carJournalContext.JournalEntries.FindAsync(id);
        if (journalEntryModel == null)
        {
            return null;
        }
        var journalEntry = _journalEntryDataMapper.ToDomainEntity(journalEntryModel);
        return journalEntry;
    }

    public void AddJournalEntry(JournalEntry journalEntry)
    {
        var journalEntryModel = _journalEntryDataMapper.ToModel(journalEntry);
        _carJournalContext.Add(journalEntryModel);
        _carJournalContext.SaveChanges();
    }

    public void UpdateJournalEntry(JournalEntry journalEntry)
    {
        _journalEntryDataMapper.ToModel(journalEntry);
        _carJournalContext.Entry(journalEntry).State = EntityState.Modified;
        _carJournalContext.SaveChanges();
    }

    public Task DeleteJournalEntry(Guid journalEntryId)
    {
        var journalEntryModel = _carJournalContext.JournalEntries.FirstOrDefault(j =>
            j.Id == journalEntryId
        );
        _carJournalContext.Remove(journalEntryModel);
        _carJournalContext.SaveChanges();

        return Task.CompletedTask;
    }
}
