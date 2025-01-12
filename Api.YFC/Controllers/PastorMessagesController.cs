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
    public class PastorMessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PastorMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PastorMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PastorMessage>>> GetPastorMessages()
        {
            return await _context.PastorMessages.ToListAsync();
        }

        // GET: api/PastorMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastorMessage>> GetPastorMessage(int id)
        {
            var pastorMessage = await _context.PastorMessages.FindAsync(id);

            if (pastorMessage == null)
            {
                return NotFound();
            }

            return pastorMessage;
        }

        // PUT: api/PastorMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPastorMessage(int id, PastorMessage pastorMessage)
        {
            if (id != pastorMessage.PastorMessageId)
            {
                return BadRequest();
            }

            _context.Entry(pastorMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastorMessageExists(id))
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

        // POST: api/PastorMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PastorMessage>> PostPastorMessage(PastorMessage pastorMessage)
        {
            _context.PastorMessages.Add(pastorMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPastorMessage", new { id = pastorMessage.PastorMessageId }, pastorMessage);
        }

        // DELETE: api/PastorMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePastorMessage(int id)
        {
            var pastorMessage = await _context.PastorMessages.FindAsync(id);
            if (pastorMessage == null)
            {
                return NotFound();
            }

            _context.PastorMessages.Remove(pastorMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PastorMessageExists(int id)
        {
            return _context.PastorMessages.Any(e => e.PastorMessageId == id);
        }
    }
}
