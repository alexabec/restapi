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
    public class SavedItemsController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public SavedItemsController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/SavedItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavedItems>>> GetSavedItems()
        {
            return await _context.SavedItems.ToListAsync();
        }

        // GET: api/SavedItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavedItems>> GetSavedItems(int id)
        {
            var savedItems = await _context.SavedItems.FindAsync(id);

            if (savedItems == null)
            {
                return NotFound();
            }

            return savedItems;
        }

        // GET: api/SavedItems/5
        [HttpGet("{id}/photo")]
        public async Task<ActionResult<SavedItems>> GetSavedItemsPhotos(int id)
        {
            var savedItems = await _context.SavedItems.FindAsync(id);

            if (savedItems == null)
            {
                return NotFound();
            }
            return savedItems;
        }

        // GET: api/saveditems/user/customer_id
        [HttpGet("user/{customer_id}")]
        public ActionResult<List<SavedItems>> GetUserSaved(int customer_id)
        {
            var list = _context.SavedItems.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<SavedItems> SavedList = new List<SavedItems>();

            foreach (var entry in list)
            {
                if (entry.CustomerId == customer_id)
                {
                    SavedList.Add(entry);
                }
            }
            return SavedList;
        }

        // GET: api/items/user/photo/customer_id
        [HttpGet("user/photo/{customer_id}")]
        public ActionResult<List<SavedItems>> GetUserSavedPhotos(int customer_id)
        {
            var list = _context.SavedItems.ToList();
            if (list == null)
            {
                return NotFound("erroooorrrrr");
            }
            var savedItemsPhotos = _context.Items.ToList();
            if (savedItemsPhotos == null)
            {
                return NotFound("item fails");
            }

            List<SavedItems> SavedList = new List<SavedItems>();
            List<SavedItems> SList = new List<SavedItems>();
            List<Items> SavedPhotos = new List<Items>();

            foreach (var test in savedItemsPhotos)
            {
                foreach (var entry in list)
                {
                    if (entry.CustomerId == customer_id)
                    {
                        SavedList.Add(entry);
                    }
                    foreach (var item in SavedList)
                    {
                        if (item.ItemId == test.Id)
                        {
                            SList.Add(item);
                        }
                    }

                }
            }
            return SList;
        }

        // GET: api/saveditems/saved/item_id/customer_id
        [HttpGet("saved/{item_id}/{customer_id}")]
        public ActionResult<List<SavedItems>> GetUserSavedItem(int item_id, int customer_id)
        {
            var list = _context.SavedItems.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<SavedItems> SavedList = new List<SavedItems>();

            foreach (var entry in list)
            {
                if (entry.CustomerId == customer_id && entry.ItemId == item_id)
                {
                    SavedList.Add(entry);
                }
            }
            return SavedList;
        }

        // PUT: api/SavedItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavedItems(int id, SavedItems savedItems)
        {
            if (id != savedItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(savedItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedItemsExists(id))
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

        // POST: api/SavedItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SavedItems>> PostSavedItems(SavedItems savedItems)
        {
            _context.SavedItems.Add(savedItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavedItems", new { id = savedItems.Id }, savedItems);
        }

        // DELETE: api/SavedItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SavedItems>> DeleteSavedItems(int id)
        {
            var savedItems = await _context.SavedItems.FindAsync(id);
            if (savedItems == null)
            {
                return NotFound();
            }

            _context.SavedItems.Remove(savedItems);
            await _context.SaveChangesAsync();

            return savedItems;
        }

        private bool SavedItemsExists(int id)
        {
            return _context.SavedItems.Any(e => e.Id == id);
        }
    }
}
