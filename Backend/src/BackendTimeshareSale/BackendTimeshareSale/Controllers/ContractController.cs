using BackendTimeshareSale.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BackendTimeshareSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService contractService;
        public ContractController(IContractService contractService)
        {
            this.contractService = contractService;
        }
        [HttpGet]
        public async Task<ActionResult> GetContractAreSigned()
        {
            int result = contractService.GetContractsAreCompleted();

            return Ok(result);
        }
        [HttpGet("total/{month}")]
        public async Task<ActionResult> GetRevenueByMonth(int month)
        {
            decimal result = contractService.GetRevenueByMonth(month);

            return Ok(result);
        }
    }
}
