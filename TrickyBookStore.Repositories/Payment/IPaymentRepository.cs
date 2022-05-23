using System;

// KeepIt
namespace TrickyBookStore.Repositories.Payment
{
    public interface IPaymentRepository
    {
        double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate);
    }
}
