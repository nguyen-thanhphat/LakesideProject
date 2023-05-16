using LakesideAPI.Helpers;
using LakesideAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class methodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public methodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PhuongThucThanhToans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuongThucThanhToan>>> GetPhuongThucThanhToans()
        {
            return await _context.PhuongthucThanhtoan.ToListAsync();
        }

        // GET: api/PhuongThucThanhToans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhuongThucThanhToan>> GetPhuongThucThanhToan(int id)
        {
            var phuongThucThanhToan = await _context.PhuongthucThanhtoan.FindAsync(id);

            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }

            return phuongThucThanhToan;
        }

        // PUT: api/PhuongThucThanhToans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhuongThucThanhToan(int id, PhuongThucThanhToan phuongThucThanhToan)
        {
            if (id != phuongThucThanhToan.MaPhuongThuc)
            {
                return BadRequest();
            }

            _context.Entry(phuongThucThanhToan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhuongThucThanhToanExists(id))
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

        // POST: api/PhuongThucThanhToans
        [HttpPost]
        public async Task<ActionResult<PhuongThucThanhToan>> PostPhuongThucThanhToan(PhuongThucThanhToan phuongThucThanhToan)
        {
            _context.PhuongthucThanhtoan.Add(phuongThucThanhToan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhuongThucThanhToan), new { id = phuongThucThanhToan.MaPhuongThuc }, phuongThucThanhToan);
        }

        // DELETE: api/PhuongThucThanhToans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhuongThucThanhToan>> DeletePhuongThucThanhToan(int id)
        {
            var phuongThucThanhToan = await _context.PhuongthucThanhtoan.FindAsync(id);
            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }

            _context.PhuongthucThanhtoan.Remove(phuongThucThanhToan);
            await _context.SaveChangesAsync();

            return phuongThucThanhToan;
        }

        private bool PhuongThucThanhToanExists(int id)
        {
            return _context.PhuongthucThanhtoan.Any(e => e.MaPhuongThuc == id);
        }
    }
}
