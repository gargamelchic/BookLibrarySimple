using BookLibrarySimple.Data;
using BookLibrarySimple.Models;
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

    public async Task OnGetAsync()
    {
        Books = await _context.Books
            .Include(b => b.Author)
            .Include(b => b.Style)
            .Include(b => b.Publisher)
            .ToListAsync();
    }
}