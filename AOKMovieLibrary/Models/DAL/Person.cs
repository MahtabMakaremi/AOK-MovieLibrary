namespace AOKMovieLibrary.Models.DAL;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateOnly? BirthDate { get; set; }
    public string Role { get; set; } = "Actor"; // z.B. Actor, Director, Producer

    public string? Email { get; set; }
    public string? Bio { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }

    public string FullName => $"{FirstName} {LastName}".Trim();
}
