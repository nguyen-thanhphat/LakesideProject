using LakesideAPI.Helpers;
using LakesideAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class introduceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public introduceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GioiThieu>>> GetListGioiThieu()
        {
            return await _context.GioiThieu.ToListAsync();
        }

        // GET: api/GioiThieu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GioiThieu>> GetGioiThieu(int id)
        {
            var gioiThieu = await _context.GioiThieu.FindAsync(id);

            if (gioiThieu == null)
            {
                return NotFound();
            }

            return gioiThieu;
        }

        // PUT: api/GioiThieu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGioiThieu(int id, GioiThieu gioiThieu)
        {
            if (id != gioiThieu.MaGioiThieu)
            {
                return BadRequest();
            }

            _context.Entry(gioiThieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GioiThieuExists(id))
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

        // POST: api/GioiThieu
        [HttpPost]
        public async Task<ActionResult<GioiThieu>> PostGioiThieu(GioiThieu gioiThieu)
        {
            _context.GioiThieu.Add(gioiThieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGioiThieu), new { id = gioiThieu.MaGioiThieu }, gioiThieu);
        }

        // DELETE: api/GioiThieu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GioiThieu>> DeleteGioiThieu(int id)
        {
            var gioiThieu = await _context.GioiThieu.FindAsync(id);
            if (gioiThieu == null)
            {
                return NotFound();
            }

            _context.GioiThieu.Remove(gioiThieu);
            await _context.SaveChangesAsync();

            return gioiThieu;
        }

        private bool GioiThieuExists(int id)
        {
            return _context.GioiThieu.Any(e => e.MaGioiThieu == id);
        }
    }
}
