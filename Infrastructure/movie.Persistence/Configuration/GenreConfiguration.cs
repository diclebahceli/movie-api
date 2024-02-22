using Microsoft.EntityFrameworkCore;
using movie.Domain;

namespace movie.Persistence;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Genre> builder)
    {
        builder.HasMany(g => g.Movies)
            .WithOne(m => m.Genre)
            .HasForeignKey(m => m.GenreId);



        Genre genre = new Genre() { Id = 1, Name = "Drama", 
        Description = "Drama is a category of narrative fiction intended to be more serious than humorous in tone." };
    }
}