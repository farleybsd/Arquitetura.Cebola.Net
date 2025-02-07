namespace Ecommerce.Domain.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
        IEnumerable<Customer> GetAll();
        Customer GetCustomerById(string id);
    }
}