using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(firstName))
                AddNotification("Name.FirstName", "Nome invalido");
            
            FirstName = firstName;
            LastName = lastName;

            
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}