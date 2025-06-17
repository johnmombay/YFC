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
    public class CommunityAlbumsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunityAlbumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunityAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityAlbum>>> GetCommunityAlbums()
        {
            return await _context.CommunityAlbums.ToListAsync();
        }

		[HttpGet]
        [Route("ByCommunityId/{id}")]
		public async Task<ActionResult<IEnumerable<CommunityAlbum>>> GetCommunityAlbumsByCommunityId(int id)
		{
			return await _context.CommunityAlbums.Where(c=> c.CommunityId == id).ToListAsync();
		}

		// GET: api/CommunityAlbums/5
		[HttpGet("{id}")]
        public async Task<ActionResult<CommunityAlbum>> GetCommunityAlbum(int id)
        {
            var communityAlbum = await _context.CommunityAlbums.FindAsync(id);

            if (communityAlbum == null)
            {
                return NotFound();
            }

            return communityAlbum;
        }

        // PUT: api/CommunityAlbums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityAlbum(int id, CommunityAlbum communityAlbum)
        {
            if (id != communityAlbum.CommunityAlbumId)
            {
                return BadRequest();
            }

            _context.Entry(communityAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityAlbumExists(id))
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

        // POST: api/CommunityAlbums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityAlbum>> PostCommunityAlbum(CommunityAlbum communityAlbum)
        {
            _context.CommunityAlbums.Add(communityAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunityAlbum", new { id = communityAlbum.CommunityAlbumId }, communityAlbum);
        }

        // DELETE: api/CommunityAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityAlbum(int id)
        {
            var communityAlbum = await _context.CommunityAlbums.FindAsync(id);
            if (communityAlbum == null)
            {
                return NotFound();
            }

            _context.CommunityAlbums.Remove(communityAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityAlbumExists(int id)
        {
            return _context.CommunityAlbums.Any(e => e.CommunityAlbumId == id);
        }
    }
}
