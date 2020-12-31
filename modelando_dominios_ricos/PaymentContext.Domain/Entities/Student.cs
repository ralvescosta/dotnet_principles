using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {

    public Student(string firstName, string lastName, string document, string email)
    {
      FirstName = firstName;
      LastName = lastName;
      Document = document;
      Email = email;
      _subscription = new List<Subscription>();
    }

    public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
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