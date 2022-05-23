using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.PurchaseTransactions;

namespace TrickyBookStore.Services.PurchaseTransactions
{
    public class PurchaseTransactionService : IPurchaseTransactionService
    {
        IPurchaseTransactionRepository PurchaseTransactionRepository { get; }

        public PurchaseTransactionService(IPurchaseTransactionRepository purchaseTransactionRepository)
        {
            PurchaseTransactionRepository = purchaseTransactionRepository;
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return PurchaseTransactionRepository.GetPurchaseTransactions(customerId, fromDate, toDate);
            throw new NotImplementedException();
        }
    }
}
