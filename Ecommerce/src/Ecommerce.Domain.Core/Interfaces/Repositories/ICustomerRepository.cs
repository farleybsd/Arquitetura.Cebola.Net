﻿namespace Ecommerce.Domain.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        void Insert(Customer customer);

        void Update(Customer customer);

        void Delete(string id);

        IEnumerable<Customer> GetAll();

        Customer GetCustomer(string id);

        Customer? GetByEmail(string email);
    }
}