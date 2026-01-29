namespace AOKMovieLibrary.Implementations;

public class PersonService : IPersonService
{
    private readonly List<Person> _persons = new();
    private readonly object _gate = new();

    public Task<IReadOnlyList<Person>> GetAllAsync(CancellationToken ct = default)
    {
        lock (_gate)
        {
            return Task.FromResult((IReadOnlyList<Person>)_persons
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList()
                .AsReadOnly());
        }
    }

    public Task<Person?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        lock (_gate)
        {
            return Task.FromResult(_persons.FirstOrDefault(p => p.Id == id));
        }
    }

    public Task<Person> CreateAsync(Person person, CancellationToken ct = default)
    {
        if (person is null) throw new ArgumentNullException(nameof(person));

        lock (_gate)
        {
            if (person.Id == Guid.Empty)
                person.Id = Guid.NewGuid();

            _persons.Add(person);
            return Task.FromResult(person);
        }
    }

    public Task<bool> UpdateAsync(Person person, CancellationToken ct = default)
    {
        

            return Task.FromResult(true);
        
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
       
            return Task.FromResult(true);
        
    }
}
