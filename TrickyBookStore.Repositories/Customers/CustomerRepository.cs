using System;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Subscriptions;

namespace TrickyBookStore.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        ISubscriptionRepository SubscriptionRepository { get; }

        public CustomerRepository(ISubscriptionRepository subscriptionRepository)
        {
            SubscriptionRepository = subscriptionRepository;
        }

        public Customer GetCustomerById(long id)
        {
            var customerStore = Store.Customers.Data;
            var customer = customerStore.Where(x => id == x.Id).FirstOrDefault();
            if (customer != null)
            {
                var subscriptionIds = customer.SubscriptionIds;
                subscriptionIds.Add(2);
                var subscriptions = SubscriptionRepository.GetSubscriptions(subscriptionIds.ToArray());
                customer.Subscriptions = subscriptions.Where(x => customer.SubscriptionIds.Contains(x.Id)).ToList();
            }
            return customer;
            throw new NotImplementedException();
        }
    }
}
