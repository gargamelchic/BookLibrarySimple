namespace BookLibrarySimple.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }

    public int AuthorId { get; set; }
    public int StyleId { get; set; }
    public int PublisherId { get; set; }

    public Author Author { get; set; } = null!;
    public Style Style { get; set; } = null!;
    public Publisher Publisher { get; set; } = null!;
}