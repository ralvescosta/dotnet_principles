using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
  [TestClass]
  public class DocumentTests
  {
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJWillInvalid()
    {
      var doc = new Document("123", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Invalid);

    }

    [TestMethod]
    public void ShouldReturnErrorWhenCNPJWillValid()
    {
      var doc = new Document("34110406800015", EDocumentType.CNPJ);
      Assert.IsTrue(doc.Valid);

    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFWillInvalid()
    {
      var doc = new Document("123", EDocumentType.CPF);
      Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFWillValid()
    {
      var doc = new Document("12345678910", EDocumentType.CPF);
      Assert.IsTrue(doc.Valid);

    }
  }
}
