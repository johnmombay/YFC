using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.YFC.Data;
using Api.YFC.Models;

namespace Api.YFC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspirationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InspirationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Inspirations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspiration>>> GetInspirations()
        {
            return await _context.Inspirations.ToListAsync();
        }

        // GET: api/Inspirations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspiration>> GetInspiration(int id)
        {
            var inspiration = await _context.Inspirations.FindAsync(id);

            if (inspiration == null)
            {
                return NotFound();
            }

            return inspiration;
        }

        // PUT: api/Inspirations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspiration(int id, Inspiration inspiration)
        {
            if (id != inspiration.InspirationId)
            {
                return BadRequest();
            }

            _context.Entry(inspiration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspirationExists(id))
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

        // POST: api/Inspirations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inspiration>> PostInspiration(Inspiration inspiration)
        {
            _context.Inspirations.Add(inspiration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspiration", new { id = inspiration.InspirationId }, inspiration);
        }

        // DELETE: api/Inspirations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspiration(int id)
        {
            var inspiration = await _context.Inspirations.FindAsync(id);
            if (inspiration == null)
            {
                return NotFound();
            }

            _context.Inspirations.Remove(inspiration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspirationExists(int id)
        {
            return _context.Inspirations.Any(e => e.InspirationId == id);
        }
    }
}
