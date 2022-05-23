using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Subscriptions
{
    public interface ISubscriptionRepository
    {
        IList<Subscription> GetSubscriptions(params int[] ids);
    }
}
