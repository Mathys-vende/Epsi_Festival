using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Epsi_Festival.Models;

namespace Epsi_Festival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammationsController : ControllerBase
    {
        private readonly Festival_EPSIContext _context;

        public ProgrammationsController(Festival_EPSIContext context)
        {
            _context = context;
        }

        // GET: api/Programmations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programmation>>> GetProgrammations()
        {
            return await _context.Programmations.Include(p => p.Artiste).Include(p => p.Scene).ToListAsync();
        }

        // GET: api/Programmations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programmation>> GetProgrammation(int id)
        {
            var programmation = await _context.Programmations.FindAsync(id);

            if (programmation == null)
            {
                return NotFound();
            }

            return programmation;
        }

        // PUT: api/Programmations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgrammation(int id, Programmation programmation)
        {
            if (id != programmation.Id)
            {
                return BadRequest();
            }

            _context.Entry(programmation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammationExists(id))
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

        // POST: api/Programmations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Programmation>> PostProgrammation(Programmation programmation)
        {
            _context.Programmations.Add(programmation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgrammation", new { id = programmation.Id }, programmation);
        }

        // DELETE: api/Programmations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgrammation(int id)
        {
            var programmation = await _context.Programmations.FindAsync(id);
            if (programmation == null)
            {
                return NotFound();
            }

            _context.Programmations.Remove(programmation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgrammationExists(int id)
        {
            return _context.Programmations.Any(e => e.Id == id);
        }
    }
}
