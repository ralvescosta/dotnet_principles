using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddSignature()
        {
            var student = new Student("Name", "Last", "123456789", "email@email.com");
            var subscription = new Subscription(null);
            student.AddSubscription(subscription);
        }
    }
}
