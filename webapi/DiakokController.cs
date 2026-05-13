using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiakokWebApi.Data;
using DiakokWebApi.Model;

namespace DiakokWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiakokController : ControllerBase
    {
        private readonly EgyetemContext _context;

        public DiakokController(EgyetemContext context)
        {
            _context = context;
        }

        // GET: api/Diakok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diak>>> GetDiakok()
        {
            return await _context.Diakok.ToListAsync();
        }

        // GET: api/Diakok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diak>> GetDiak(int id)
        {
            var diak = await _context.Diakok.FindAsync(id);

            if (diak == null)
            {
                return NotFound();
            }

            return diak;
        }

        // PUT: api/Diakok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiak(int id, Diak diak)
        {
            if (id != diak.Id)
            {
                return BadRequest();
            }

            _context.Entry(diak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiakExists(id))
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

        // POST: api/Diakok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diak>> PostDiak(Diak diak)
        {
            _context.Diakok.Add(diak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiak", new { id = diak.Id }, diak);
        }

        // DELETE: api/Diakok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiak(int id)
        {
            var diak = await _context.Diakok.FindAsync(id);
            if (diak == null)
            {
                return NotFound();
            }

            _context.Diakok.Remove(diak);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiakExists(int id)
        {
            return _context.Diakok.Any(e => e.Id == id);
        }
    }
}
