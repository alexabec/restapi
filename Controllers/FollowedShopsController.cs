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
    public class FollowedShopsController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public FollowedShopsController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/FollowedShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FollowedShops>>> GetFollowedShops()
        {
            return await _context.FollowedShops.ToListAsync();
        }

        // GET: api/FollowedShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FollowedShops>> GetFollowedShops(int id)
        {
            var followedShops = await _context.FollowedShops.FindAsync(id);

            if (followedShops == null)
            {
                return NotFound();
            }

            return followedShops;
        }
        

         // GET: api/FollowedShops/user/customer_id
        [HttpGet("user/{customer_id}")]
        public ActionResult<List<FollowedShops>> GetUserFollowed(int customer_id)
        {
            var list = _context.FollowedShops.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<FollowedShops> FollowList = new List<FollowedShops>();

            foreach (var entry in list)
            {
                if (entry.CustomerId == customer_id)
                {
                    FollowList.Add(entry);
                }
            }
            return FollowList;
        }

        // GET: api/FollowedShops/user/customer_id/shop_id
        [HttpGet("id/{customer_id}/{shop_id}")]
        public ActionResult<List<FollowedShops>> GetFollowId(int customer_id, int shop_id)
        {
            var list = _context.FollowedShops.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<FollowedShops> FollowList = new List<FollowedShops>();

            foreach (var entry in list)
            {
                if (entry.CustomerId == customer_id && entry.ShopId == shop_id)
                {
                    FollowList.Add(entry);
                }
            }
            return FollowList;
        }

        // GET: api/FollowedShops/shop/shop_id
        [HttpGet("shop/{shop_id}")]
        public ActionResult<List<FollowedShops>> GetShopFollowers(int shop_id)
        {
            var list = _context.FollowedShops.ToList();
            if (list == null)
            {
                return NotFound();
            }

            List<FollowedShops> FollowList = new List<FollowedShops>();

            foreach (var entry in list)
            {
                if (entry.ShopId == shop_id)
                {
                    FollowList.Add(entry);
                }
            }
            return FollowList;
        }

        // PUT: api/FollowedShops/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowedShops(int id, FollowedShops followedShops)
        {
            if (id != followedShops.Id)
            {
                return BadRequest();
            }

            _context.Entry(followedShops).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowedShopsExists(id))
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

        // POST: api/FollowedShops
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FollowedShops>> PostFollowedShops(FollowedShops followedShops)
        {
            _context.FollowedShops.Add(followedShops);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFollowedShops", new { id = followedShops.Id }, followedShops);
        }

        // DELETE: api/FollowedShops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FollowedShops>> DeleteFollowedShops(int id)
        {
            var followedShops = await _context.FollowedShops.FindAsync(id);
            if (followedShops == null)
            {
                return NotFound();
            }

            _context.FollowedShops.Remove(followedShops);
            await _context.SaveChangesAsync();

            return followedShops;
        }

        private bool FollowedShopsExists(int id)
        {
            return _context.FollowedShops.Any(e => e.Id == id);
        }
    }
}
