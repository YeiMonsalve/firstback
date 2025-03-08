using Users_Opportunities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users_Opportunities.Sevices;
using Users_Opportunities.DTO;


[ApiController]
[Route("api/[controller]")]
public class UsersOpportunitiesController : ControllerBase
{
    private readonly IUsers_OpportunitiesServices _userOpportunityService;

    public UsersOpportunitiesController(IUsers_OpportunitiesServices userOpportunityService)
    {
        _userOpportunityService = userOpportunityService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsersOpportunityDTO>>> GetUsersOpportunities()
    {
        var userOpportunities = await _userOpportunityService.GetAllAsync();
        
        return Ok(userOpportunities);
    }

    [HttpPost]
    public async Task<ActionResult<UsersOpportunityDTO>> CreateUserOpportunity(UsersOpportunityDTO usersOpportunityDTO)
    {
        var userOpportunities = await _userOpportunityService.CreateAsync(usersOpportunityDTO);
        return CreatedAtAction(nameof(GetUsersOpportunities), new { userId = usersOpportunityDTO.UserId, opportunityId = usersOpportunityDTO.OpportunityId }, usersOpportunityDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UsersOpportunityDTO usersOpportunityDTO)
    {
        var userOpportunity = await _userOpportunityService.GetByIdAsync(id);
        if (userOpportunity == null)
        {
            return NotFound();
            userOpportunity.UserId = Id;
            await _userOpportunityService.UpdateAsync(id, usersOpportunityDTO);
            return NoContent();
        }
    }

    
    [HttpDelete]
    public async Task<IActionResult> DeleteUserOpportunity(UsersOpportunityDTO usersOpportunityDTO)
    {
       await _userOpportunityService.DeleteAsync(usersOpportunityDTO);
       return NoContent();
    }
}