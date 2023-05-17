using LakesideAPI.Helpers;
using LakesideAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class feedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public feedbackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<IEnumerable<PhanHoi>>> GetListPhanHoi()
        {
            return await _context.PhanHoi.ToListAsync();
        }

        // GET: api/PhanHoi/5
        [HttpGet("getby/{id}")]
        public async Task<ActionResult<PhanHoi>> GetPhanHoi(int id)
        {
            var phanHoi = await _context.PhanHoi.FindAsync(id);

            if (phanHoi == null)
            {
                return NotFound();
            }

            return phanHoi;
        }

        // PUT: api/PhanHoi/5
        [HttpPut("editby/{id}")]
        public async Task<IActionResult> PutPhanHoi(int id, PhanHoi phanHoi)
        {
            if (id != phanHoi.MaPhanHoi)
            {
                return BadRequest();
            }

            _context.Entry(phanHoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhanHoiExists(id))
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

        // POST: api/ThongTin
        [HttpPost("create")]
        public async Task<ActionResult<PhanHoi>> PostPhanHoi(PhanHoi phanHoi)
        {
            _context.PhanHoi.Add(phanHoi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhanHoi), new { id = phanHoi.MaPhanHoi }, phanHoi);
        }

        // DELETE: api/ThongTin/5
        [HttpDelete("delby/{id}")]
        public async Task<ActionResult<PhanHoi>> DeletePhanHoi(int id)
        {
            var phanHoi = await _context.PhanHoi.FindAsync(id);
            if (phanHoi == null)
            {
                return NotFound();
            }

            _context.PhanHoi.Remove(phanHoi);
            await _context.SaveChangesAsync();

            return phanHoi;
        }

        private bool PhanHoiExists(int id)
        {
            return _context.PhanHoi.Any(e => e.MaPhanHoi == id);
        }
    }
}
