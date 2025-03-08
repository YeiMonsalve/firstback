using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace firstback.categorias
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _categoriasService;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriasService categoriasService, IMapper mapper)
        {
            _categoriasService = categoriasService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetAllAsync()
        {
            var categorias = await _categoriasService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Categorias>>(categorias));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categorias>> Get(int id)
        {
            var categoria = await _categoriasService.GetByIDAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoriasDTO categoriaDTO)
        {
            int id = await _categoriasService.CreateAsync(categoriaDTO);
            return CreatedAtAction(nameof(Get), new { id }, categoriaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CategoriasDTO categoriaDTO)
        {
            var existingCategoria = await _categoriasService.GetByIDAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            _mapper.Map(categoriaDTO, existingCategoria);

            await _categoriasService.UpdateAsync(id, categoriaDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingCategoria = await _categoriasService.GetByIDAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            await _categoriasService.DeleteAsync(id);
            return NoContent();
        }
    }
}