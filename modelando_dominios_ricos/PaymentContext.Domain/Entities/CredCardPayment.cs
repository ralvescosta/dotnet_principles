using System;

namespace PaymentContext.Domain.Entities
{
  public class CredCardPayment : Payment
    {
      public CredCardPayment(
        string cardHolderName, 
        string cardNumber, 
        string lastTransactionNumber,
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
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
      }

      public string CardHolderName { get; private set; }
          public string CardNumber { get; private set; }
          public string LastTransactionNumber { get; private set; }
      }
}