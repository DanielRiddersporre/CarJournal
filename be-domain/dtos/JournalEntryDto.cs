namespace be_domain.dtos;

public class JournalEntryDto
{
    public string Type { get; set; }
    public string Comment { get; set; }
    public DateOnly Date { get; set; }
    public int DistanceInKilometers { get; set; }
    public int Cost { get; set; }

    public JournalEntryDto(string type, string comment, DateOnly date, int distanceInKilometers, int cost)
    {
        Type = type;
        Comment = comment;
        Date = date;
        DistanceInKilometers = distanceInKilometers;
        Cost = cost;
    }
}