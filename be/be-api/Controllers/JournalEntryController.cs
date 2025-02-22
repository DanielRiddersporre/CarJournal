using Microsoft.AspNetCore.Mvc;

namespace be_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntryController : ControllerBase
    {
        List<JournalEntryModel> journalEntries = new()
        {
            new JournalEntryModel("Gas", "Eslövs biogas", new DateTime(2024, 10, 15), 15954, 596),
            new JournalEntryModel("Service", "Mekonomen", new DateTime(2024, 12, 6), 16215, 4095),
        };

        [HttpGet]
        public IEnumerable<JournalEntryModel> GetAllJournalEntries()
        {
            return journalEntries;
        }

        [HttpPost]
        public async Task<IActionResult> AddJournalEntry([FromBody] JournalEntryModel newEntry)
        {
            if (newEntry == null)
            {
                return BadRequest("Invalid data");
            }

            journalEntries.Add(newEntry);

            return Ok(newEntry);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveJournalEntry(Guid id)
        {
            var journalEntry = journalEntries.FirstOrDefault(j => j.Id == id);

            if(journalEntry == null)
            {
                return BadRequest("Journal Entry not found!");
            }

            journalEntries.Remove(journalEntry);

            return Ok(journalEntry);
        }
    }
}