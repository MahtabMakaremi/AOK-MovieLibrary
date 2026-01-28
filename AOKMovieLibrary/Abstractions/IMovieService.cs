namespace AOKMovieLibrary.Abstractions;

public interface IMovieService
{

    Task<IReadOnlyList<MovieOverviewData>> GetAllOverviewAsync(CancellationToken ct = default);
    Task<MovieDetailData?> GetByIdAsync(Guid id, CancellationToken ct = default);

    Task<MovieDetailData> CreateAsync(CreateMovieCommand command, CancellationToken ct = default);
    Task<bool> UpdateAsync(Guid id, UpdateMovieCommand command, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
}
