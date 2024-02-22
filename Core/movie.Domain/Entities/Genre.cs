namespace movie.Domain;

public class Genre : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }

    public Genre(string name, string description)
    {
        Name = name;
        Description = description;
        Movies = new List<Movie>();
    }
}