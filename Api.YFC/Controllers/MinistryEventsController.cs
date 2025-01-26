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
    public class MinistryEventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MinistryEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MinistryEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MinistryEvent>>> GetMinistryEvents()
        {
            return await _context.MinistryEvents.ToListAsync();
        }

		[HttpGet]
        [Route("GetMinistryEventsByMinistryId/{id}")]
		public async Task<ActionResult<IEnumerable<MinistryEvent>>> GetMinistryEventsByMinistryId(int id)
		{
			return await _context.MinistryEvents.Where(m=> m.MinistryId == id).ToListAsync();
		}

		// GET: api/MinistryEvents/5
		[HttpGet("{id}")]
        public async Task<ActionResult<MinistryEvent>> GetMinistryEvent(int id)
        {
            var ministryEvent = await _context.MinistryEvents.FindAsync(id);

            if (ministryEvent == null)
            {
                return NotFound();
            }

            return ministryEvent;
        }


        // PUT: api/MinistryEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinistryEvent(int id, MinistryEvent ministryEvent)
        {
            if (id != ministryEvent.MinistryEventId)
            {
                return BadRequest();
            }

            _context.Entry(ministryEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinistryEventExists(id))
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

        // POST: api/MinistryEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MinistryEvent>> PostMinistryEvent(MinistryEvent ministryEvent)
        {
            _context.MinistryEvents.Add(ministryEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinistryEvent", new { id = ministryEvent.MinistryEventId }, ministryEvent);
        }

        // DELETE: api/MinistryEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinistryEvent(int id)
        {
            var ministryEvent = await _context.MinistryEvents.FindAsync(id);
            if (ministryEvent == null)
            {
                return NotFound();
            }

            _context.MinistryEvents.Remove(ministryEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MinistryEventExists(int id)
        {
            return _context.MinistryEvents.Any(e => e.MinistryEventId == id);
        }
    }
}
