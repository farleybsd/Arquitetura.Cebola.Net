namespace Ecommerce.Application.Mappers
{
    public class CustomerMapper : IMapper<Customer, CustomerDto>, IMapper<CustomerDto, Customer>
    {
        public CustomerDto Map(Customer source)
        {
            return new CustomerDto
            {
                Name = source.Name,
                LastName = source.LastName,
                Email = source.Email,
                BirthDate = source.BirthDate,
                Address = new AddressDto
                {
                    Street = source.Address.Street,
                    Number = source.Address.Number,
                    Complement = source.Address.Complement,
                    City = source.Address.City,
                    State = source.Address.State,
                    PostalCode = source.Address.PostalCode,
                },
                Cpf = source.Cpf,
            };
        }

        public IEnumerable<CustomerDto> Map(IEnumerable<Customer> source)
        {
            foreach (var item in source)
            {
                yield return Map(item);
            }
        }

        public Customer Map(CustomerDto source)
        {
            return new Customer
            {
                Name = source.Name,
                LastName = source.LastName,
                Email = source.Email,
                BirthDate = source.BirthDate,
                Address = new Address
                {
                    Street = source.Address.Street,
                    Number = source.Address.Number,
                    Complement = source.Address.Complement,
                    City = source.Address.City,
                    State = source.Address.State,
                    PostalCode = source.Address.PostalCode,
                },
                Cpf = source.Cpf,
            };
        }

        public IEnumerable<Customer> Map(IEnumerable<CustomerDto> source)
        {
            foreach (var item in source)
            {
                yield return Map(item);
            }
        }
    }
}