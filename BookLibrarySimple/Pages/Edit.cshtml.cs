using BookLibrarySimple.Data;
using BookLibrarySimple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookLibrarySimple.Pages;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = new();

    public SelectList? AuthorsList { get; set; }
    public SelectList? StylesList { get; set; }
    public SelectList? PublishersList { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return NotFound();

        Book = book;
        await LoadSelectLists();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadSelectLists();
            return Page();
        }

        _context.Attach(Book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Books.Any(b => b.Id == Book.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadSelectLists()
    {
        AuthorsList = new SelectList(await _context.Authors.ToListAsync(), nameof(Author.Id), nameof(Author.FullName));
        StylesList = new SelectList(await _context.Styles.ToListAsync(), nameof(Style.Id), nameof(Style.Name));
        PublishersList = new SelectList(await _context.Publishers.ToListAsync(), nameof(Publisher.Id), nameof(Publisher.Name));
    }
}