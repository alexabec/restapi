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

namespace kwiqstage.Models
{
    public class CreateStripeClient
    {
        public static async Task<dynamic> CreateClientAsync(string email, string name, string cardNumber, int month, int year, string cvv)
        {
            var optionstoken = new TokenCreateOptions
            {
                Card = new CreditCardOptions
                {
                    Number = cardNumber,
                    ExpMonth = month,
                    ExpYear = year,
                    Cvc = cvv
                }
            };

            var servicetoken = new TokenService();
            Token stripetoken = await servicetoken.CreateAsync(optionstoken);

            var customer = new CustomerCreateOptions
            {
                Email = email,
                Name = name,
                Source = stripetoken.Id,
            };

            Console.WriteLine(" stripetoken attributes :" + stripetoken);

            var services = new CustomerService();
            var created = services.Create(customer);


            var option = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardCreateOptions
                {
                    Number = cardNumber,
                    ExpMonth = month,
                    ExpYear = year,
                    Cvc = cvv,
                },
            };

            var service = new PaymentMethodService();
            var result = service.Create(option);

            Console.WriteLine(" PaymentMethodService attributes :" + result);

            var options = new PaymentMethodAttachOptions
            {
                Customer = created.Id,
            };
            var method = new PaymentMethodService();
            method.Attach(
              result.Id,
              options
            );

            if (created.Id == null)
            {
                return "Failed";
            }
            else
            {
                return created.Id;
            }
        }

        public static ActionResult<List<Customer>> GetClientId(string email)
        {
            var options = new CustomerListOptions();
            var service = new CustomerService();
            StripeList<Customer> customers = service.List(
              options
            );

            List<Customer> userList = new List<Customer>();

            foreach (var c in customers)
            {
                if (c.Email == email)
                {
                    userList.Add(c);
                }
            }
            return userList;
        }

    }
    
}
