﻿using BackendshareSale.Repo.Interfaces;
using BackendshareSale.Repo.Models;
using BackendshareSale.Repo.ViewModel;
using BackendTimeshareSale.Extensions;
using BackendTimeshareSale.Helper;
using BackendTimeshareSale.Service.IServices;
using BackendTimeshareSale.Service.ServiceImp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTimeshareSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeshareController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IUnitOfWork _unitOfWork;

        public TimeshareController(IPropertyService propertyService, IUnitOfWork unitOfWork)
        {
            _propertyService = propertyService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost()]
        [Route("/api/[controller]/insertDataToSQL")]
        public async Task<IActionResult> InsertData()
        {
            _propertyService.InsertDataToSQL();
            return Ok("Insert successully!");
        }

        [HttpPost()]
        [Route("/api/[controller]/indexDocument")]
        public async Task<IActionResult> IndexAsync()
        {
            var query = _unitOfWork.PropertyRepo.Get();
            //var result = query.ToList();
            var checkIndex = await _propertyService.IndexData(query);
            if (checkIndex)
            {
                return Ok("Saved successfully!");
            }
            return BadRequest("Index data failed!");
        }

        [HttpGet()]
        [Route("/api/[controller]/get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var document = _propertyService.GetById(id);
            return Ok(document);
        }

        [HttpGet()]
        [Route("/api/[controller]/getAll")]
        public async Task<IActionResult> Get()
        {
            var document = await _propertyService.GetAllProperties();
            return Ok(document);
        }

        [HttpGet()]
        [Route("/api/[controller]/getWithPaging")]
        public async Task<IActionResult> Get([FromQuery] int pageIndex, [FromQuery] int perPage)
        {
            var query = await _propertyService.GetAllProperties();
            var totalCount = query.ToList().Count;
            var totalPages = Math.Ceiling(totalCount / 10.0);
            var properties = query.ToPageList(pageIndex, perPage);
            if (properties == null || totalCount == 0)
            {
                return NotFound(new BaseResponseWithPaging<List<PropertyVM>>
                {
                    status = "Failed",
                    message = "Not found any records!",
                    page = pageIndex,
                    per_page = perPage,
                    total = totalCount,
                    total_pages = totalPages,
                    data = null

                });
            }
            return Ok(new BaseResponseWithPaging<IEnumerable<PropertyVM>>
            {
                status = "OK",
                message = "Query Successfully!",
                page = pageIndex,
                per_page = perPage,
                total = totalCount,
                total_pages = totalPages,
                data = properties,

            });
        }

        [HttpPost()]
        [Route("/api/[controller]/search")]
        public async Task<IActionResult> Get([FromQuery] string keyword)
        {
            var document = await _propertyService.SearchProperties(keyword);
            return Ok(document);
        }

        [HttpPost()]
        [Route("/api/[controller]/searchWithPaging")]
        public async Task<IActionResult> Get([FromQuery] string keyword, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var query = await _propertyService.SearchProperties(keyword);
            var totalCount = query.ToList().Count;
            var totalPages = Math.Ceiling(totalCount / 10.0);
            var properties = query.ToPageList(pageIndex, pageSize);

            if (properties == null || totalCount == 0)
            {
                return NotFound(new BaseResponseWithPaging<List<PropertyVM>>
                {
                    status = "Failed",
                    message = "Not found any records!",
                    page = pageIndex,
                    per_page = pageSize,
                    total = totalCount,
                    total_pages = totalPages,
                    data = null

                });
            }
            return Ok(new BaseResponseWithPaging<IEnumerable<PropertyVM>>
            {
                status = "OK",
                message = "Query Successfully!",
                page = pageIndex,
                per_page = pageSize,
                total = totalCount,
                total_pages = totalPages,
                data = properties,

            });
        }

    }
}
