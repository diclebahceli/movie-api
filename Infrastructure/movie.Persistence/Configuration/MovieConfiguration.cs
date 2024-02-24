using Microsoft.EntityFrameworkCore;
using movie.Domain;

namespace movie.Persistence;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Movie> builder)
    {
        Movie movie = new Movie()
        {
            Id = 1,
            Title = "The Godfather",
            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
            Year = 1972,
            GenreId = 1
        };

        Movie movie2 = new Movie()
        {
            Id = 2,
            Title = "The Shawshank Redemption",
            Description = "Two imprisoned,",
            Year = 1994,
            GenreId = 1
        };

        builder.HasData(movie, movie2);

    }
}