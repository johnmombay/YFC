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
    public class CommunityEventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunityEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunityEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityEvent>>> GetCommunityEvents()
        {
            return await _context.CommunityEvents.ToListAsync();
        }

        // GET: api/CommunityEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityEvent>> GetCommunityEvent(int id)
        {
            var communityEvent = await _context.CommunityEvents.FindAsync(id);

            if (communityEvent == null)
            {
                return NotFound();
            }

            return communityEvent;
        }

        // PUT: api/CommunityEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityEvent(int id, CommunityEvent communityEvent)
        {
            if (id != communityEvent.CommunityEventId)
            {
                return BadRequest();
            }

            _context.Entry(communityEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityEventExists(id))
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

        // POST: api/CommunityEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityEvent>> PostCommunityEvent(CommunityEvent communityEvent)
        {
            _context.CommunityEvents.Add(communityEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunityEvent", new { id = communityEvent.CommunityEventId }, communityEvent);
        }

        // DELETE: api/CommunityEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityEvent(int id)
        {
            var communityEvent = await _context.CommunityEvents.FindAsync(id);
            if (communityEvent == null)
            {
                return NotFound();
            }

            _context.CommunityEvents.Remove(communityEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityEventExists(int id)
        {
            return _context.CommunityEvents.Any(e => e.CommunityEventId == id);
        }
    }
}
