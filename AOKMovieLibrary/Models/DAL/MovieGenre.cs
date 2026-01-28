using System;

namespace AOKMovieLibrary.Models.DAL
{
    [Flags]
    public enum MovieGenre
    {
        None = 0,
        Action = 1 << 0,
        Comedy = 1 << 1,
        Drama = 1 << 2,
        Fantasy = 1 << 3,
        Horror = 1 << 4,
        Mystery = 1 << 5,
        Romance = 1 << 6,
        Thriller = 1 << 7,
        SciFi = 1 << 8,
        Documentary = 1 << 9,
        Animation = 1 << 10,
        Adventure = 1 << 11,
        Musical = 1 << 12,
        Biography = 1 << 13,
        Crime = 1 << 14,
        Family = 1 << 15,
        History = 1 << 16,
        War = 1 << 17,
        Western = 1 << 18,
        Sport = 1 << 19,
        Music = 1 << 20,
    }
}
