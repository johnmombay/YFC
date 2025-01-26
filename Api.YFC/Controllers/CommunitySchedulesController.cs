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
    public class CommunitySchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunitySchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunitySchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunitySchedule>>> GetCommunitySchedules()
        {
            return await _context.CommunitySchedules.ToListAsync();
        }

		[HttpGet]
        [Route("GetCommunitySchedulesByCommunityId/{id}")]
		public async Task<ActionResult<IEnumerable<CommunitySchedule>>> GetCommunitySchedulesByCommunityId(int id)
		{
			return await _context.CommunitySchedules.Where(c=>c.CommunityId == id).ToListAsync();
		}

		// GET: api/CommunitySchedules/5
		[HttpGet("{id}")]
        public async Task<ActionResult<CommunitySchedule>> GetCommunitySchedule(int id)
        {
            var communitySchedule = await _context.CommunitySchedules.FindAsync(id);

            if (communitySchedule == null)
            {
                return NotFound();
            }

            return communitySchedule;
        }

        // PUT: api/CommunitySchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunitySchedule(int id, CommunitySchedule communitySchedule)
        {
            if (id != communitySchedule.CommunityScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(communitySchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityScheduleExists(id))
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

        // POST: api/CommunitySchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunitySchedule>> PostCommunitySchedule(CommunitySchedule communitySchedule)
        {
            _context.CommunitySchedules.Add(communitySchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunitySchedule", new { id = communitySchedule.CommunityScheduleId }, communitySchedule);
        }

        // DELETE: api/CommunitySchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunitySchedule(int id)
        {
            var communitySchedule = await _context.CommunitySchedules.FindAsync(id);
            if (communitySchedule == null)
            {
                return NotFound();
            }

            _context.CommunitySchedules.Remove(communitySchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityScheduleExists(int id)
        {
            return _context.CommunitySchedules.Any(e => e.CommunityScheduleId == id);
        }
    }
}
