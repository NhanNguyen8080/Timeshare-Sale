using BackendshareSale.Repo.Models;
using BackendTimeshareSale.Extensions;
using BackendTimeshareSale.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendTimeshareSale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        private const int offset = 1;

        [HttpGet]
        public async Task<ActionResult<BaseResponseWithPaging<User>>> GetAllUser()
        {
            var todoItems = await _userService.GetAllUser().ToListAsync();
            var totalCount = todoItems.Count;
            var totalPages = Math.Ceiling(totalCount / 10.0);
            if (todoItems == null || totalCount == 0)
            {
                return NotFound(new BaseResponseWithPaging<List<User>>
                {
                    status = "Failed",
                    message = "Not found any records!",
                    page = 0,
                    per_page = 10,
                    total = totalCount,
                    total_pages = totalPages,
                    data = null

                });
            }
            return Ok(new BaseResponseWithPaging<List<User>>
            {
                status = "OK",
                message = "Query Successfully!",
                page = 0,
                per_page = 10,
                total = totalCount,
                total_pages = totalPages,
                data = todoItems

            });
        }
    }
}
