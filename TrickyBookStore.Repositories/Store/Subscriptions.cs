using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Store
{
    public static class Subscriptions
    {
        public static readonly IEnumerable<Subscription> Data = new List<Subscription>
        {
            new Subscription { Id = 1, SubscriptionType = SubscriptionTypes.Paid, Priority = 5,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 50 },
                    { "OldBookCharge", 0.05},
                    { "NewBookDiscount", 0.05}
                }
            },
            new Subscription { Id = 2, SubscriptionType = SubscriptionTypes.Free, Priority = 6,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 0 },
                    { "OldBookDiscount", 0.1 },
                    { "NewBookDiscount", 0}
                }
            },
            new Subscription { Id = 3, SubscriptionType = SubscriptionTypes.Premium, Priority = 4,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 200 },
                    { "OldBookCharge", 0 },
                    { "NewBookDiscount", 0.15}
                }
            },
            new Subscription { Id = 4, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 1,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 75 },
                    { "OldBookCharge", 0 },
                    { "NewBookDiscount", 0.15}
                },
                BookCategoryId = 4
            },
            new Subscription { Id = 5, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 2,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 75 },
                    { "OldBookCharge", 0 },
                    { "NewBookDiscount", 0.15}
                },
                BookCategoryId = 1
            },
            new Subscription { Id = 6, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    { "FixPrice", 75 },
                    { "OldBookCharge", 0 },
                    { "NewBookDiscount", 0.15}
                },
                BookCategoryId = 3
            }
        };
    }
}
