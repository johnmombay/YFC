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
    public class PastorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PastorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pastors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pastor>>> GetPastors()
        {
            return await _context.Pastors.ToListAsync();
        }

        // GET: api/Pastors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pastor>> GetPastor(int id)
        {
            var pastor = await _context.Pastors.FindAsync(id);

            if (pastor == null)
            {
                return NotFound();
            }

            return pastor;
        }

        // PUT: api/Pastors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastor(int id, Pastor pastor)
        {
            if (id != pastor.PastorId)
            {
                return BadRequest();
            }

            _context.Entry(pastor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastorExists(id))
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

        // POST: api/Pastors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pastor>> PostPastor(Pastor pastor)
        {
            _context.Pastors.Add(pastor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastor", new { id = pastor.PastorId }, pastor);
        }

        // DELETE: api/Pastors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastor(int id)
        {
            var pastor = await _context.Pastors.FindAsync(id);
            if (pastor == null)
            {
                return NotFound();
            }

            _context.Pastors.Remove(pastor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastorExists(int id)
        {
            return _context.Pastors.Any(e => e.PastorId == id);
        }
    }
}
