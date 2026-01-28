namespace AOKMovieLibrary.Models.Commands;

public record CreateMovieCommand
{
    public string Title { get; init; } = string.Empty;
    public AOKMovieLibrary.Models.DAL.MovieGenre Genre { get; init; }
    public int Year { get; init; }
    public int Runtime { get; init; }
    public decimal Rating { get; init; }
}
