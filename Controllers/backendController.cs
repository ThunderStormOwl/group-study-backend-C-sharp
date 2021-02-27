using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class backendController : ControllerBase
    {
        private readonly backendContext _context;

        public backendController(backendContext context)
        {
            _context = context;
        }

        // GET: api/backend
        [HttpGet]
        public async Task<ActionResult<IEnumerable<backendItem>>> GetbackendItems()
        {
            return await _context.backendItems.ToListAsync();
        }

        // GET: api/backend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<backendItem>> GetbackendItem(long id)
        {
            var backendItem = await _context.backendItems.FindAsync(id);

            if (backendItem == null)
            {
                return NotFound();
            }

            return backendItem;
        }

        // PUT: api/backend/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutbackendItem(long id, backendItem backendItem)
        {
            if (id != backendItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(backendItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!backendItemExists(id))
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

        // POST: api/backend
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<backendItem>> PostbackendItem(backendItem backendItem)
        {
            _context.backendItems.Add(backendItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetbackendItem", new { id = backendItem.Id }, backendItem);
        }

        // DELETE: api/backend/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletebackendItem(long id)
        {
            var backendItem = await _context.backendItems.FindAsync(id);
            if (backendItem == null)
            {
                return NotFound();
            }

            _context.backendItems.Remove(backendItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool backendItemExists(long id)
        {
            return _context.backendItems.Any(e => e.Id == id);
        }
    }
}
