namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
       private readonly ICustomerApplicationService _customerApplicationService;

        public CustomersController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatedCustomer([FromBody] CustomerDto customerDto)
        {
            try
            {
                _customerApplicationService.SaveCustomer(customerDto);
            }
            catch (DuplicateEmailExeption ex)
            {

                return Conflict(ex.Message);
            }
            return Created("", customerDto);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = _customerApplicationService.GetAll();
            return Ok(customers);
        }

        [HttpGet("customers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomerById(string id)
        {
            var formattedCustomerId = Uri.UnescapeDataString(id);
            var customer = _customerApplicationService.GetCustomerById(formattedCustomerId);

            if (customer is null)
                return NotFound();
            else
                return Ok(customer);
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CustomerDto>> DeleteCustomerById(string id)
        {
            var formattedCustomerId = Uri.UnescapeDataString(id);
            _customerApplicationService.DeleteCustomer(formattedCustomerId);
            return NoContent();
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCustomer([FromBody]  CustomerDto customerDto)
        {
            try
            {
                _customerApplicationService.UpdateCustomer(customerDto);
            }
            catch (DuplicateEmailExeption ex)
            {

                return Conflict(ex.Message);
            }
            return NoContent(); 
        }
    }
}
