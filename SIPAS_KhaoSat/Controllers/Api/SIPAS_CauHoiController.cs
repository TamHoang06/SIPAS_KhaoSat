using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIPAS_KhaoSat.Data;
using SIPAS_KhaoSat.Models;

namespace SIPAS_KhaoSat.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SIPAS_CauHoiController : ControllerBase
    {
        private readonly SipasDbContext _context;

        public SIPAS_CauHoiController(SipasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SIPAS_CauHoi>>> GetCauHois()
        {
            return await _context.CauHois.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SIPAS_CauHoi>> GetCauHoi(int id)
        {
            var cauHoi = await _context.CauHois.FindAsync(id);

            if (cauHoi == null)
            {
                return NotFound();
            }

            return cauHoi;
        }

        [HttpPost]
        public async Task<ActionResult<SIPAS_CauHoi>> PostCauHoi(SIPAS_CauHoi cauHoi)
        {
            _context.CauHois.Add(cauHoi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCauHoi), new { id = cauHoi.MaCauHoi }, cauHoi);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCauHoi(int id, SIPAS_CauHoi cauHoi)
        {
            if (id != cauHoi.MaCauHoi)
            {
                return BadRequest();
            }

            _context.Entry(cauHoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CauHois.Any(e => e.MaCauHoi == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCauHoi(int id)
        {
            var cauHoi = await _context.CauHois.FindAsync(id);
            if (cauHoi == null)
            {
                return NotFound();
            }

            _context.CauHois.Remove(cauHoi);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
