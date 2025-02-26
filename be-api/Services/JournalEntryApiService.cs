using be_domain.Entities;
using be_domain.Interfaces.Services;
using be_domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace be_api.Services;

public class JournalEntryApiService : IJournalEntryApiService
{
    private readonly JournalEntryDomainService _journalEntryDomainService;

    public JournalEntryApiService(JournalEntryDomainService journalEntryDomainService)
    {
        _journalEntryDomainService = journalEntryDomainService;
    }
    
    public async Task<IEnumerable<JournalEntry>> GetAllJournalEntriesAsync()
    {
        return await _journalEntryDomainService.GetAllJournalEntriesAsync();
    }

    public Task<JournalEntry> GetJournalEntryById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<JournalEntry> AddJournalEntry(JournalEntry journalEntry)
    {
        _journalEntryDomainService.AddJournalEntry(journalEntry);
        return Task.FromResult(journalEntry);
    }

    public Task UpdateJournalEntry(JournalEntry existingJournalEntry)
    {
        _journalEntryDomainService.UpdateJournalEntry(existingJournalEntry);
        return Task.CompletedTask;
    }

    public Task DeleteJournalEntry(Guid journalEntryId)
    {
        _journalEntryDomainService.DeleteJournalEntry(journalEntryId);
        return Task.CompletedTask;
    }
}