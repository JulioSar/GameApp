using GameStore.API.Data;
using GameStore.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();
app.MapGenreEndPoints();
app.MapGamesEndPoints();
await app.MigrateDbAsync();

app.Run();