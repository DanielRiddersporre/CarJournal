using System.Diagnostics;
using be_api.Dtos;
using be_api.Mappers;
using be_domain.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace be_api.controllers;

/// <summary>
/// Controller that handles all CRUD actions around journal entries.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class JournalEntryController : Controller
{
    private readonly IJournalEntryApiService _journalEntryApiService;
    private readonly JournalEntryApiMapper _journalEntryApiMapper;

    public JournalEntryController(
        IJournalEntryApiService journalEntryApiService,
        JournalEntryApiMapper journalEntryApiMapper
    )
    {
        _journalEntryApiService = journalEntryApiService;
        _journalEntryApiMapper = journalEntryApiMapper;
    }

    /// <summary>
    /// Get all Journal Entries.
    /// </summary>
    /// <returns>All journal entries</returns>
    [HttpGet("all")]
    public async Task<IEnumerable<JournalEntryDto>> GetAllJournalEntries()
    {
        var journalEntries = await _journalEntryApiService.GetAllJournalEntriesAsync();

        return _journalEntryApiMapper.ToDtos(journalEntries);
    }

    /// <summary>
    /// Get all Journal Entries.
    /// </summary>
    /// <returns>All journal entries</returns>
    [HttpGet("total-fuel-costs")]
    public async Task<int> GetTotalFuelCosts()
    {
        var totalCost = await _journalEntryApiService.GetTotalFuelCostsAsync();

        return totalCost;
    }

    /// <summary>
    /// Get a specific journal entry by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The requested journal entry</returns>
    [HttpGet("{id}")]
    public async Task<JournalEntryDto> GetJournalEntryById(Guid id)
    {
        var journalEntry = await _journalEntryApiService.GetJournalEntryById(id);
        return _journalEntryApiMapper.ToDto(journalEntry);
    }

    /// <summary>
    /// Add a journal entry to the database
    /// </summary>
    /// <param name="journalEntryDto"></param>
    /// <returns>The added JournalEntryModel</returns>
    [HttpPost]
    public async Task<IActionResult> AddJournalEntry([FromBody] JournalEntryDto journalEntryDto)
    {
        try
        {
            var journalEntry = _journalEntryApiMapper.ToDomainEntity(journalEntryDto);
            await _journalEntryApiService.AddJournalEntry(journalEntry);

            return Ok(journalEntry);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    /// <summary>
    /// Update an existing journal entry with new data
    /// </summary>
    /// <param name="id"></param>
    /// <param name="journalEntryDto"></param>
    /// <returns>The data from the updated journal entry</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJournalEntry(
        Guid id,
        [FromBody] JournalEntryDto journalEntryDto
    )
    {
        var existingJournalEntry = await _journalEntryApiService.GetJournalEntryById(id);

        existingJournalEntry.Category = journalEntryDto.Category;
        existingJournalEntry.Comment = journalEntryDto.Comment;
        existingJournalEntry.Date = journalEntryDto.Date;
        existingJournalEntry.DistanceInKilometers = journalEntryDto.DistanceInKilometers;
        existingJournalEntry.Cost = journalEntryDto.Cost;

        await _journalEntryApiService.UpdateJournalEntry(existingJournalEntry);

        return Ok(existingJournalEntry);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJournalEntry(Guid id)
    {
        await _journalEntryApiService.DeleteJournalEntry(id);

        return Ok();
    }
}
