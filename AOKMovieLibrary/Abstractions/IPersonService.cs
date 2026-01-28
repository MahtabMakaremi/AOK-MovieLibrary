namespace AOKMovieLibrary.Abstractions;

public interface IPersonService
{
    Task<IReadOnlyList<Person>> GetAllAsync(CancellationToken ct = default);
    Task<Person?> GetByIdAsync(Guid id, CancellationToken ct = default);

    Task<Person> CreateAsync(Person person, CancellationToken ct = default);
    Task<bool> UpdateAsync(Person person, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
}
