using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kwiqstage.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Stripe;

namespace kwiqstage.Controllers
{
    public class clientSecret
    {
        public string client_secret { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        private readonly kwiq_prodContext _context;

        public CustomerAccountController(kwiq_prodContext context)
        {
            _context = context;
        }

        [HttpPost("stripecharge")]
        public async Task<dynamic> Pay(Models.PaymentModel pm)
        {
            return await MakePayment.PayAsync(pm.value, pm.currency, pm.stripeId);
        }

        [HttpPost("stripecustomer")]
        public async Task<dynamic> Client(Models.StripeClientModel sc)
        {
            return await CreateStripeClient.CreateClientAsync(sc.email, sc.name, sc.cardNumber, sc.month, sc.year, sc.cvv);
        }

        [HttpGet("{email}/customerId")]
        public ActionResult<List<Customer>> GetCustomerStripeId(Models.StripeClientModel sc)
        {
             return CreateStripeClient.GetClientId(sc.email);  
        }

        // GET: api/CustomerAccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerAccount>>> GetCustomerAccount()
        {
            return await _context.CustomerAccount.ToListAsync();
        }

        // GET: api/CustomerAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAccount>> GetCustomerAccount(int id)
        {
            var customerAccount = await _context.CustomerAccount.FindAsync(id);

            if (customerAccount == null)
            {
                return NotFound();
            }

            return customerAccount;
        }

        // GET: api/customeraccount/login/username
        [HttpGet("login/{username}")]
        public ActionResult<List<CustomerAccount>> GetLogin(string username)
        {
            var users = _context.CustomerAccount.ToList();
            if (users == null)
            {
                return NotFound();
            }

            List<CustomerAccount> userList = new List<CustomerAccount>();

            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    userList.Add(user);
                }
            }
            return userList;
        }

        // GET: api/CustomerAccount/secret
        [HttpPut("secret")]
        public string Get(int total, string currency, string customer)
        {
            total = 50000;
            currency = "CAD";
            customer = "cus_HWhZwYCqBmCxoU";

            var intent = new PaymentIntentCreateOptions
            {
                Amount = total,
                Currency = currency,
                Customer = customer,
                SetupFutureUsage = "on_session",
                PaymentMethodTypes = new List<string>
                { "card" },
                PaymentMethod = "pm_1GxeAPITcigAAz2yPakJ4Ce7"
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(intent);

            var options = new PaymentIntentConfirmOptions
            {
                PaymentMethod = "pm_1GxeAPITcigAAz2yPakJ4Ce7",
            };
            var payment = new PaymentIntentService();
            payment.Confirm(
              paymentIntent.Id,
              options
            );

            var myClient = new clientSecret() { client_secret = paymentIntent.ClientSecret };
            return JsonSerializer.Serialize<clientSecret>(myClient);
        }

        // PUT: api/CustomerAccount/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerAccount(int id, CustomerAccount customerAccount)
        {
            if (id != customerAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAccountExists(id))
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

        // PUT: api/customeraccount/5/user/username
        [HttpPut("{id}/user/{username}")]
        public string PutUsername(int id, string username)
        {

            var account = _context.CustomerAccount.Find(id);

            if (account.Username != null)
            {

                account.Username = username;
                _context.CustomerAccount.Update(account);
                _context.SaveChanges();

                return "Username has been changed to " + account.Username;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/customeraccount/5/pword/password
        [HttpPut("{id}/pword/{password}")]
        public string PutPassword(int id, string password)
        {

            var account = _context.CustomerAccount.Find(id);

            if (account.Password != null)
            {

                account.Password = password;
                _context.CustomerAccount.Update(account);
                _context.SaveChanges();

                return "Password has been changed to " + account.Password;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/customeraccount/5/email/email
        [HttpPut("{id}/email/{email}")]
        public string PutEmail(int id, string email)
        {

            var account = _context.CustomerAccount.Find(id);

            if (account.Email != null)
            {

                account.Email = email;
                _context.CustomerAccount.Update(account);
                _context.SaveChanges();

                return "Email has been changed to " + account.Email;

            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/customeraccount/5/dir/shipping_address
        [HttpPut("{id}/dir/{shipping_address}")]
        public string PutShippingAddress(int id, string shipping_address)
        {

            var account = _context.CustomerAccount.Find(id);

            if (account.ShippingAddress != null)
            {

                account.ShippingAddress = shipping_address;
                _context.CustomerAccount.Update(account);
                _context.SaveChanges();

                return "Shipping address has been changed to " + account.ShippingAddress;
            }
            else
            {
                return "Error.";
            }
        }

        // PUT: api/customeraccount/5/currency/currency
        [HttpPut("{id}/currency/{currency}")]
        public string PutCurrency(int id, string currency)
        {

            var account = _context.CustomerAccount.Find(id);

            if (account.Currency != null || account.Currency == null)
            {

                account.Currency = currency;
                _context.CustomerAccount.Update(account);
                _context.SaveChanges();

                return "Currency has been changed to " + account.Currency;

            }
            else
            {
                return "Error.";
            }
        }

        // POST: api/CustomerAccount
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerAccount>> PostCustomerAccount(CustomerAccount customerAccount)
        {
            _context.CustomerAccount.Add(customerAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerAccount", new { id = customerAccount.Id }, customerAccount);
        }

        // DELETE: api/CustomerAccount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerAccount>> DeleteCustomerAccount(int id)
        {
            var customerAccount = await _context.CustomerAccount.FindAsync(id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            _context.CustomerAccount.Remove(customerAccount);
            await _context.SaveChangesAsync();

            return customerAccount;
        }

        private bool CustomerAccountExists(int id)
        {
            return _context.CustomerAccount.Any(e => e.Id == id);
        }
    }
}
