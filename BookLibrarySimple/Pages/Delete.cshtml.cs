using BookLibrarySimple.Data;
using BookLibrarySimple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrarySimple.Pages;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var book = await _context.Books
            .Include(b => b.Author)
            .Include(b => b.Style)
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
            return NotFound();

        Book = book;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var book = await _context.Books.FindAsync(Book.Id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage("./Index");
    }
}