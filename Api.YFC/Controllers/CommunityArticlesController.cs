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
    public class CommunityArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunityArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommunityArticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommunityArticle>>> GetCommunityArticles()
        {
            return await _context.CommunityArticles.ToListAsync();
        }

        // GET: api/CommunityArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommunityArticle>> GetCommunityArticle(int id)
        {
            var communityArticle = await _context.CommunityArticles.FindAsync(id);

            if (communityArticle == null)
            {
                return NotFound();
            }

            return communityArticle;
        }

        // PUT: api/CommunityArticles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunityArticle(int id, CommunityArticle communityArticle)
        {
            if (id != communityArticle.CommunityArticleId)
            {
                return BadRequest();
            }

            _context.Entry(communityArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityArticleExists(id))
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

        // POST: api/CommunityArticles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommunityArticle>> PostCommunityArticle(CommunityArticle communityArticle)
        {
            _context.CommunityArticles.Add(communityArticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommunityArticle", new { id = communityArticle.CommunityArticleId }, communityArticle);
        }

        // DELETE: api/CommunityArticles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunityArticle(int id)
        {
            var communityArticle = await _context.CommunityArticles.FindAsync(id);
            if (communityArticle == null)
            {
                return NotFound();
            }

            _context.CommunityArticles.Remove(communityArticle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommunityArticleExists(int id)
        {
            return _context.CommunityArticles.Any(e => e.CommunityArticleId == id);
        }
    }
}
