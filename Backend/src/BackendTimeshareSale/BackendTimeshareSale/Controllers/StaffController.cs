using BackendTimeshareSale.Service.IServices;
using BackendTimeshareSale.Service.ServiceImp;
using Microsoft.AspNetCore.Mvc;

namespace BackendTimeshareSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService staffService;
        public StaffController(IStaffService staffService)
        {
            this.staffService = staffService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllStaffs()
        {
            int result = staffService.GetStaffCount();

            return Ok(result);
        }
    }
}
