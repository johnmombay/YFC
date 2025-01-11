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
    public class MinistriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MinistriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ministries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ministry>>> GetMinistries()
        {
            return await _context.Ministries.ToListAsync();
        }

        // GET: api/Ministries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ministry>> GetMinistry(int id)
        {
            var ministry = await _context.Ministries.FindAsync(id);

            if (ministry == null)
            {
                return NotFound();
            }

            return ministry;
        }

        // PUT: api/Ministries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinistry(int id, Ministry ministry)
        {
            if (id != ministry.MinistryId)
            {
                return BadRequest();
            }

            _context.Entry(ministry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinistryExists(id))
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

        // POST: api/Ministries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ministry>> PostMinistry(Ministry ministry)
        {
            _context.Ministries.Add(ministry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinistry", new { id = ministry.MinistryId }, ministry);
        }

        // DELETE: api/Ministries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinistry(int id)
        {
            var ministry = await _context.Ministries.FindAsync(id);
            if (ministry == null)
            {
                return NotFound();
            }

            _context.Ministries.Remove(ministry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MinistryExists(int id)
        {
            return _context.Ministries.Any(e => e.MinistryId == id);
        }
    }
}
