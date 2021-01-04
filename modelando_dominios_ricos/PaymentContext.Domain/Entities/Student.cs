using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
  public class Student : Entity
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

    public void AddSubscription(Subscription subscription)
    {

      var hasSubscriptionActive = false;
      foreach (var sub in _subscription)
      {
        if (sub.Active)
          hasSubscriptionActive = true;
      }

      AddNotifications(new Contract().Requires()
          .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Voce ja tem uma assinatura ativa")
          .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
      );

      if (Invalid)
      {
        return;
      }

      _subscription.Add(subscription);
    }
  }
}