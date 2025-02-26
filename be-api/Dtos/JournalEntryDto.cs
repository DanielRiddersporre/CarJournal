using System.ComponentModel.DataAnnotations;

namespace be_api.Dtos;

public class JournalEntryDto
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "{0} is required")]
    public string Category { get; set; }
    
    [Required(ErrorMessage = "{0} is required")]
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    public int DistanceInKilometers { get; set; }
    public int Cost { get; set; }

    public JournalEntryDto() { }
}