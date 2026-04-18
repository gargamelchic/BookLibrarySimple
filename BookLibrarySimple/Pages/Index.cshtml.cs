using BookLibrarySimple.Data;
using BookLibrarySimple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrarySimple.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Book> Books { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchTitle { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchAuthor { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchStyle { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchPublisher { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchYear { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Books
            .Include(b => b.Author)
            .Include(b => b.Style)
            .Include(b => b.Publisher)
            .AsQueryable();

        if (!string.IsNullOrEmpty(SearchTitle))
        {
            query = query.Where(b => b.Title.Contains(SearchTitle));
        }
        if (!string.IsNullOrEmpty(SearchAuthor))
        {
            query = query.Where(b => b.Author.FullName.Contains(SearchAuthor));
        }
        if (!string.IsNullOrEmpty(SearchStyle))
        {
            query = query.Where(b => b.Style.Name.Contains(SearchStyle));
        }
        if (!string.IsNullOrEmpty(SearchPublisher))
        {
            query = query.Where(b => b.Publisher.Name.Contains(SearchPublisher));
        }
        if (!string.IsNullOrEmpty(SearchYear) && int.TryParse(SearchYear, out int year))
        {
            query = query.Where(b => b.Year == year);
        }

        Books = await query.ToListAsync();
    }
}