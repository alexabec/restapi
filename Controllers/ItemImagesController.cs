using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kwiqstage.Models;

namespace kwiqstage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemImagesController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public ItemImagesController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/ItemImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemImages>>> GetItemImages()
        {
            return await _context.ItemImages.ToListAsync();
        }

        // GET: api/ItemImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemImages>> GetItemImages(int id)
        {
            var itemImages = await _context.ItemImages.FindAsync(id);

            if (itemImages == null)
            {
                return NotFound();
            }

            return itemImages;
        }

        // PUT: api/ItemImages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemImages(int id, ItemImages itemImages)
        {
            if (id != itemImages.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemImages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemImagesExists(id))
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

        // POST: api/ItemImages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemImages>> PostItemImages(ItemImages itemImages)
        {
            _context.ItemImages.Add(itemImages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemImages", new { id = itemImages.Id }, itemImages);
        }

        // DELETE: api/ItemImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemImages>> DeleteItemImages(int id)
        {
            var itemImages = await _context.ItemImages.FindAsync(id);
            if (itemImages == null)
            {
                return NotFound();
            }

            _context.ItemImages.Remove(itemImages);
            await _context.SaveChangesAsync();

            return itemImages;
        }

        private bool ItemImagesExists(int id)
        {
            return _context.ItemImages.Any(e => e.Id == id);
        }
    }
}
