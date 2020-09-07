using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kwiqstage.Models;
using Stripe;


namespace kwiqstage.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public OrdersController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }
            

            return orders;
        }

        // GET: api/orders/user/username
        [HttpGet("user/{username}")]
        public ActionResult<List<Orders>> GetUserOrders(string username)
        {
            var list = _context.Orders.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Orders> MyOrdersList = new List<Orders>();

            foreach (var entry in list)
            {
                if (entry.CustomerUsername == username)
                {
                    MyOrdersList.Add(entry);
                }
            }
            return MyOrdersList;
        }

        // GET: api/orders/shop/shop_name
        [HttpGet("shop/{shop_name}")]
        public ActionResult<List<Orders>> GetShopOrders(string shop_name)
        {
            var list = _context.Orders.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Orders> OrdersList = new List<Orders>();

            foreach (var entry in list)
            {
                if (entry.ShopName == shop_name)
                {
                    OrdersList.Add(entry);
                }
            }
            return OrdersList;
        }

        // GET: api/orders/pending/shop_name
        [HttpGet("pending/{shop_name}")]
        public ActionResult<List<Orders>> GetPendingOrders(string shop_name)
        {
            var list = _context.Orders.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Orders> PendingOrdersList = new List<Orders>();

            foreach (var entry in list)
            {
                if (entry.Shipped == false && entry.ShopName == shop_name)
                {
                    PendingOrdersList.Add(entry);
                }
            }
            return PendingOrdersList;
        }

        // GET: api/orders/history/shop_name
        [HttpGet("history/{shop_name}")]
        public ActionResult<List<Orders>> GetSalesHistory(string shop_name)
        {
            var list = _context.Orders.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<Orders> SalesHistoryList = new List<Orders>();

            foreach (var entry in list)
            {
                if (entry.Shipped == true && entry.ShopName == shop_name)
                {
                    SalesHistoryList.Add(entry);
                }
            }
            return SalesHistoryList;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if (id != orders.Id)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // PUT: api/Orders/5/shipped
        [HttpPut("{id}/shipped")]
        public string PutShipped(int id, DateTime shipping_date)
        {

            var status = _context.Orders.Find(id);

            if (status.Shipped == false)
            {
                status.Shipped = true;
                status.ShippingDate = shipping_date;
                _context.Orders.Update(status);
                _context.SaveChanges();

                return "Status has been set to shipped " + status.Shipped + " at " + status.ShippingDate;

            }
            else
            {
                return "This order has already been shipped";
            }
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrders(Orders orders, string currency)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrders", new { id = orders.Id }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return orders;
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
