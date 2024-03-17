using BackendTimeshareSale.Service.IServices;
using BackendTimeshareSale.Service.ServiceImp;
using Microsoft.AspNetCore.Mvc;

namespace BackendTimeshareSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestorController : ControllerBase
    {
        private readonly IInvestorService investorService;
        public InvestorController(IInvestorService investorService)
        {
            this.investorService = investorService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllInvestors()
        {
            int result = investorService.GetInvestorCount();

            return Ok(result);
        }
    }
}
