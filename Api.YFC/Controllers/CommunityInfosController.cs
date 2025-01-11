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
    public class CommunityInfosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunityInfosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunityInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityInfo>>> GetCommunitiesInfos()
        {
            return await _context.CommunitiesInfos.ToListAsync();
        }

        // GET: api/CommunityInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityInfo>> GetCommunityInfo(int id)
        {
            var communityInfo = await _context.CommunitiesInfos.FindAsync(id);

            if (communityInfo == null)
            {
                return NotFound();
            }

            return communityInfo;
        }

		[HttpGet]
        [Route("GetCommunityInfoByCommunityId/{id}")]
		public async Task<ActionResult<CommunityInfo>> GetCommunityInfoByCommunityId(int id)
		{
			var communityInfo = await _context.CommunitiesInfos.Where(c => c.CommunityId == id).FirstOrDefaultAsync();

			if (communityInfo == null)
			{
				return NotFound();
			}

			return communityInfo;
		}

		// PUT: api/CommunityInfoes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityInfo(int id, CommunityInfo communityInfo)
        {
            if (id != communityInfo.CommunityInfoId)
            {
                return BadRequest();
            }

            _context.Entry(communityInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityInfoExists(id))
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

        // POST: api/CommunityInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityInfo>> PostCommunityInfo(CommunityInfo communityInfo)
        {
            _context.CommunitiesInfos.Add(communityInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunityInfo", new { id = communityInfo.CommunityInfoId }, communityInfo);
        }

        // DELETE: api/CommunityInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityInfo(int id)
        {
            var communityInfo = await _context.CommunitiesInfos.FindAsync(id);
            if (communityInfo == null)
            {
                return NotFound();
            }

            _context.CommunitiesInfos.Remove(communityInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityInfoExists(int id)
        {
            return _context.CommunitiesInfos.Any(e => e.CommunityInfoId == id);
        }
    }
}
