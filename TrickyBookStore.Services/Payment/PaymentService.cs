using System;
using System.Linq;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Repositories.Payment;

namespace TrickyBookStore.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        IPaymentRepository PaymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return PaymentRepository.GetPaymentAmount(customerId, fromDate, toDate);
            throw new NotImplementedException();
        }
    }
}
