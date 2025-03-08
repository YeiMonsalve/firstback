using Users_Opportunities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users_Opportunities.Sevices;
using Users_Opportunities.DTO;
using AutoMapper;


[ApiController]
[Route("api/[controller]")]
public class UsersOpportunitiesController : ControllerBase
{
    private readonly IUsers_OpportunitiesServices _userOpportunityService;
    private readonly IMapper _mapper;
    public UsersOpportunitiesController(IMapper mapper, IUsers_OpportunitiesServices userOpportunityService)
    {
        _mapper = mapper;
        _userOpportunityService = userOpportunityService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsersOpportunityDTO>>> GetAll()
    {
        var userOpportunities = await _userOpportunityService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<UsersOpportunityDTO>>(userOpportunities));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<UsersOpportunityDTO>> Get(int id)
    {
        var userOpportunities = await _userOpportunityService.GetByIdAsync(id);
        if (userOpportunities == null)
        {
            return NotFound();
        }
        return Ok(userOpportunities);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUserOpportunity([FromBody] UsersOpportunityDTO usersOpportunityDTO)
    {
        await _userOpportunityService.CreateAsync(usersOpportunityDTO);
        return CreatedAtAction(nameof(Get), new { userId = usersOpportunityDTO.UserId, opportunityId = usersOpportunityDTO.OpportunityId }, usersOpportunityDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UsersOpportunityDTO usersOpportunityDTO)
    {
        var userOpportunity = await _userOpportunityService.GetByIdAsync(id);
        if (userOpportunity == null)
            return NotFound();
            userOpportunity.userId = id;
            await _userOpportunityService.UpdateAsync(id, usersOpportunityDTO);
            return NoContent();
        
    }

    
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync (int Id)
    {
        var userOpportunity = await _userOpportunityService.GetByIdAsync(Id);
        if (userOpportunity == null)
            return NotFound();
            await _userOpportunityService.DeleteAsync(Id);
       return NoContent();
    }
    
       
    
}