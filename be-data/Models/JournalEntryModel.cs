namespace be_data.Models;

public class JournalEntryModel
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    public int DistanceInKilometers { get; set; }
    public int Cost { get; set; }

    /// <summary>
    /// Parameterless constructor for EF Core
    /// </summary>
    public JournalEntryModel(){}

    public JournalEntryModel(Guid journalEntryId, string category, string comment, DateTime date,
        int distanceInKilometers, int cost)
    {
        Id = journalEntryId;
        Category = category;
        Comment = comment;
        Date = date;
        DistanceInKilometers = distanceInKilometers;
        Cost = cost;
    }
}