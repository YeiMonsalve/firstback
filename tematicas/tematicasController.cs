using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace FIRSTBACK.Tematicas
{
    [Route("api/[controller]")]
    [ApiController]
    public class TematicaController : ControllerBase
    {
        private readonly ITematicaService _tematicaService;
        private readonly IMapper _mapper;

        public TematicaController(ITematicaService tematicaService, IMapper mapper)
        {
            _tematicaService = tematicaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tematica>>> GetAll()
        {
            var tematicas = await _tematicaService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Tematica>>(tematicas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tematica>> Get(int id)
        {
            var tematica = await _tematicaService.GetByIdAsync(id);
            if (tematica == null)
                return NotFound();
            return Ok(_mapper.Map<Tematica>(tematica));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TematicaDTO tematicaDto)
        {
            int id = await _tematicaService.CreateAsync(tematicaDto);
            return CreatedAtAction(nameof(Get), new { id }, tematicaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TematicaDTO tematicaDto)
        {
            var existingTematica = await _tematicaService.GetByIdAsync(id);
            if (existingTematica == null)
                return NotFound();
            _mapper.Map(tematicaDto, existingTematica);
            await _tematicaService.UpdateAsync(id, tematicaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var tematica = await _tematicaService.GetByIdAsync(id);
            if (tematica == null)
                return NotFound();
            await _tematicaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
