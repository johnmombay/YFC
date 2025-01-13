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
    public class MinistryLeadersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MinistryLeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MinistryLeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MinistryLeader>>> GetMinistryLeaders()
        {
            return await _context.MinistryLeaders.ToListAsync();
        }

        // GET: api/MinistryLeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MinistryLeader>> GetMinistryLeader(int id)
        {
            var ministryLeader = await _context.MinistryLeaders.FindAsync(id);

            if (ministryLeader == null)
            {
                return NotFound();
            }

            return ministryLeader;
        }

        // PUT: api/MinistryLeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinistryLeader(int id, MinistryLeader ministryLeader)
        {
            if (id != ministryLeader.MinistryLeaderId)
            {
                return BadRequest();
            }

            _context.Entry(ministryLeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinistryLeaderExists(id))
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

        // POST: api/MinistryLeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MinistryLeader>> PostMinistryLeader(MinistryLeader ministryLeader)
        {
            _context.MinistryLeaders.Add(ministryLeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinistryLeader", new { id = ministryLeader.MinistryLeaderId }, ministryLeader);
        }

        // DELETE: api/MinistryLeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinistryLeader(int id)
        {
            var ministryLeader = await _context.MinistryLeaders.FindAsync(id);
            if (ministryLeader == null)
            {
                return NotFound();
            }

            _context.MinistryLeaders.Remove(ministryLeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MinistryLeaderExists(int id)
        {
            return _context.MinistryLeaders.Any(e => e.MinistryLeaderId == id);
        }
    }
}
