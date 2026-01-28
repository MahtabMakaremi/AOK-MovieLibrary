using System;
using System.Collections.Generic;
using System.Linq;


namespace AOKMovieLibrary.Models.Responses;

public record MovieMetaData
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public AOKMovieLibrary.Models.DAL.MovieGenre Genre { get; set; }

    public int Year { get; set; }

    public PersonMetaData? Director { get; set; }

    public List<PersonMetaData> Actors { get; set; } = new();

    public string? Description { get; set; }

    public int Runtime { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}

public static class MovieMetaDataMapping
{
    /// <summary>
    /// Mapping für "MetaData" (z.B. wenn du Movie-Liste / Kachelansicht hast).
    /// Da dein DAL aktuell nur DirectorId hat, werden Director/Actors optional als Parameter übergeben.
    /// </summary>
    public static MovieMetaData MapToMovieMetaData(
        this AOKMovieLibrary.Models.DAL.Movie movie,
        AOKMovieLibrary.Models.DAL.Person? director = null,
        IEnumerable<AOKMovieLibrary.Models.DAL.Person>? actors = null,
        string? description = null,
        byte[]? rowVersion = null)
    {
        return new MovieMetaData
        {
            Id = movie.Id,
            Title = movie.Name,                 // DAL: Name -> DTO: Title
            Genre = movie.Genre,
            Year = movie.ReleaseYear,           // DAL: ReleaseYear -> DTO: Year
            Director = director.MapToPersonMetaDataOrNull(),
            Actors = (actors ?? Enumerable.Empty<AOKMovieLibrary.Models.DAL.Person>())
                        .Select(a => a.MapToPersonMetaData())
                        .ToList(),
            Description = description,
            Runtime = movie.DurationMinutes,    // DAL: DurationMinutes -> DTO: Runtime
            RowVersion = rowVersion ?? Array.Empty<byte>()
        };
    }
}