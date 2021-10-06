using Microsoft.AspNetCore.Mvc;
using Pagination.Context;
using Pagination.Filter;
using Pagination.Helpers;
using Pagination.Models;
using Pagination.Services;
using Pagination.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace Pagination.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CRMContext _context;
        private readonly IUriService _uriService;

        public CustomersController(CRMContext context, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;
        }

        [HttpGet]
        public ActionResult<PagedResponse<IReadOnlyList<Customer>>> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);            
            var customers = _context.customers
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            var totalRecords = _context.customers.Count();

            var response = PaginationHelper.CreatePagedResponse<Customer>(customers, validFilter, totalRecords, _uriService, route);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Customer>> GetById(int id)
        {
            var customer = _context.customers.Find(id);

            return Ok(new Response<Customer>(customer));
        }
    }
}
