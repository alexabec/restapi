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
    public class BusinessAccountController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public BusinessAccountController(kwiq_prodContext context)
        {
            _context = context;
        }

        // GET: api/BusinessAccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessAccount>>> GetBusinessAccount()
        {
            return await _context.BusinessAccount.ToListAsync();
        }

        // GET: api/BusinessAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessAccount>> GetBusinessAccount(int id)
        {
            var businessAccount = await _context.BusinessAccount.FindAsync(id);

            if (businessAccount == null)
            {
                return NotFound();
            }

            return businessAccount;
        }

        // GET: api/businessaccount/login/shop_name
        [HttpGet("login/{shop_name}")]
        public ActionResult<List<BusinessAccount>> GetLogin (string shop_name) 
        {
            var shops = _context.BusinessAccount.ToList ();
            if (shops == null) 
            {
                return NotFound();
            }
            
            List<BusinessAccount> shopList = new List<BusinessAccount> ();

            foreach (var shop in shops) 
            {
                if (shop.ShopName == shop_name)
                {
                    shopList.Add(shop);
                }
            }
            return shopList;
        }

        // PUT: api/BusinessAccount/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessAccount(int id, BusinessAccount businessAccount)
        {
            if (id != businessAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessAccountExists(id))
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

        // PUT: api/businessaccount/5/pword/password
        [HttpPut("{id}/pword/{password}")]
        public string PutPassword (int id, string password) 
        {

            var account = _context.BusinessAccount.Find (id);

            if (account.Password != null ) {

                account.Password = password;
                _context.BusinessAccount.Update (account);
                _context.SaveChanges ();

                return "Password has been changed to " + account.Password ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // PUT: api/businessaccount/5/email/email
        [HttpPut("{id}/email/{email}")]
        public string PutEmail (int id, string email) 
        {

            var account = _context.BusinessAccount.Find (id);

            if (account.BusinessEmail != null ) {

                account.BusinessEmail = email;
                _context.BusinessAccount.Update (account);
                _context.SaveChanges ();

                return "Email has been changed to " + account.BusinessEmail ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // PUT: api/businessaccount/5/dir/business_address
        [HttpPut("{id}/dir/{business_address}")]
        public string PutBusinessAddress (int id, string business_address) 
        {

            var account = _context.BusinessAccount.Find (id);

            if (account.BusinessAddress != null ) {

                account.BusinessAddress = business_address;
                _context.BusinessAccount.Update (account);
                _context.SaveChanges ();

                return "Business address has been changed to " + account.BusinessAddress ;

            } 
            else 
            {
                return "Error.";
            }
        }

        // PUT: api/businessaccount/5/curr/currency
        [HttpPut("{id}/curr/{currency}")]
        public string PutCurrency (int id, string currency) 
        {
            var account = _context.BusinessAccount.Find (id);

            if (account.Currency != null || account.Currency == null ) {

                account.Currency = currency;
                _context.BusinessAccount.Update (account);
                _context.SaveChanges ();

                return "Business currency has been changed to " + account.Currency ;

            } 
            else 
            {
                return "Error.";
            }
        }
        // POST: api/BusinessAccount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessAccount>> PostBusinessAccount(BusinessAccount businessAccount)
        {
            _context.BusinessAccount.Add(businessAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessAccount", new { id = businessAccount.Id }, businessAccount);
        }

        // DELETE: api/BusinessAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessAccount>> DeleteBusinessAccount(int id)
        {
            var businessAccount = await _context.BusinessAccount.FindAsync(id);
            if (businessAccount == null)
            {
                return NotFound();
            }

            _context.BusinessAccount.Remove(businessAccount);
            await _context.SaveChangesAsync();

            return businessAccount;
        }

        private bool BusinessAccountExists(int id)
        {
            return _context.BusinessAccount.Any(e => e.Id == id);
        }
    }
}
