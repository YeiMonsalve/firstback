using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace firstback.bootcamps
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;
        private readonly IMapper _mapper;

        public BootcampController(IBootcampService BootcampService, IMapper mapper)
        {
            _bootcampService = BootcampService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BootcampInstitucionDTO>>> GetBootcamps()
        {
            var bootcamps = await _bootcampService.GetBootcampsAsync();
            return Ok(bootcamps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BootcampInstitucionDTO>> GetBootcamp(int id)
        {
            var bootcamp = await _bootcampService.GetBootcampByIdAsync(id);

            if (bootcamp == null)
            {
                return NotFound();
            }

            return Ok(bootcamp);
        }

        [HttpPost]
        public async Task<ActionResult> PostBootcamp([FromBody] BootcampDTO bootcampDTO)
        {
            int id = await _bootcampService.CreateBootcampAsync(bootcampDTO);
            return CreatedAtAction(nameof(GetBootcamp), new { id }, bootcampDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBootcamp(int id, [FromBody] BootcampDTO bootcampDTO)
        {
            var existingBootcamp = await _bootcampService.GetBootcampByIdAsync(id);
            if (existingBootcamp == null)
            {
                return NotFound();
            }

            _mapper.Map(bootcampDTO, existingBootcamp);

            await _bootcampService.UpdateBootcampAsync(id, bootcampDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBootcamp(int id)
        {
            var existingBootcamp = await _bootcampService.GetBootcampByIdAsync(id);
            if (existingBootcamp == null)
            {
                return NotFound();
            }

            await _bootcampService.DeleteBootcampAsync(id);
            return NoContent();
        }
    }
}