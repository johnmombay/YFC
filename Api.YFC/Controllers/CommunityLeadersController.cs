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
    public class CommunityLeadersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunityLeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunityLeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityLeader>>> GetCommunityLeaders()
        {
            return await _context.CommunityLeaders.ToListAsync();
        }

        // GET: api/CommunityLeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityLeader>> GetCommunityLeader(int id)
        {
            var communityLeader = await _context.CommunityLeaders.FindAsync(id);

            if (communityLeader == null)
            {
                return NotFound();
            }

            return communityLeader;
        }

        // PUT: api/CommunityLeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityLeader(int id, CommunityLeader communityLeader)
        {
            if (id != communityLeader.CommunityLeaderId)
            {
                return BadRequest();
            }

            _context.Entry(communityLeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityLeaderExists(id))
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

        // POST: api/CommunityLeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityLeader>> PostCommunityLeader(CommunityLeader communityLeader)
        {
            _context.CommunityLeaders.Add(communityLeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunityLeader", new { id = communityLeader.CommunityLeaderId }, communityLeader);
        }

        // DELETE: api/CommunityLeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityLeader(int id)
        {
            var communityLeader = await _context.CommunityLeaders.FindAsync(id);
            if (communityLeader == null)
            {
                return NotFound();
            }

            _context.CommunityLeaders.Remove(communityLeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityLeaderExists(int id)
        {
            return _context.CommunityLeaders.Any(e => e.CommunityLeaderId == id);
        }
    }
}
