using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace FIRSTBACK.Instituciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {
        private readonly IInstitucionService _institucionService;
        private readonly IMapper _mapper;

        public InstitucionController(IInstitucionService institucionService, IMapper mapper)
        {
            _institucionService = institucionService;
            _mapper = mapper;
        }

        // GET: api/Institucion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institucion>>> GetAll()
        {
            var Instituciones = await _institucionService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Institucion>>(Instituciones));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Institucion>> Get(int id)
        {
            var product = await _institucionService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] InstitucionDTO institucionDTO)
        {
            int id = await _institucionService.CreateAsync(institucionDTO);
            return CreatedAtAction(nameof(Get), new { id }, institucionDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] InstitucionDTO institucionDTO)
        {
            var existinginstitucion = await _institucionService.GetByIdAsync(id);
            if (existinginstitucion == null)
            {
                return NotFound();
            }
            
            _mapper.Map(institucionDTO, existinginstitucion);

            await _institucionService.UpdateAsync(id, institucionDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existinginstitucion = await _institucionService.GetByIdAsync(id);
            if (existinginstitucion == null)
                return NotFound();
            await _institucionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
