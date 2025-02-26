using be_api.Dtos;
using be_domain.Entities;

namespace be_api.Mappers;

public class JournalEntryApiMapper
{
    public JournalEntry ToDomainEntity(JournalEntryDto journalEntryDto)
    {
        return new JournalEntry(
            journalEntryDto.Id,
            journalEntryDto.Category,
            journalEntryDto.Comment,
            journalEntryDto.Date,
            journalEntryDto.DistanceInKilometers,
            journalEntryDto.Cost
        );
    }

    public JournalEntryDto ToDto(JournalEntry journalEntry)
    {
        return new JournalEntryDto(
            journalEntry.Id,
            journalEntry.Category,
            journalEntry.Comment,
            journalEntry.Date,
            journalEntry.DistanceInKilometers, 
            journalEntry.Cost
        );
    }

    public IEnumerable<JournalEntryDto> ToDtos(IEnumerable<JournalEntry> journalEntries)
    {
        return journalEntries.Select(journalEntry => ToDto(journalEntry));
    }
}