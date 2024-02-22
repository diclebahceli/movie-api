using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using movie.Domain;

namespace movie.Persistence;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Movies)
        .WithMany(m => m.FavoritedUsers);


        User user = new User() { Id = 1 };
        User user1 = new User() { Id = 2 };
        User user2 = new User() { Id = 3 };
        builder.HasData(user, user1, user2);
    }
}
