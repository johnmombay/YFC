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
    public class ChurchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChurchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Churches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Church>>> GetChurches()
        {
            return await _context.Churches.ToListAsync();
        }

        // GET: api/Churches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Church>> GetChurch(int id)
        {
            var church = await _context.Churches.FindAsync(id);

            if (church == null)
            {
                return NotFound();
            }

            return church;
        }

        // PUT: api/Churches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChurch(int id, Church church)
        {
            if (id != church.ChurchId)
            {
                return BadRequest();
            }

            _context.Entry(church).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChurchExists(id))
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

        // POST: api/Churches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Church>> PostChurch(Church church)
        {
            _context.Churches.Add(church);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChurch", new { id = church.ChurchId }, church);
        }

        // DELETE: api/Churches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChurch(int id)
        {
            var church = await _context.Churches.FindAsync(id);
            if (church == null)
            {
                return NotFound();
            }

            _context.Churches.Remove(church);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChurchExists(int id)
        {
            return _context.Churches.Any(e => e.ChurchId == id);
        }
    }
}
