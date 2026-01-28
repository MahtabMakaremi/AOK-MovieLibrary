using System;


namespace AOKMovieLibrary.Models.Responses;

public record PersonMetaData
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Role { get; set; }
}

public static class PersonMetaDataMapping
{
    public static PersonMetaData MapToPersonMetaData(this AOKMovieLibrary.Models.DAL.Person person)
    {
        return new PersonMetaData
        {
            Id = person.Id,
            FullName = person.FullName,
            Email = person.Email,
            Role = person.Role
        };
    }

    public static PersonMetaData? MapToPersonMetaDataOrNull(this AOKMovieLibrary.Models.DAL.Person? person)
        => person is null ? null : person.MapToPersonMetaData();
}