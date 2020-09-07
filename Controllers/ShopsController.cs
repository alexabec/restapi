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
    public class ShopsController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public ShopsController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shops>>> GetShops()
        {
            return await _context.Shops.ToListAsync();
        }

        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shops>> GetShops(int id)
        {
            var shops = await _context.Shops.FindAsync(id);

            if (shops == null)
            {
                return NotFound();
            }

            return shops;
        }

        // GET: api/shops/shop/shop_name
        [HttpGet("shop/{shop_name}")]
        public ActionResult<List<Shops>> GetShopName (string shop_name) 
        {
            var list = _context.Shops.ToList ();
            if (list == null) 
            {
                return NotFound();
            }
            
            List<Shops> ShopParams = new List<Shops> ();

            foreach (var entry in list) 
            {
                if (entry.ShopName == shop_name) 
                {
                    ShopParams.Add(entry);
                }
            }
            return ShopParams;
        }

        // PUT: api/Shops/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShops(int id, Shops shops)
        {
            if (id != shops.Id)
            {
                return BadRequest();
            }

            _context.Entry(shops).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopsExists(id))
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

        // PUT: api/Shops/5/currency/currency
        [HttpPut("{id}/currency/{currency}")]
        public string PutCurrency (int id, string currency) 
        {

            var shop = _context.Shops.Find (id);

            if (shop.Currency != null || shop.Currency == null ) {

                shop.Currency = currency;
                _context.Shops.Update (shop);
                _context.SaveChanges ();

                return "Currency has been changed to " + shop.Currency ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // PUT: api/Shops/5/address/address
        [HttpPut("{id}/address/{address}")]
        public string PutAddress (int id, string address) 
        {

            var shop = _context.Shops.Find (id);

            if (shop.ProfileAddress != null || shop.ProfileAddress == null ) {

                shop.ProfileAddress = address;
                _context.Shops.Update (shop);
                _context.SaveChanges ();

                return "Address has been changed to " + shop.ProfileAddress ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // PUT: api/Shops/5/infobio/infobio
        [HttpPut("{id}/infobio/{infobio}")]
        public string PutInfoBio (int id, string infobio) 
        {

            var shop = _context.Shops.Find (id);

            if (shop.ProfileBio != null || shop.ProfileBio == null ) {

                shop.ProfileBio = infobio;
                _context.Shops.Update (shop);
                _context.SaveChanges ();

                return "Bio has been changed to " + shop.ProfileBio ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // PUT: api/Shops/5/infobio/infobio
        [HttpPut("{id}/contact/{email}")]
        public string PutEmail (int id, string email) 
        {

            var shop = _context.Shops.Find (id);

            if (shop.ProfileEmail != null || shop.ProfileEmail == null ) {

                shop.ProfileEmail = email;
                _context.Shops.Update (shop);
                _context.SaveChanges ();

                return "Contact email has been changed to " + shop.ProfileEmail ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // PUT: api/Shops/5/category/category
        [HttpPut("{id}/category/{category}")]
        public string PutCategory (int id, string category) 
        {

            var shop = _context.Shops.Find (id);

            if (shop.Category != null || shop.Category == null ) {

                shop.Category = category;
                _context.Shops.Update (shop);
                _context.SaveChanges ();

                return "Category has been changed to " + shop.Category ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // POST: api/Shops
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shops>> PostShops(Shops shops)
        {
            _context.Shops.Add(shops);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShops", new { id = shops.Id }, shops);
        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shops>> DeleteShops(int id)
        {
            var shops = await _context.Shops.FindAsync(id);
            if (shops == null)
            {
                return NotFound();
            }

            _context.Shops.Remove(shops);
            await _context.SaveChangesAsync();

            return shops;
        }

        private bool ShopsExists(int id)
        {
            return _context.Shops.Any(e => e.Id == id);
        }
    }
}
