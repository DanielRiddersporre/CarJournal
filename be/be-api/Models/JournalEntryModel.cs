namespace be_api;

public class JournalEntryModel{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string? Comment { get; set; }
    public DateTime Date { get; set; }
    public int? DistanceInKilometers { get; set; }
    public int Cost { get; set; }

    public JournalEntryModel(string type, string comment, DateTime date, int distanceInKilometers, int cost){
        
        Id = Guid.NewGuid();
        Type = type;
        Comment = comment;
        Date = date;
        DistanceInKilometers = distanceInKilometers;
        Cost = cost;
    }
}