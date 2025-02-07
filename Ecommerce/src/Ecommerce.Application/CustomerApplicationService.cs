namespace Ecommerce.Application
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper<CustomerDto, Customer> _mapperEntity;
        private readonly IMapper<Customer, CustomerDto> _mapperDto;

        public CustomerApplicationService(ICustomerService customerService,
                                          IMapper<CustomerDto, Customer> mapperEntity,
                                          IMapper<Customer, CustomerDto> mapperDto)
        {
            _customerService = customerService;
            _mapperEntity = mapperEntity;
            _mapperDto = mapperDto;
        }

        public void DeleteCustomer(string id)
        {
            _customerService.DeleteCustomer(id);
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customer = _customerService.GetAll();
            return _mapperDto.Map(customer);
        }

        public CustomerDto GetCustomerById(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            return _mapperDto.Map(customer);
        }

        public void SaveCustomer(CustomerDto customerDto)
        {
            var customer = _mapperEntity.Map(customerDto);
            _customerService.SaveCustomer(customer);
        }

        public void UpdateCustomer(CustomerDto customer)
        {
            var customerupdate = _mapperEntity.Map(customer);
            _customerService.SaveCustomer(customerupdate);
        }
    }
}
