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
    public class CartsController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public CartsController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carts>>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carts>> GetCarts(int id)
        {
            var carts = await _context.Carts.FindAsync(id);

            if (carts == null)
            {
                return NotFound();
            }

            return carts;
        }

        // GET: api/carts/user/username
        [HttpGet("user/{customer_username}")]
        public ActionResult<List<Carts>> GetUserCarts(string customer_username)
        {
            var list = _context.Carts.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Carts> CartList = new List<Carts>();

            foreach (var entry in list)
            {
                if (entry.CustomerUsername == customer_username)
                {
                    CartList.Add(entry);
                }
            }
            return CartList;
        }

        // GET: api/carts/user/username/shop_name
        [HttpGet("user/{customer_username}/{shop_name}")]
        public ActionResult<List<Carts>> GetShopCart(string customer_username, string shop_name)
        {
            var list = _context.Carts.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Carts> ShopCart = new List<Carts>();

            foreach (var entry in list)
            {
                if (entry.CustomerUsername == customer_username && entry.ShopName == shop_name)
                {
                    ShopCart.Add(entry);
                }
            }
            return ShopCart;
        }


        // PUT: api/Carts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarts(int id, Carts carts)
        {
            if (id != carts.Id)
            {
                return BadRequest();
            }

            _context.Entry(carts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartsExists(id))
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

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Carts>> PostCarts(Carts carts)
        {
            _context.Carts.Add(carts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarts", new { id = carts.Id }, carts);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carts>> DeleteCarts(int id)
        {
            var carts = await _context.Carts.FindAsync(id);
            if (carts == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(carts);
            await _context.SaveChangesAsync();

            return carts;
        }

        private bool CartsExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
