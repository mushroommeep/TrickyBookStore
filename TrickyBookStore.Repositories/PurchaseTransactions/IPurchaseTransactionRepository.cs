using System;
using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.PurchaseTransactions
{
    // KeepIt
    public interface IPurchaseTransactionRepository
    {
        IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate);
    }
}
