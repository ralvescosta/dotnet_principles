using System;

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
        string document, 
        string address, 
        string email) : base(numero, paidDate, expireDate, total, totalPaid, payer, document, address, email)
      {
        TransactionCode = transactionCode;
      }

      public string TransactionCode { get; private set; }
      }
}