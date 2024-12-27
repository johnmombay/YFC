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
    public class StatementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Statements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statement>>> GetStatements()
        {
            return await _context.Statements.ToListAsync();
        }

        // GET: api/Statements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statement>> GetStatement(int id)
        {
            var statement = await _context.Statements.FindAsync(id);

            if (statement == null)
            {
                return NotFound();
            }

            return statement;
        }

        // PUT: api/Statements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatement(int id, Statement statement)
        {
            if (id != statement.StatementId)
            {
                return BadRequest();
            }

            _context.Entry(statement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatementExists(id))
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

        // POST: api/Statements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statement>> PostStatement(Statement statement)
        {
            _context.Statements.Add(statement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatement", new { id = statement.StatementId }, statement);
        }

        // DELETE: api/Statements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatement(int id)
        {
            var statement = await _context.Statements.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }

            _context.Statements.Remove(statement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatementExists(int id)
        {
            return _context.Statements.Any(e => e.StatementId == id);
        }
    }
}
