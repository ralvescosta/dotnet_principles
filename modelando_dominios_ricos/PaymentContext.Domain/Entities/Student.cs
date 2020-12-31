using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student: Entity
    {

        public Student(Name name, Document document, Email email)
        {
            AddNotifications(name, document, email);

            Name = name;
            Document = document;
            Email = email;
            _subscription = new List<Subscription>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        private IList<Subscription> _subscription;
        public IReadOnlyCollection<Subscription> Subscription { get { return _subscription.ToArray(); } }

        public void AddSubscription(Subscription subscription){

            //Cancela todas as outras assinaturas, e coloca esta como principal
            foreach (var sub in Subscription)
            {
                sub.Inactivate();
            }

            _subscription.Add(subscription);
        }
    }
}