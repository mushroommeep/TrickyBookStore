using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Books;

namespace TrickyBookStore.Repositories.PurchaseTransactions
{
    public class PurchaseTransactionRepository : IPurchaseTransactionRepository
    {
        IBookRepository BookRepository { get; }

        public PurchaseTransactionRepository(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var purchaseStore = Store.PurchaseTransactions.Data;
            var purchases = purchaseStore.Where(x => customerId == x.CustomerId && fromDate <= x.CreatedDate && x.CreatedDate <= toDate);
            if (purchases.Any())
            {
                foreach(var purchase in purchases)
                {
                    var bookId = purchase.BookId;
                    var book = BookRepository.GetBooks(bookId);
                    purchase.Book = book.FirstOrDefault();
                }
            }
            return purchases.ToList();
            throw new NotImplementedException();
        }
    }
}
