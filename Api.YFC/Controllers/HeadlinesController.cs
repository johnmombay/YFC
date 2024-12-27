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
    public class HeadlinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HeadlinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Headlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Headline>>> GetHeadlines()
        {
            return await _context.Headlines.ToListAsync();
        }

        // GET: api/Headlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Headline>> GetHeadline(int id)
        {
            var headline = await _context.Headlines.FindAsync(id);

            if (headline == null)
            {
                return NotFound();
            }

            return headline;
        }

        // PUT: api/Headlines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeadline(int id, Headline headline)
        {
            if (id != headline.HeadlineId)
            {
                return BadRequest();
            }

            _context.Entry(headline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadlineExists(id))
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

        // POST: api/Headlines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Headline>> PostHeadline(Headline headline)
        {
            _context.Headlines.Add(headline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeadline", new { id = headline.HeadlineId }, headline);
        }

        // DELETE: api/Headlines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeadline(int id)
        {
            var headline = await _context.Headlines.FindAsync(id);
            if (headline == null)
            {
                return NotFound();
            }

            _context.Headlines.Remove(headline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeadlineExists(int id)
        {
            return _context.Headlines.Any(e => e.HeadlineId == id);
        }
    }
}
