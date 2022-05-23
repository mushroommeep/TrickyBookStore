using System;
using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Subscriptions
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public IList<Subscription> GetSubscriptions(params int[] ids)
        {
            var subscriptionStore = Store.Subscriptions.Data;
            var subscriptions = subscriptionStore.Where(x => ids.Contains(x.Id));
            return subscriptions.ToList();
            throw new NotImplementedException();
        }
    }
}
