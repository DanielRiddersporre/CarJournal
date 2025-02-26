using be_data.Models;
using be_domain.Entities;

namespace be_data.Mappers;

public class JournalEntryDataMapper
{
    public JournalEntry? ToDomainEntity(JournalEntryModel journalEntryModel)
    {
        return new JournalEntry(
            journalEntryModel.Id,
            journalEntryModel.Category,
            journalEntryModel.Comment,
            journalEntryModel.Date,
            journalEntryModel.DistanceInKilometers,
            journalEntryModel.Cost
        );
    }

    public JournalEntryModel ToModel(JournalEntry journalEntry)
    {
        return new JournalEntryModel(
            Guid.NewGuid(),
            journalEntry.Category,
            journalEntry.Comment,
            journalEntry.Date,
            journalEntry.DistanceInKilometers,
            journalEntry.Cost
        );
    }
    
    public IEnumerable<JournalEntry> ToDomainEntities(IEnumerable<JournalEntryModel> journalEntries)
    {
        return journalEntries.Select(journalEntry => ToDomainEntity(journalEntry));
    }
}