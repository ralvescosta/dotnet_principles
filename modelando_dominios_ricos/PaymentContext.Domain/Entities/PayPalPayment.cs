using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
  public class PayPalPayment : Payment
  {
    public PayPalPayment(
      string transactionCode,
      string numero,
      DateTime paidDate,
      DateTime expireDate,
      decimal total,
      decimal totalPaid,
      string payer,
      Document document,
      Address address,
      Email email) : base(numero, paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
      TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
  }
}