using System.Diagnostics;
using System.Globalization;
using BookStoreTestingApp.Dtos;
using BookStoreTestingApp.IRepositories;
using Microsoft.AspNetCore.Mvc;
using BookStoreTestingApp.Models;

namespace BookStoreTestingApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBookRepository _bookRepository;
    
    public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
    {
        _logger = logger;
        _bookRepository = bookRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult GenerateBooks(GenerateBookRequestDto request)
    {
        IEnumerable<Book> books = _bookRepository.GenerateBooks(language: request.Language,
            seed: request.Seed, 
            likes: request.Likes,
            reviews: request.Reviews,
            numberOfBooks: request.NumberOfBooks,
            lastRowId: request.LastRowId);
        
        return Json(new
        {
            data = books
        });
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}