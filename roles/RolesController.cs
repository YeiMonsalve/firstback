using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace firstback.roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        private readonly IMapper _mapper;

        public RolesController(IRolesService RolesService, IMapper mapper)
        {
            _rolesService = RolesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetAllAsync()
        {
            var roles = await _rolesService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> Get(int id)
        {
            var roles = await _rolesService.GetByIDAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RolesDTO rolesDTO)
        {
            int id = await _rolesService.CreateAsync(rolesDTO);
            return CreatedAtAction(nameof(Get), new { id }, rolesDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RolesDTO rolesDTO)
        {
            var existingRoles = await _rolesService.GetByIDAsync(id);
            if (existingRoles == null)
            {
                return NotFound();
            }

            _mapper.Map(rolesDTO, existingRoles);

            await _rolesService.UpdateAsync(id, rolesDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingRoles = await _rolesService.GetByIDAsync(id);
            if (existingRoles == null)
            {
                return NotFound();
            }

            await _rolesService.DeleteAsync(id);
            return NoContent();
        }
    }
}