using Mission10API.Models;

public interface IBowlerRepository
{
    //Task<IEnumerable<Bowler>> GetAllBowlersAsync(); // Get all bowlers from the database
    Task<IEnumerable<Bowler>> GetBowlersByTeamsAsync(string[] teamNames); // Get all bowlers from the specified teams
}
