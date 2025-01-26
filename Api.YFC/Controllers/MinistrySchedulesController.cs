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
    public class MinistrySchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MinistrySchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MinistrySchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MinistrySchedule>>> GetMinistrySchedules()
        {
            return await _context.MinistrySchedules.ToListAsync();
        }

		[HttpGet]
		[Route("GetMinistrySchedulesByMinistryId/{id}")]
		public async Task<ActionResult<IEnumerable<MinistrySchedule>>> GetMinistrySchedulesByMinistryId(int id)
		{
			return await _context.MinistrySchedules.Where(m => m.MinistryId == id).ToListAsync();
		}

		// GET: api/MinistrySchedules/5
		[HttpGet("{id}")]
        public async Task<ActionResult<MinistrySchedule>> GetMinistrySchedule(int id)
        {
            var ministrySchedule = await _context.MinistrySchedules.FindAsync(id);

            if (ministrySchedule == null)
            {
                return NotFound();
            }

            return ministrySchedule;
        }

        // PUT: api/MinistrySchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinistrySchedule(int id, MinistrySchedule ministrySchedule)
        {
            if (id != ministrySchedule.MinistryScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(ministrySchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinistryScheduleExists(id))
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

        // POST: api/MinistrySchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MinistrySchedule>> PostMinistrySchedule(MinistrySchedule ministrySchedule)
        {
            _context.MinistrySchedules.Add(ministrySchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinistrySchedule", new { id = ministrySchedule.MinistryScheduleId }, ministrySchedule);
        }

        // DELETE: api/MinistrySchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinistrySchedule(int id)
        {
            var ministrySchedule = await _context.MinistrySchedules.FindAsync(id);
            if (ministrySchedule == null)
            {
                return NotFound();
            }

            _context.MinistrySchedules.Remove(ministrySchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MinistryScheduleExists(int id)
        {
            return _context.MinistrySchedules.Any(e => e.MinistryScheduleId == id);
        }
    }
}
