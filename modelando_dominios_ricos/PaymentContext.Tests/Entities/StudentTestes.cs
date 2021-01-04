using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class StudentTests
  {

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
      var name = new Name("Bruce", "Waybe");
      var document = new Document("12345678910", EDocumentType.CPF);
      var email = new Email("email@email.com");
      var address = new Address("street 1", "number 1", "neighborhood 1", "city 1", "country 1", "zipCode 1");
      var student = new Student(name, document, email); ;
      var subscription = new Subscription(null);

      var payment = new PayPalPayment("12345678", "", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Coporation", document, address, email);

      subscription.AddPayment(payment);
      student.AddSubscription(subscription);
      student.AddSubscription(subscription);

      Assert.IsTrue(student.Invalid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscriptionHasNoPayment()
    {
      var name = new Name("Bruce", "Waybe");
      var document = new Document("12345678910", EDocumentType.CPF);
      var email = new Email("email@email.com");
      var address = new Address("street 1", "number 1", "neighborhood 1", "city 1", "country 1", "zipCode 1");
      var student = new Student(name, document, email); ;
      var subscription = new Subscription(null);

      student.AddSubscription(subscription);
      Assert.IsTrue(student.Invalid);
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
      var name = new Name("Bruce", "Waybe");
      var document = new Document("12345678910", EDocumentType.CPF);
      var email = new Email("email@email.com");
      var address = new Address("street 1", "number 1", "neighborhood 1", "city 1", "country 1", "zipCode 1");
      var student = new Student(name, document, email); ;
      var subscription = new Subscription(null);

      var payment = new PayPalPayment("12345678", "", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Coporation", document, address, email);

      subscription.AddPayment(payment);
      student.AddSubscription(subscription);

      Assert.IsTrue(student.Valid);
    }
  }
}
