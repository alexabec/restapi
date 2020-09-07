using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stripe;

namespace kwiqstage.Models
{
    public class MakePayment
    {
        public static async  Task<dynamic> PayAsync(int value, string currency, string stripeId)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = value,
                    Currency = currency,
                    Description = "TestChargeSarah",
                    Customer = stripeId
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    return charge.Id;
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception e)
            {
                
                return e.Message;
            }

        }

    }
}
