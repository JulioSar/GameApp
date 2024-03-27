using GameStore.API.Data;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.EndPoints;

public static class GenreEndPoint
{

    public static RouteGroupBuilder MapGenreEndPoints(this WebApplication app)
    {

        var group = app.MapGroup(("genres"));
        group.MapGet("/",
            async (GameStoreContext dbContext) =>
                await dbContext.Genres.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync());

        return group;
    }
    
}