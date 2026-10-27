using GameStore.Api.Data;
using GameStore.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);
var connctionString = "Data Source = GameStoreDD.db";
builder.Services.AddSqlite<GameStoreContext>(connctionString);

var app = builder.Build();
const string getGameEndPointName = "GetName";

List<GameDto> games =[
    new(
    1,
    "Minecraft",
    "Sandbox",
    new DateOnly(2011, 11, 18)
),
new (2,
     "Witcher",
     "RolePlaying",
     new DateOnly(2015, 5, 19)
     ),
new(
    3,
    "EldenRing",
    "RolePlaying",
    new DateOnly(2022, 2, 25)
)];

// GET Games
app.MapGet("/games", () => games);

// GET game by ID
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(getGameEndPointName);

// POST game
app.MapPost("/games" ,(CreateGameDto newGame) => {
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(getGameEndPointName, new {id = game.Id}, game);
});

// PUT (update) game
app.MapPut("/games/{id}", (int id, UpdateGameDto updateDemo) =>
{
    var index = games.FindIndex(game => game.Id == id);
    if(index == -1)
    {
        return Results.NotFound();
    }

    games[index] = new GameDto(
        id,
        updateDemo.Name,
        updateDemo.Genre,
        updateDemo.ReleaseDate
    );

    return Results.NoContent();
    
});

// DELELTE game
app.MapDelete("/games/{id}", (int id) =>
{
    var game = games.RemoveAll(game => game.Id == id);
    return game == -1 ? Results.NotFound() : Results.Ok(game);
});

app.Run();
