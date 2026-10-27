using System;

namespace GameStore.Api.Models;

public class Games
{
    public int Id {get; set;}
    public  required string Name{get; set;}
    public required Genre Genre{get; set;}
    public DateOnly ReleaseDate{get; set;}

}
