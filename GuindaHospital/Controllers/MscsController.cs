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
    public class MscsController : ControllerBase
    {
        private readonly GindaHospitalContext _context;

        public MscsController(GindaHospitalContext context)
        {
            _context = context;
        }

        // GET: api/Mscs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Msc>>> GetMscs()
        {
          if (_context.Mscs == null)
          {
              return NotFound();
          }
            return await _context.Mscs.ToListAsync();
        }

        // GET: api/Mscs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Msc>> GetMsc(int id)
        {
          if (_context.Mscs == null)
          {
              return NotFound();
          }
            var msc = await _context.Mscs.FindAsync(id);

            if (msc == null)
            {
                return NotFound();
            }

            return msc;
        }

        // PUT: api/Mscs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMsc(int id, Msc msc)
        {
            if (id != msc.Id)
            {
                return BadRequest();
            }

            _context.Entry(msc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MscExists(id))
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

        // POST: api/Mscs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Msc>> PostMsc(Msc msc)
        {
          if (_context.Mscs == null)
          {
              return Problem("Entity set 'GindaHospitalContext.Mscs'  is null.");
          }
            _context.Mscs.Add(msc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMsc", new { id = msc.Id }, msc);
        }

        // DELETE: api/Mscs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMsc(int id)
        {
            if (_context.Mscs == null)
            {
                return NotFound();
            }
            var msc = await _context.Mscs.FindAsync(id);
            if (msc == null)
            {
                return NotFound();
            }

            _context.Mscs.Remove(msc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MscExists(int id)
        {
            return (_context.Mscs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
