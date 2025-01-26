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
    public class MinistryArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MinistryArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MinistryArticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MinistryArticle>>> GetMinistryArticles()
        {
            return await _context.MinistryArticles.ToListAsync();
        }

		[HttpGet]
        [Route("GetMinistryArticlesByMinistryId/{id}")]
		public async Task<ActionResult<IEnumerable<MinistryArticle>>> GetMinistryArticlesByMinistryId(int id)
		{
			return await _context.MinistryArticles.Where(m => m.MinistryId == id).ToListAsync();
		}

		// GET: api/MinistryArticles/5
		[HttpGet("{id}")]
        public async Task<ActionResult<MinistryArticle>> GetMinistryArticle(int id)
        {
            var ministryArticle = await _context.MinistryArticles.FindAsync(id);

            if (ministryArticle == null)
            {
                return NotFound();
            }

            return ministryArticle;
        }

        // PUT: api/MinistryArticles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMinistryArticle(int id, MinistryArticle ministryArticle)
        {
            if (id != ministryArticle.MinistryArticleId)
            {
                return BadRequest();
            }

            _context.Entry(ministryArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MinistryArticleExists(id))
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

        // POST: api/MinistryArticles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MinistryArticle>> PostMinistryArticle(MinistryArticle ministryArticle)
        {
            _context.MinistryArticles.Add(ministryArticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMinistryArticle", new { id = ministryArticle.MinistryArticleId }, ministryArticle);
        }

        // DELETE: api/MinistryArticles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMinistryArticle(int id)
        {
            var ministryArticle = await _context.MinistryArticles.FindAsync(id);
            if (ministryArticle == null)
            {
                return NotFound();
            }

            _context.MinistryArticles.Remove(ministryArticle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MinistryArticleExists(int id)
        {
            return _context.MinistryArticles.Any(e => e.MinistryArticleId == id);
        }
    }
}
