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
    public class MinistryAlbumsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MinistryAlbumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MinistryAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MinistryAlbum>>> GetMinistryAlbums()
        {
            return await _context.MinistryAlbums.ToListAsync();
        }

		[HttpGet]
        [Route("ByMinistryId/{id}")]
		public async Task<ActionResult<IEnumerable<MinistryAlbum>>> GetMinistryAlbumsByMinistryId(int id)
		{
			return await _context.MinistryAlbums.Where(m => m.MinistryId == id).ToListAsync();
		}

		// GET: api/MinistryAlbums/5
		[HttpGet("{id}")]
        public async Task<ActionResult<MinistryAlbum>> GetMinistryAlbum(int id)
        {
            var ministryAlbum = await _context.MinistryAlbums.FindAsync(id);

            if (ministryAlbum == null)
            {
                return NotFound();
            }

            return ministryAlbum;
        }

        // PUT: api/MinistryAlbums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinistryAlbum(int id, MinistryAlbum ministryAlbum)
        {
            if (id != ministryAlbum.MinistryAlbumId)
            {
                return BadRequest();
            }

            _context.Entry(ministryAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinistryAlbumExists(id))
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

        // POST: api/MinistryAlbums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MinistryAlbum>> PostMinistryAlbum(MinistryAlbum ministryAlbum)
        {
            _context.MinistryAlbums.Add(ministryAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinistryAlbum", new { id = ministryAlbum.MinistryAlbumId }, ministryAlbum);
        }

        // DELETE: api/MinistryAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinistryAlbum(int id)
        {
            var ministryAlbum = await _context.MinistryAlbums.FindAsync(id);
            if (ministryAlbum == null)
            {
                return NotFound();
            }

            _context.MinistryAlbums.Remove(ministryAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MinistryAlbumExists(int id)
        {
            return _context.MinistryAlbums.Any(e => e.MinistryAlbumId == id);
        }
    }
}
