using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Youapi.Models;

namespace Youapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YouItemController : ControllerBase
    {
        private readonly YouContext _context;

        public YouItemController(YouContext context)
        {
            _context = context;
        }

        // GET: api/YouItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YouItem>>> GetYouItem()
        {
            return await _context.YouItem.ToListAsync();
        }

        // GET: api/YouItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YouItem>> GetYouItem(long id)
        {
            var youItem = await _context.YouItem.FindAsync(id);

            if (youItem == null)
            {
                return NotFound();
            }

            return youItem;
        }

        // PUT: api/YouItem/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYouItem(long id, YouItem youItem)
        {
            if (id != youItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(youItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YouItemExists(id))
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

        // POST: api/YouItem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<YouItem>> PostYouItem(YouItem youItem)
        {
            _context.YouItem.Add(youItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetYouItem), new { id = youItem.Id }, youItem);
            // return CreatedAtAction("GetYouItem", new { id = youItem.Id }, youItem);
        }

        // DELETE: api/YouItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<YouItem>> DeleteYouItem(long id)
        {
            var youItem = await _context.YouItem.FindAsync(id);
            if (youItem == null)
            {
                return NotFound();
            }

            _context.YouItem.Remove(youItem);
            await _context.SaveChangesAsync();

            return youItem;
        }

        private bool YouItemExists(long id)
        {
            return _context.YouItem.Any(e => e.Id == id);
        }
    }
}
