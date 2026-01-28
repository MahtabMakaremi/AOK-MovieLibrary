namespace AOKMovieLibrary.Models.DAL;



public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

   
    public MovieGenre Genre { get; set; } = MovieGenre.None;

    public int ReleaseYear { get; set; }
    public int DurationMinutes { get; set; }

    public Guid? DirectorId { get; set; }
    public decimal Rating { get; set; } 

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }
    public string? PosterFileName { get; set; }

    public string GenreText => Genre == MovieGenre.None
        ? "None"
        : Genre.ToString().Replace(", ", ", ");
}


