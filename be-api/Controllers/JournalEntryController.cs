using be_api.models;
using Microsoft.AspNetCore.Mvc;

namespace be_api.controllers;

/// <summary>
/// Controller that handles all CRUD actions around journal entries.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class JournalEntryController : Controller
{
    private List<JournalEntryModel> _journalEntries = new List<JournalEntryModel>()
    {
        new JournalEntryModel("gas", "Testing", new DateOnly(2025,01,19), 15945, 596),
        new JournalEntryModel("service", "Mekonomen", new DateOnly(2025, 01, 15), 16721, 4800)
    };
    
    /// <summary>
    /// Get all journal entries without any filtering
    /// </summary>
    /// <returns>All journal entries</returns>
    [HttpGet]
    public IEnumerable<JournalEntryModel> GetAllJournalEntries()
    {
        var journalEntries = _journalEntries;
        return journalEntries; 
    }

    /// <summary>
    /// Get a specific journal entry by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The requested journal entry</returns>
    [HttpGet("{id}")]
    public async Task<JournalEntryModel> GetJournalEntry(Guid id)
    {
        var journalEntry = _journalEntries.FirstOrDefault(j => j.Id == id);
        
        return journalEntry;
    }
    
    /// <summary>
    /// Add a journal entry to the database
    /// </summary>
    /// <param name="journalEntryModel"></param>
    /// <returns>The added JournalEntryModel</returns>
    [HttpPost]
    public IActionResult AddJournalEntry([FromBody] JournalEntryModel journalEntryModel)
    {
        if (journalEntryModel == null)
        {
            return BadRequest();
        }
        
        _journalEntries.Add(journalEntryModel);
        
        return Ok(journalEntryModel);
    }

    /// <summary>
    /// Update an existing journal entry with new data
    /// </summary>
    /// <param name="id"></param>
    /// <param name="journalEntryModel"></param>
    /// <returns>The data from the updated journal entry</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateJournalEntry(Guid id, [FromBody] JournalEntryModel journalEntryModel)
    {
        var existingJournalEntry = _journalEntries.FirstOrDefault(j => j.Id == id);
        if (existingJournalEntry == null)
        {
            return BadRequest();
        }
        
        existingJournalEntry.Type = journalEntryModel.Type;
        existingJournalEntry.Comment = journalEntryModel.Comment;
        existingJournalEntry.Date = journalEntryModel.Date;
        existingJournalEntry.DistanceInKilometers = journalEntryModel.DistanceInKilometers;
        existingJournalEntry.Cost = journalEntryModel.Cost;
        
        return Ok(existingJournalEntry);
    }
}