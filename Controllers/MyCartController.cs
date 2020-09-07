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
    public class MyCartController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public MyCartController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/MyCart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyCart>>> GetMyCart()
        {
            return await _context.MyCart.ToListAsync();
        }

        // GET: api/MyCart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyCart>> GetMyCart(int id)
        {
            var myCart = await _context.MyCart.FindAsync(id);

            if (myCart == null)
            {
                return NotFound();
            }

            return myCart;
        }
        // GET: api/mycart/user/cart_id
        [HttpGet("cart/{cart_id}")]
        public ActionResult<List<MyCart>> GetUserCarts(int cart_id)
        {
            var list = _context.MyCart.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<MyCart> CartList = new List<MyCart>();

            foreach (var entry in list)
            {
                if (entry.CartId == cart_id)
                {
                    CartList.Add(entry);
                }
            }
            return CartList;
        }

        // PUT: api/MyCart/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyCart(int id, MyCart myCart)
        {
            if (id != myCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(myCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyCartExists(id))
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

        // POST: api/MyCart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MyCart>> PostMyCart(MyCart myCart)
        {
            _context.MyCart.Add(myCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyCart", new { id = myCart.Id }, myCart);
        }

        // DELETE: api/MyCart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MyCart>> DeleteMyCart(int id)
        {
            var myCart = await _context.MyCart.FindAsync(id);
            if (myCart == null)
            {
                return NotFound();
            }

            _context.MyCart.Remove(myCart);
            await _context.SaveChangesAsync();

            return myCart;
        }

        private bool MyCartExists(int id)
        {
            return _context.MyCart.Any(e => e.Id == id);
        }
    }
}
