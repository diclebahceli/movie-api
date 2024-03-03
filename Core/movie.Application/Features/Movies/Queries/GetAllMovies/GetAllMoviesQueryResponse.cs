using movie.Domain;

namespace movie.Application;

public class GetAllMoviesQueryResponse
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public Genre Genre { get; set; }

}
