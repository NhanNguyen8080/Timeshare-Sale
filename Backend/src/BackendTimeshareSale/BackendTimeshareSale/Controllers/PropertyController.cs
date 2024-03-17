using BackendTimeshareSale.Service.IServices;
using BackendTimeshareSale.Service.ServiceImp;
using Microsoft.AspNetCore.Mvc;

namespace BackendTimeshareSale.Controllers 
{ 

    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProperties()
        {
            int result = propertyService.GetAllOfProperties();

            return Ok(result);
        }
        [HttpGet("Available/Percent/{month}")]
        public async Task<ActionResult> GetPercentOfAvailableProperties(int month)
        {
            double result = propertyService.PercentOfAvailableProperty(month);

            return Ok(result);
        }
        [HttpGet("Booking/Percent/{month}")]
        public async Task<ActionResult> GetPercentOfBookingProperties(int month)
        {
            double result = propertyService.PercentOfBookingProperty(month);

            return Ok(result);

        }
        [HttpGet("Booking/{month}")]
        public async Task<ActionResult> GetNumberOfBookingProperties(int month)
        {
            double result = propertyService.NumberOfPropertiesAreBooking(month);

            return Ok(result);
        }
        [HttpGet("Available/{month}")]
        public async Task<ActionResult> GetNumberOfAvailableProperties(int month)
        {
            double result = propertyService.NumberOfPropertiesAreAvailable(month);

            return Ok(result);
        }
    }
}
