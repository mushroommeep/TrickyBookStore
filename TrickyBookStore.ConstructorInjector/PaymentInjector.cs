using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Services.Payment;
using TrickyBookStore.Models;

namespace TrickyBookStore.Main
{
    public class PaymentInjector
    {
        private IPaymentService _paymentService;
        public PaymentInjector(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return _paymentService.GetPaymentAmount(customerId, fromDate, toDate);
            throw new NotImplementedException();
        }
    }
}
