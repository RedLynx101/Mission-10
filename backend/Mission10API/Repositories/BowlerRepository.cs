using Microsoft.EntityFrameworkCore;
using Mission10API.Models;

public class BowlerRepository : IBowlerRepository
{
    private readonly BowlingLeagueContext _context; // The database context

    public BowlerRepository(BowlingLeagueContext context)
    {
        _context = context; // Set the context, adds the database to the repository
    }

    //public async Task<IEnumerable<Bowler>> GetAllBowlersAsync()
    //{
    //    return await _context.Bowlers.ToListAsync(); // Return all bowlers from the database
    //}

    // Get all bowlers from the specified teams
    public async Task<IEnumerable<Bowler>> GetBowlersByTeamsAsync(string[] teamNames)
    {
        // Project the query results to include TeamName directly
        var bowlers = await _context.Bowlers
                                    .Where(b => b.Team != null && teamNames.Contains(b.Team.TeamName))
                                    .Select(b => new Bowler
                                    {
                                        BowlerId = b.BowlerId,
                                        BowlerLastName = b.BowlerLastName,
                                        BowlerFirstName = b.BowlerFirstName,
                                        BowlerMiddleInit = b.BowlerMiddleInit,
                                        BowlerAddress = b.BowlerAddress,
                                        BowlerCity = b.BowlerCity,
                                        BowlerState = b.BowlerState,
                                        BowlerZip = b.BowlerZip,
                                        BowlerPhoneNumber = b.BowlerPhoneNumber,
                                        TeamId = b.TeamId,
                                        // Include other needed properties here
                                        TeamName = b.Team.TeamName // Set TeamName directly from the Team entity
                                    })
                                    .ToListAsync();
        return bowlers;
    }
}
