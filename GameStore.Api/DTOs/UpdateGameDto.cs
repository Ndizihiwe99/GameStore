namespace GameStore.Api.DTOs;

public record UpdateGameDto (
    string Name,
    string Genre,
    DateOnly ReleaseDate
);

