using LearningNRules;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules
{
    public class DicsountNotificationRule : Rule
    {
        public override void Define()
        {
            Customer customer = null;

            When()
                .Match<Customer>(() => customer)
                .Exists<Order>(o => o.Customer == customer, o => o.PercentDiscount > 0.0);

            Then()
                .Do(_ => customer.NotifyAboutDiscount());
        }
    }
}
