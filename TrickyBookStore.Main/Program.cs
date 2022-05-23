// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using TrickyBookStore.Main;
using TrickyBookStore.Services.Payment;
using TrickyBookStore.Repositories.Payment;
using TrickyBookStore.Repositories.Customers;
using TrickyBookStore.Repositories.PurchaseTransactions;
using TrickyBookStore.Repositories.Subscriptions;
using TrickyBookStore.Repositories.Books;



PaymentInjector paymentInjector = new PaymentInjector(new PaymentService( 
                                                            new PaymentRepository( 
                                                                new CustomerRepository( new SubscriptionRepository()),
                                                                new PurchaseTransactionRepository(new BookRepository()))));

Console.Write("Customer Id: ");
int customerId = Convert.ToInt32(Console.ReadLine());

Console.Write("Month: ");
int month = Convert.ToInt32(Console.ReadLine());

Console.Write("Year: ");
int year = Convert.ToInt32(Console.ReadLine());

DateTimeOffset fromDate = new DateTimeOffset(new DateTime(year, month, 1));
DateTimeOffset toDate = new DateTimeOffset(new DateTime(year, month, DateTime.DaysInMonth(year, month)));

double paymentAmount = paymentInjector.GetPaymentAmount(customerId, fromDate, toDate);
Console.Write("\n -> Payment Amount: {0}USD", paymentAmount);



