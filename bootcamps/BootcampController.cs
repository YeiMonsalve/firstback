using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendProject.Data;

namespace BackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BootcampController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bootcamp>>> GetBootcamps()
        {
            return await _context.Bootcamps.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bootcamp>> GetBootcamp(int id)
        {
            var bootcamp = await _context.Bootcamps.FindAsync(id);

            if (bootcamp == null)
            {
                return NotFound();
            }

            return bootcamp;
        }

        [HttpPost]
        public async Task<ActionResult<Bootcamp>> PostBootcamp([FromBody] Bootcamp bootcamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bootcamps.Add(bootcamp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBootcamp", new { id = bootcamp.Id }, bootcamp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBootcamp(int id, [FromBody] Bootcamp bootcamp)
        {
            if (id != bootcamp.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(bootcamp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BootcampExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBootcamp(int id)
        {
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if (bootcamp == null)
            {
                return NotFound();
            }

            _context.Bootcamps.Remove(bootcamp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BootcampExists(int id)
        {
            return _context.Bootcamps.Any(e => e.Id == id);
        }
    }
}