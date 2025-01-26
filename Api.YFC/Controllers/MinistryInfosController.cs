using Api.YFC.Data;
using Api.YFC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.YFC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MinistryInfosController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public MinistryInfosController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/MinistryInfos
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MinistryInfo>>> GetMinistryInfos()
		{
			return await _context.MinistryInfos.ToListAsync();
		}

		// GET: api/MinistryInfos/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MinistryInfo>> GetMinistryInfo(int id)
		{
			var ministryInfo = await _context.MinistryInfos.FindAsync(id);

			if (ministryInfo == null)
			{
				return NotFound();
			}

			return ministryInfo;
		}

		[HttpGet]
		[Route("GetMinistryInfoByMinistryId/{id}")]
		public async Task<ActionResult<MinistryInfo>> GetMinistryInfoByMinistryId(int id)
		{
			var ministryInfo = await _context.MinistryInfos.Where(m=> m.MinistryId == id).FirstOrDefaultAsync();

			if (ministryInfo == null)
			{
				return NotFound();
			}

			return ministryInfo;
		}

		// PUT: api/MinistryInfos/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMinistryInfo(int id, MinistryInfo ministryInfo)
		{
			if (id != ministryInfo.MinistryInfoId)
			{
				return BadRequest();
			}

			_context.Entry(ministryInfo).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MinistryInfoExists(id))
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

		// POST: api/MinistryInfos
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<MinistryInfo>> PostMinistryInfo(MinistryInfo ministryInfo)
		{
			_context.MinistryInfos.Add(ministryInfo);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetMinistryInfo", new { id = ministryInfo.MinistryInfoId }, ministryInfo);
		}

		// DELETE: api/MinistryInfos/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMinistryInfo(int id)
		{
			var ministryInfo = await _context.MinistryInfos.FindAsync(id);
			if (ministryInfo == null)
			{
				return NotFound();
			}

			_context.MinistryInfos.Remove(ministryInfo);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MinistryInfoExists(int id)
		{
			return _context.MinistryInfos.Any(e => e.MinistryInfoId == id);
		}
	}
}
