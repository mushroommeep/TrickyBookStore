using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Models;

namespace TrickyBookStore.Main
{
    public class PurchaseInjector
    {
        private IPurchaseTransactionService _purchaseTransactionService;
        public PurchaseInjector(IPurchaseTransactionService purchaseTransactionService)
        {
            _purchaseTransactionService = purchaseTransactionService;
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return _purchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);
            throw new NotImplementedException();
        }
    }
}
