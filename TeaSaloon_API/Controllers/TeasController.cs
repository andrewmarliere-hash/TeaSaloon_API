using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeaSaloon_API.Data;
using TeaSaloon_API.Models;

namespace TeaSaloon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeasController : ControllerBase
    {
        private readonly TeaSaloonContext _context;

        public TeasController(TeaSaloonContext context)
        {
            _context = context;
        }

        // GET: api/Teas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tea>>> GetTeas()
        {
            return await _context.Teas.ToListAsync();
        }

        // GET: api/Teas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tea>> GetTea(int id)
        {
            var tea = await _context.Teas.FindAsync(id);

            if (tea == null)
            {
                return NotFound();
            }

            return tea;
        }

        // PUT: api/Teas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTea(int id, Tea tea)
        {
            if (id != tea.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(tea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeaExists(id))
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

        // POST: api/Teas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tea>> PostTea(Tea tea)
        {
            _context.Teas.Add(tea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTea", new { id = tea.ProductID }, tea);
        }

        // DELETE: api/Teas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTea(int id)
        {
            var tea = await _context.Teas.FindAsync(id);
            if (tea == null)
            {
                return NotFound();
            }

            _context.Teas.Remove(tea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeaExists(int id)
        {
            return _context.Teas.Any(e => e.ProductID == id);
        }
    }
}
