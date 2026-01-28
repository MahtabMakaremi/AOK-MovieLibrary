namespace AOKMovieLibrary.Models.ViewModels;

public record MovieOverviewData
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int Year { get; set; }

    public AOKMovieLibrary.Models.DAL.MovieGenre Genre { get; set; }

    // Für UI wie im Screenshot: "Action, SciFi"
    public string GenreText { get; set; } = string.Empty;

    // Minuten
    public int Runtime { get; set; }
    public string PosterUrl { get; set; } = "images/poster.png";

}

public static class MovieOverviewDataMapping
{
    public static MovieOverviewData MapToMovieOverviewData(this AOKMovieLibrary.Models.DAL.Movie movie)
    {
        return new MovieOverviewData
        {
            Id = movie.Id,
            Title = movie.Name,
            Year = movie.ReleaseYear,
            Genre = movie.Genre,
            GenreText = movie.Genre == AOKMovieLibrary.Models.DAL.MovieGenre.None
                ? "None"
                : movie.Genre.ToString().Replace(", ", ", "),
            Runtime = movie.DurationMinutes,
            PosterUrl = string.IsNullOrWhiteSpace(movie.PosterFileName)
    ?       "images/poster.png"
    :       $"images/posters/{movie.PosterFileName}"
        };
    }
}