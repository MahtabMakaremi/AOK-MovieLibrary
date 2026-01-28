namespace AOKMovieLibrary.Implementations;

public class MovieService : IMovieService
{
    private readonly List<AOKMovieLibrary.Models.DAL.Movie> _movies = new();
    private readonly object _gate = new();

    public MovieService()
    {
        Seed();
    }

    private void Seed()
    {
        lock (_gate)
        {
            if (_movies.Count > 0) return;

            _movies.AddRange(new[]
            {
                new AOKMovieLibrary.Models.DAL.Movie
                {
                    Id = Guid.NewGuid(),
                    Name = " The Godfather",
                    PosterFileName="Godfather.jpg",
                    Genre = AOKMovieLibrary.Models.DAL.MovieGenre.Action | AOKMovieLibrary.Models.DAL.MovieGenre.Drama | AOKMovieLibrary.Models.DAL.MovieGenre.Crime,
                    ReleaseYear = 2010,
                    DurationMinutes = 148,
                    Rating = 8.8m,
                    CreatedAtUtc = DateTime.UtcNow
                },
                new AOKMovieLibrary.Models.DAL.Movie
                {
                    Id = Guid.NewGuid(),
                    Name = "The Matrix",
                    PosterFileName="matrix.jpg",
                    Genre = AOKMovieLibrary.Models.DAL.MovieGenre.Action | AOKMovieLibrary.Models.DAL.MovieGenre.SciFi,
                    ReleaseYear = 1999,
                    DurationMinutes = 136,
                    Rating = 8.7m,
                    CreatedAtUtc = DateTime.UtcNow
                }
            });
        }
    }

    public Task<IReadOnlyList<MovieOverviewData>> GetAllOverviewAsync(CancellationToken ct = default)
    {
        lock (_gate)
        {
            var list = _movies
                .OrderBy(m => m.Name)
                .Select(m => m.MapToMovieOverviewData())
                .ToList()
                .AsReadOnly();

            return Task.FromResult((IReadOnlyList<MovieOverviewData>)list);
        }
    }

    public Task<MovieDetailData?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(movie?.MapToMovieDetailData());
        }
    }

    public Task<MovieDetailData> CreateAsync(CreateMovieCommand command, CancellationToken ct = default)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var movie = new AOKMovieLibrary.Models.DAL.Movie
        {
            Id = Guid.NewGuid(),
            Name = command.Title?.Trim() ?? string.Empty,
            Genre = command.Genre,
            ReleaseYear = command.Year,
            DurationMinutes = command.Runtime,
            Rating = command.Rating,
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = null
        };

        if (string.IsNullOrWhiteSpace(movie.Name))
            throw new ArgumentException("Title ist erforderlich.", nameof(command));

        lock (_gate)
        {
            _movies.Add(movie); // ✅ FIX: _movies statt movies
            return Task.FromResult(movie.MapToMovieDetailData());
        }
    }

    public Task<bool> UpdateAsync(Guid id, UpdateMovieCommand command, CancellationToken ct = default)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));
        if (id == Guid.Empty) throw new ArgumentException("Id ist erforderlich.", nameof(id));

        lock (_gate)
        {
            var existing = _movies.FirstOrDefault(m => m.Id == id);
            if (existing is null) return Task.FromResult(false);

            existing.Name = command.Title?.Trim() ?? existing.Name;
            existing.Genre = command.Genre;
            existing.ReleaseYear = command.Year;
            existing.DurationMinutes = command.Runtime;  
            existing.Rating = command.Rating;
            existing.UpdatedAtUtc = DateTime.UtcNow;

            return Task.FromResult(true);
        }
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        lock (_gate)
        {
            var existing = _movies.FirstOrDefault(m => m.Id == id);
            if (existing is null) return Task.FromResult(false);

            _movies.Remove(existing);
            return Task.FromResult(true);
        }
    }
}
