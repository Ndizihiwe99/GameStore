using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record UpdateGameDto (
    [Required][StringLength(50)]string Name,
    [Required][StringLength(50)]string Genre,
    DateOnly ReleaseDate
);

