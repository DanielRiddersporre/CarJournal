using Microsoft.AspNetCore.Mvc;

namespace be_api.controllers;

public class JournalEntryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}