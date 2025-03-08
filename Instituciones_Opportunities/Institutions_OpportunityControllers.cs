using Institutions_Opportunity.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FIRSTBACK.Institutions_Opportunity.Services;
using Institutions_Opportunity.Models;

namespace Institutions_Opportunity.Controllers
{
[ApiController]
[Route("Api/[Controller]")]

public class InstitutionsOpportunityController : ControllerBase
{

    private readonly IMapper _mapper;
    private readonly IInstitutions_OpportunityService _institutions_OpportunityService;
    public InstitutionsOpportunityController(IMapper mapper, IInstitutions_OpportunityService institutions_OpportunityService)
    {
        _mapper = mapper;
        _institutions_OpportunityService = institutions_OpportunityService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<InstitutionOpportunityDTO>>> GetAll()
    {
        var institutionsOpportunity = await _institutions_OpportunityService.getAllAsync();
        return Ok(_mapper.Map<IEnumerable<InstitutionOpportunityDTO>>(institutionsOpportunity));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InstitutionOpportunity>> get(int id)
    {
        var institutionsOpportunity = await _institutions_OpportunityService.getByIdAsync(id);
        if (institutionsOpportunity == null)
            return NotFound();
        return Ok(institutionsOpportunity);
    }

    [HttpPost]
    public async Task<ActionResult> createInstitutionOpportunity([FromBody] InstitutionOpportunity institutionOpportunity)
    {
        await _institutions_OpportunityService.createAsync(institutionOpportunity);
        return CreatedAtAction(nameof(get), new { id = institutionOpportunity.institutionId, opportunityId = institutionOpportunity.opportunityId }, institutionOpportunity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateAsync(int id, [FromBody] InstitutionOpportunity institutionOpportunity)
    {
        var institutionsOpportunity = await _institutions_OpportunityService.getByIdAsync(id);
        if (institutionsOpportunity == null)
            return NotFound();
            institutionOpportunity.institutionId = id;
            await _institutions_OpportunityService.updateAsync(id, institutionOpportunity);
            return NoContent();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> deleteAsync(int id)
    {
        var institutionsOpportunity = await _institutions_OpportunityService.getByIdAsync(id);
        if (institutionsOpportunity == null)
            return NotFound();
            await _institutions_OpportunityService.deleteAsync(id);
            return NoContent();
    }

}

}