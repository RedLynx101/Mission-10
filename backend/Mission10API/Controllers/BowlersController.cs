using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mission10API.Models;
using System.Threading.Tasks;

[Route("api/")]
[ApiController]
public class BowlersController : ControllerBase
{
    private readonly IBowlerRepository _bowlerRepository;

    public BowlersController(IBowlerRepository bowlerRepository)
    {
        _bowlerRepository = bowlerRepository;
    }

    //GET: api/Bowlers
   [HttpGet("Bowlers")]
    public async Task<ActionResult<IEnumerable<Bowler>>> GetBowlers()
    {
        var bowlers = await _bowlerRepository.GetBowlersByTeamsAsync(new string[] { "Marlins", "Sharks" });
        return Ok(bowlers);
    }

    // GET: api/AllBowlers
    //[HttpGet("AllBowlers")]
    //public async Task<ActionResult<IEnumerable<Bowler>>> GetAllBowlers()
    //{
    //    var bowlers = await _bowlerRepository.GetAllBowlersAsync();
    //    return Ok(bowlers);
    //}
}
