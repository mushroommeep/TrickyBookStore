using System;
using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Subscriptions;

namespace TrickyBookStore.Services.Subscriptions
{
    public class SubscriptionService : ISubscriptionService
    {
        ISubscriptionRepository SubscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            SubscriptionRepository = subscriptionRepository;
        }
        public IList<Subscription> GetSubscriptions(params int[] ids)
        {
            return SubscriptionRepository.GetSubscriptions(ids);    
            throw new NotImplementedException();
        }
    }
}
