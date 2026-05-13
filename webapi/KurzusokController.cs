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
    public class KurzusokController : ControllerBase
    {
        private readonly EgyetemContext _context;

        public KurzusokController(EgyetemContext context)
        {
            _context = context;
        }

        // GET: api/Kurzusok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kurzus>>> GetKurzusok()
        {
            return await _context.Kurzusok.ToListAsync();
        }

        // GET: api/Kurzusok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kurzus>> GetKurzus(int id)
        {
            var kurzus = await _context.Kurzusok.FindAsync(id);

            if (kurzus == null)
            {
                return NotFound();
            }

            return kurzus;
        }

        // PUT: api/Kurzusok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKurzus(int id, Kurzus kurzus)
        {
            if (id != kurzus.Id)
            {
                return BadRequest();
            }

            _context.Entry(kurzus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KurzusExists(id))
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

        // POST: api/Kurzusok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kurzus>> PostKurzus(Kurzus kurzus)
        {
            _context.Kurzusok.Add(kurzus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKurzus", new { id = kurzus.Id }, kurzus);
        }

        // DELETE: api/Kurzusok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKurzus(int id)
        {
            var kurzus = await _context.Kurzusok.FindAsync(id);
            if (kurzus == null)
            {
                return NotFound();
            }

            _context.Kurzusok.Remove(kurzus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KurzusExists(int id)
        {
            return _context.Kurzusok.Any(e => e.Id == id);
        }
    }
}
