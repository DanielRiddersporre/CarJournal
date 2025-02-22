namespace be_data.entities;

public class JournalEntryEntity
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Comment { get; set; }
    public DateOnly Date { get; set; }
    public int DistanceInKilometers { get; set; }
    public int Cost { get; set; }

    public JournalEntryEntity(string type, string comment, DateOnly date, int distanceInKilometers, int cost)
    {
        Id = Guid.NewGuid();
        Type = type;
        Comment = comment;
        Date = date;
        DistanceInKilometers = distanceInKilometers;
        Cost = cost;
    }
}