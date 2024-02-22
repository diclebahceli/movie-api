namespace movie.Domain;

public class User : EntityBase
{
    public ICollection<Movie> Movies { get; set; }

    public User()
    {
        Movies = new List<Movie>();
    }
}
