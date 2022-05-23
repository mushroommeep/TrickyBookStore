using System;
using System.Linq;
using TrickyBookStore.Repositories.Books;
using TrickyBookStore.Repositories.Customers;
using TrickyBookStore.Repositories.PurchaseTransactions;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        ICustomerRepository CustomerRepository { get; }
        IPurchaseTransactionRepository PurchaseTransactionRepository { get; }

        public PaymentRepository(ICustomerRepository customerRepository, 
            IPurchaseTransactionRepository purchaseTransactionRepository)
        {
            CustomerRepository = customerRepository;
            PurchaseTransactionRepository = purchaseTransactionRepository;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            double totalAmount = 0;
            var customer = CustomerRepository.GetCustomerById(customerId);
            var purchases = PurchaseTransactionRepository.GetPurchaseTransactions(customerId, fromDate, toDate)
                                                            .OrderBy(x => x.CreatedDate);

            var subscriptions = customer.Subscriptions.OrderBy(x => x.Priority).ToList();
            var newBooks = new List<Book>();
            var oldBooks = new List<Book>();
            foreach(var purchase in purchases)
            {
                if(purchase.Book.IsOld)
                    oldBooks.Add(purchase.Book);
                else
                    newBooks.Add(purchase.Book);
            }

            totalAmount = GetSubscriptionPayment(subscriptions) + GetNewBooksPayment(subscriptions, newBooks) + GetOldBooksPayment(subscriptions, oldBooks);

            return totalAmount;
            throw new NotImplementedException();
        }

        private double GetNewBooksPayment(List<Subscription> subscriptions, List<Book> books)
        {
            double totalAmount = 0;

            if (!books.Any())
                return totalAmount;

            foreach (var subscription in subscriptions)
            {
                var subscriptionType = subscription.SubscriptionType;
                if (subscriptionType == SubscriptionTypes.CategoryAddicted)
                {
                    int bookLimit = 3;
                    foreach (var book in books.ToList())
                    {
                        if (bookLimit == 0)
                            break;
                        if(book.CategoryId == subscription.BookCategoryId)
                        {
                            totalAmount += book.Price - (book.Price * subscription.PriceDetails["NewBookDiscount"]);
                            books.Remove(book);
                            bookLimit--;
                        }
                    }
                }
                else if (subscriptionType == SubscriptionTypes.Premium)
                {
                    int bookLimit = 3;
                    foreach (var book in books.ToList())
                    {
                        if (bookLimit == 0)
                            break;
                        totalAmount += book.Price - (book.Price * subscription.PriceDetails["NewBookDiscount"]);
                        books.Remove(book);
                        bookLimit--;
                    }
                }
                else if (subscriptionType == SubscriptionTypes.Paid)
                {
                    int bookLimit = 3;
                    foreach (var book in books.ToList())
                    {
                        if (bookLimit == 0)
                            break;
                        totalAmount += book.Price - (book.Price * subscription.PriceDetails["NewBookDiscount"]);
                        books.Remove(book);
                        bookLimit--;
                    }
                }
                else if (subscriptionType == SubscriptionTypes.Free)
                {
                    foreach (var book in books.ToList())
                    {
                        totalAmount += book.Price;
                    }
                }
            }

            return totalAmount;
        }

        private double GetOldBooksPayment(List<Subscription> subscriptions, List<Book> books)
        {
            double totalAmount = 0;

            if(!books.Any())
                return totalAmount;

            foreach (var subscription in subscriptions)
            {
                var subscriptionType = subscription.SubscriptionType;
                if (subscriptionType == SubscriptionTypes.Premium)
                    return totalAmount;
                else if (subscriptionType == SubscriptionTypes.CategoryAddicted)
                {
                    foreach (var book in books.ToList())
                    {
                        if (book.CategoryId == subscription.BookCategoryId)
                        {
                            books.Remove(book);
                        }
                    }
                }
                else if (subscriptionType == SubscriptionTypes.Paid)
                {
                    foreach (var book in books.ToList())
                    {
                        totalAmount += book.Price * subscription.PriceDetails["OldBookCharge"];
                    }
                    return totalAmount;
                }
                else if (subscriptionType == SubscriptionTypes.Free)
                {
                    foreach (var book in books.ToList())
                    {
                        totalAmount += book.Price - (book.Price * subscription.PriceDetails["OldBookDiscount"]);
                    }
                    return totalAmount;
                }
            }

            return totalAmount;
        }

        private double GetSubscriptionPayment(List<Subscription> subscriptions)
        {
            double totalAmount = 0;

            foreach (var subscription in subscriptions)
            {
                totalAmount += subscription.PriceDetails["FixPrice"];

            }
            return totalAmount;
        }
    }
}
