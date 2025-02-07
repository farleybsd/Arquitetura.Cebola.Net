namespace Ecommerce.Domain.Core.Extensions
{
    public class DuplicateEmailExeption : Exception
    {
        public DuplicateEmailExeption(string email) : base($"Email {email} ja esta em unso")
        {
        }
    }
}