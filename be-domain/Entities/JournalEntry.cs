namespace be_domain.Entities;

public class JournalEntry
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    public int DistanceInKilometers { get; set; }
    public int Cost { get; set; }

    public JournalEntry(Guid id, string category, string comment, DateTime date, int distanceInKilometers, int cost)
    {
        Id = id;
        Category = category;
        Comment = comment;
        Date = date;
        DistanceInKilometers = distanceInKilometers;
        Cost = cost;
    }
}