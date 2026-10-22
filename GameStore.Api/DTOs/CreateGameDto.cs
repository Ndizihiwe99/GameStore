namespace GameStore.Api.DTOs;

public record CreateGameDto(
    string Name,
    string Genre,
    DateOnly ReleaseDate
);
