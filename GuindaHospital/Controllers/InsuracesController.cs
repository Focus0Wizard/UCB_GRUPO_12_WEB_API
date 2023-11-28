using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuindaHospital.Model;

namespace GuindaHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuracesController : ControllerBase
    {
        private readonly GindaHospitalContext _context;

        public InsuracesController(GindaHospitalContext context)
        {
            _context = context;
        }

        // GET: api/Insuraces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurace>>> GetInsuraces()
        {
          if (_context.Insuraces == null)
          {
              return NotFound();
          }
            return await _context.Insuraces.ToListAsync();
        }

        // GET: api/Insuraces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insurace>> GetInsurace(int id)
        {
          if (_context.Insuraces == null)
          {
              return NotFound();
          }
            var insurace = await _context.Insuraces.FindAsync(id);

            if (insurace == null)
            {
                return NotFound();
            }

            return insurace;
        }

        // PUT: api/Insuraces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurace(int id, Insurace insurace)
        {
            if (id != insurace.Id)
            {
                return BadRequest();
            }

            _context.Entry(insurace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuraceExists(id))
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

        // POST: api/Insuraces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insurace>> PostInsurace(Insurace insurace)
        {
          if (_context.Insuraces == null)
          {
              return Problem("Entity set 'GindaHospitalContext.Insuraces'  is null.");
          }
            _context.Insuraces.Add(insurace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsurace", new { id = insurace.Id }, insurace);
        }

        // DELETE: api/Insuraces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurace(int id)
        {
            if (_context.Insuraces == null)
            {
                return NotFound();
            }
            var insurace = await _context.Insuraces.FindAsync(id);
            if (insurace == null)
            {
                return NotFound();
            }

            _context.Insuraces.Remove(insurace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuraceExists(int id)
        {
            return (_context.Insuraces?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
