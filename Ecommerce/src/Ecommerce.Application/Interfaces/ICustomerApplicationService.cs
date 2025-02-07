namespace Ecommerce.Application.Interfaces
{
    public interface ICustomerApplicationService
    {
        void SaveCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(string id);
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetCustomerById(string id);
    }
}
