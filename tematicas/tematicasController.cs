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
        public async Task<ActionResult<IEnumerable<TematicaDTO>>> GetAll()
        {
            var tematicas = await _tematicaService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<TematicaDTO>>(tematicas));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TematicaDTO>> Get(int id)
        {
            var tematica = await _tematicaService.GetByIdAsync(id);
            if (tematica == null)
                return NotFound();
            return Ok(_mapper.Map<TematicaDTO>(tematica));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TematicaDTO tematicaDto)
        {
            if (tematicaDto == null)
                return BadRequest("El objeto Tematica no puede ser null.");

            var tematica = _mapper.Map<Tematica>(tematicaDto);
            await _tematicaService.CreateAsync(tematica);
            return CreatedAtAction(nameof(Get), new { id = tematica.Id }, tematica);
        }
    }

}
