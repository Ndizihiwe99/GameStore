using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record GameDto(
    int Id, 
    [Required][StringLength(50)]string Name, 
    [Required][StringLength(50)]string Genre, 
    DateOnly RealeaseDate);
