using LakesideAPI.Helpers;
using LakesideAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class infoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public infoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThongTin>>> GetListThongTin()
        {
            return await _context.ThongTin.ToListAsync();
        }

        // GET: api/ThongTin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThongTin>> GetThongTin(int id)
        {
            var thongTin = await _context.ThongTin.FindAsync(id);

            if (thongTin == null)
            {
                return NotFound();
            }

            return thongTin;
        }

        // PUT: api/ThongTin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThongTin(int id, ThongTin thongTin)
        {
            if (id != thongTin.MaThongTin)
            {
                return BadRequest();
            }

            _context.Entry(thongTin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThongTinExists(id))
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
        [HttpPost]
        public async Task<ActionResult<ThongTin>> PostThongTin(ThongTin thongTin)
        {
            _context.ThongTin.Add(thongTin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetThongTin), new { id = thongTin.MaThongTin }, thongTin);
        }

        // DELETE: api/ThongTin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThongTin>> DeleteThongTin(int id)
        {
            var thongTin = await _context.ThongTin.FindAsync(id);
            if (thongTin == null)
            {
                return NotFound();
            }

            _context.ThongTin.Remove(thongTin);
            await _context.SaveChangesAsync();

            return thongTin;
        }

        private bool ThongTinExists(int id)
        {
            return _context.ThongTin.Any(e => e.MaThongTin == id);
        }
    }
}
