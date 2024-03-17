using BackendTimeshareSale.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BackendTimeshareSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            int result = _customerService.GetCustomerCount();

            return Ok(result);
        }
    }
}
