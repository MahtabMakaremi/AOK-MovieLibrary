namespace AOKMovieLibrary.Models.DAL;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string? Email { get; set; }

    // z.B. "Actor", "Director"
    public string? Role { get; set; }

    public string FullName => $"{FirstName} {LastName}".Trim();
}