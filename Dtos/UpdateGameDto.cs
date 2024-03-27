using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record UpdateGameDto(
    [Required][StringLength((100))] string Name, 
    int GenreId, 
    [Required][Range(1,200)]decimal Price, 
    DateOnly ReleaseDate
    );