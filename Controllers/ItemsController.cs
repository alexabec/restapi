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
    public class ItemsController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public ItemsController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Items>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Items>> GetItems(int id)
        {
            var items = await _context.Items.FindAsync(id);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        // GET: api/items/user/photo/customer_id
        [HttpGet("user/photo/{customer_id}")]
        public ActionResult<List<Items>> GetUserSavedPhotos(int customer_id)
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
            List<Items> SavedPhotos = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.CustomerId == customer_id)
                {
                    SavedList.Add(entry);
                }

                foreach (var test in savedItemsPhotos)
                {
                    foreach (var item in SavedList)
                    {
                        if (item.ItemId == test.Id)
                        {
                            SavedPhotos.Add(test);
                        }
                    }
                }
            }
            return SavedPhotos;
        }

        //GET: api/Items/featured/
        [HttpGet("featured/")]
        public ActionResult<List<Items>> GetFeatured()
        {
            var list = _context.Items.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Items> FeaturedList = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.Featured == true)
                {
                    FeaturedList.Add(entry);
                }
            }
            return FeaturedList;
        }

        //GET: api/Items/feed/
        [HttpGet("feed/")]
        public ActionResult<List<Items>> GetFeed()
        {
            var list = _context.Items.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Items> FeedList = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.Featured == false)
                {
                    FeedList.Add(entry);
                }
            }
            return FeedList;
        }

        // GET: api/Items/featured/shop_name
        [HttpGet("featured/{shop_name}")]
        public ActionResult<List<Items>> GetFeaturedItems(string shop_name)
        {
            var list = _context.Items.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Items> FeaturedList = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.Featured == true && entry.ShopName == shop_name)
                {
                    FeaturedList.Add(entry);
                }
            }
            return FeaturedList;
        }

        // GET: api/Items/shop_id/featured
        [HttpGet("{shop_id}/featured")]
        public ActionResult<List<Items>> GetFeaturedItemsShopId(int shop_id)
        {
            var list = _context.Items.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Items> FeaturedList = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.Featured == true && entry.ShopId == shop_id)
                {
                    FeaturedList.Add(entry);
                }
            }
            return FeaturedList;
        }

        // GET: api/Items/feed/shop_name
        [HttpGet("feed/{shop_name}")]
        public ActionResult<List<Items>> GetFeedItems(string shop_name)
        {
            var list = _context.Items.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Items> FeedList = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.Featured == false && entry.ShopName == shop_name)
                {
                    FeedList.Add(entry);
                }
            }
            return FeedList;
        }

        // GET: api/Items/shop_id/featured
        [HttpGet("{shop_id}/feed")]
        public ActionResult<List<Items>> GetFeedItemsShopId(int shop_id)
        {
            var list = _context.Items.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Items> FeaturedList = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.Featured == false && entry.ShopId == shop_id)
                {
                    FeaturedList.Add(entry);
                }
            }
            return FeaturedList;
        }

        // GET: api/Items/search/hashtag
        [HttpGet("search/{hashtag}")]
        public ActionResult<List<Items>> GetSearchHashtag(string hashtag)
        {
            var list = _context.Items.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Items> SearchList = new List<Items>();

            foreach (var entry in list)
            {
                if (entry.Hashtags.Contains(hashtag) || entry.Category.Contains(hashtag))
                {
                    SearchList.Add(entry);
                }
            }
            return SearchList;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems(int id, Items items)
        {
            if (id != items.Id)
            {
                return BadRequest();
            }

            _context.Entry(items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(id))
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

        // PUT: api/items/5/name/name
        [HttpPut("{id}/name/{name}")]
        public string PutName(int id, string name)
        {

            var item = _context.Items.Find(id);

            if (item.Name != null || item.Name == null)
            {

                item.Name = name;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Name has been changed to " + item.Name;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/price/price
        [HttpPut("{id}/price/{price}")]
        public string PutPrice(int id, string price)
        {

            var item = _context.Items.Find(id);

            if (item.Price != null || item.Price == null)
            {

                item.Price = price;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Price has been changed to " + item.Price;

            }
            else
            {
                return "Error.";
            }
        }

        // // PUT: api/items/5/image/
        [HttpPut("{id}/image")]
        public string PutImage(int id, string image)
        {

            var item = _context.Items.Find(id);

            if (item.Image != null || item.Image == null)
            {

                item.Image = image;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Image has been changed to " + item.Image;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/gender/gender
        [HttpPut("{id}/gender/{gender}")]
        public string PutGender(int id, string gender)
        {

            var item = _context.Items.Find(id);

            if (item.Gender != null || item.Gender == null)
            {

                item.Gender = gender;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "gender has been changed to " + item.Gender;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/size/size
        [HttpPut("{id}/size/{size}")]
        public string PutSize(int id, string size)
        {

            var item = _context.Items.Find(id);

            if (item.Size != null || item.Size == null)
            {

                item.Size = size;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Size has been changed to " + item.Size;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/desc/desc
        [HttpPut("{id}/desc/{description}")]
        public string PutDescription(int id, string description)
        {

            var item = _context.Items.Find(id);

            if (item.Description != null || item.Description == null)
            {

                item.Description = description;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Description has been changed to " + item.Description;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/sale/sale
        [HttpPut("{id}/sale/{sale}")]
        public string PutSale(int id, string sale)
        {

            var item = _context.Items.Find(id);

            if (item.Sale != null || item.Sale == null)
            {

                item.Sale = sale;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Username has been changed to " + item.Sale;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/hash/hash
        [HttpPut("{id}/hash/{hash}")]
        public string PutHash(int id, string hash)
        {

            var item = _context.Items.Find(id);

            if (item.Hashtags != null || item.Hashtags == null)
            {

                item.Hashtags = hash;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Username has been changed to " + item.Hashtags;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/cat/cat
        [HttpPut("{id}/cat/{cat}")]
        public string PutCategory(int id, string cat)
        {

            var item = _context.Items.Find(id);

            if (item.Category != null || item.Category == null)
            {

                item.Category = cat;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Category has been changed to " + item.Category;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/items/5/feat/featured
        [HttpPut("{id}/feat/{featured}")]
        public string PutFeatured(int id, bool featured)
        {

            var item = _context.Items.Find(id);

            if (item.Featured != null || item.Featured == null)
            {

                item.Featured = featured;
                _context.Items.Update(item);
                _context.SaveChanges();

                return "Username has been changed to " + item.Featured;

            }
            else
            {
                return "Error.";
            }
        }


        // POST: api/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Items>> PostItems(Items items)
        {
            _context.Items.Add(items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItems", new { id = items.Id }, items);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Items>> DeleteItems(int id)
        {
            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            _context.Items.Remove(items);
            await _context.SaveChangesAsync();

            return items;
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
