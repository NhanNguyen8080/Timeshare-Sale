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
        public async Task<ActionResult> GetContractUser()
        {
            int result = contractService.GetContractsAreCompleted();

            return Ok(result);
        }
    }
}
