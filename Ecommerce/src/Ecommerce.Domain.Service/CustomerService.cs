
namespace Ecommerce.Domain.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void SaveCustomer(Customer customer)
        {
            ValidateEmail(customer.Email);
            customer.IsActive = true;
            customer.CreatedDate = DateTime.Now;
            customer.Address.IsActive= true;
            customer.Address.CreatedDate= DateTime.Now;
            _customerRepository.Insert(customer);
        }

        private void ValidateEmail(string email)
        {
            if (isEmailValid(email))
                throw new DuplicateEmailExeption(email);

            var existingCustomer = _customerRepository.GetByEmail(email);

            if (existingCustomer is not null)
                throw new DuplicateEmailExeption(email);
        }

        private bool isEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            try
            {
                var emailAddress = new MailAddress(email);

                if (emailAddress.Address != email) return false;
                return CheckDomainHasMxRecord(emailAddress.Host);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool CheckDomainHasMxRecord(string domaim)
        {
            try
            {
                var lookup = new LookupClient();
                var result = lookup.Query(domaim, QueryType.MX);
                return result.Answers.MxRecords().Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(string id)
        {
            _customerRepository.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
           return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(string id)
        {
            return _customerRepository.GetCustomer(id);
        }
    }
}