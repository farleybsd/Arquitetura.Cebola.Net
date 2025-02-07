namespace Ecommerce.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDocumentStore _documentStore;

        public CustomerRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Delete(string id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var customer = documentSession.Load<Customer>(id);

            if (customer is not null)
            {
                documentSession.Delete(customer);
                documentSession.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            return documentSession.Query<Customer>().ToList();
        }

        public Customer? GetByEmail(string email)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();

            var customerEntity = documentSession.Query<Customer>().FirstOrDefault(c => c.Email == email);

            if (customerEntity is not null) return customerEntity;

            return null;
        }

        public Customer GetCustomer(string id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            return documentSession.Load<Customer>(id);
        }

        public void Insert(Customer customer)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            documentSession.Store(customer);
            documentSession.SaveChanges();
        }

        public void Update(Customer customer)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var customerEntity = documentSession.Query<Customer>().FirstOrDefault(c => c.Name == customer.Name);

            if (customerEntity is not null)
            {
                customerEntity.Name = customer.Name;
                customerEntity.LastName = customer.LastName;
                customerEntity.Email = customer.Email;
                customerEntity.BirthDate = customer.BirthDate;
                customerEntity.Address = customer.Address;
                customerEntity.Cpf = customer.Cpf;
                customerEntity.IsActive = true;
            }

            documentSession.SaveChanges();
        }
    }
}