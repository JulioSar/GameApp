using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record CreateGameDto(
    [Required][StringLength((100))] string Name, 
    int GenreId, 
    [Required][Range(1,200)]decimal Price, 
    DateOnly ReleaseDate
    );