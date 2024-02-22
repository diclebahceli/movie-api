using System.Reflection;

namespace movie.Domain;

public class Movie : EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    public Movie(string title, string description, int year, int genreId, Genre genre)
    {
        Title = title;
        Description = description;
        Year = year;
        GenreId = genreId;
        Genre = genre;
    }
}
