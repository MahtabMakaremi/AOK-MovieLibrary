using System;
using System.Collections.Generic;
using System.Linq;


namespace AOKMovieLibrary.Models.ViewModels;

public record MovieDetailData
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public AOKMovieLibrary.Models.DAL.MovieGenre Genre { get; set; }

    public int Year { get; set; }

    public PersonMetaData? Director { get; set; }

    public List<PersonMetaData> Actors { get; set; } = new();

    public string? Description { get; set; }

    public int Runtime { get; set; }

    public decimal Rating { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? UpdatedAtUtc { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}

public static class MovieDetailDataMapping
{
    public static MovieDetailData MapToMovieDetailData(
        this AOKMovieLibrary.Models.DAL.Movie movie,
        AOKMovieLibrary.Models.DAL.Person? director = null,
        IEnumerable<AOKMovieLibrary.Models.DAL.Person>? actors = null,
        string? description = null,
        byte[]? rowVersion = null)
    {
        return new MovieDetailData
        {
            Id = movie.Id,
            Title = movie.Name,
            Genre = movie.Genre,
            Year = movie.ReleaseYear,
            Director = director.MapToPersonMetaDataOrNull(),
            Actors = (actors ?? Enumerable.Empty<AOKMovieLibrary.Models.DAL.Person>())
                        .Select(a => a.MapToPersonMetaData())
                        .ToList(),
            Description = description,
            Runtime = movie.DurationMinutes,
            Rating = movie.Rating,
            CreatedAtUtc = movie.CreatedAtUtc,
            UpdatedAtUtc = movie.UpdatedAtUtc,
            RowVersion = rowVersion ?? Array.Empty<byte>()
        };
    }
}
