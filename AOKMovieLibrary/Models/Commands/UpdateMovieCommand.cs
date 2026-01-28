namespace AOKMovieLibrary.Models.Commands;

public record UpdateMovieCommand
{
    public string? Title { get; init; }
    public AOKMovieLibrary.Models.DAL.MovieGenre Genre { get; init; }
    public int Year { get; init; }
    public int Runtime { get; init; }
    public decimal Rating { get; init; }
}
