using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAttributeController : ControllerBase
    {
        private readonly ICustomerAttributeService _service;

        public CustomerAttributeController(ICustomerAttributeService service)
        {
            _service = service;
        }

        //api/CustomerAttribute?name=
        [HttpGet]
        public async Task<PagedList<CustomerAttributeModel>> getALl([FromQuery]CustomerSearch customerSearch)
        {
            var pagedList = await _service.GetAll(customerSearch);
            var items = pagedList.Items;
            var result = new PagedList<CustomerAttributeModel>(items.ToList(),
                pagedList.MetaData.TotalCount, pagedList.MetaData.CurrentPage, pagedList.MetaData.PageSize);
            return result;
        }

        [HttpGet("{id}")]
        public Task<CustomerAttributeModel> getOne(int id)
        {
            return _service.GetOne(id);
        }

        [HttpPost]
        public Task<bool> create([FromBody]CustomerAttributeModel request)
        {
            return _service.Create(request);
        }

        [HttpDelete("{id}")]
        public Task<bool> delete(int id)
        {
            return _service.Delete(id);
        }

        [HttpPut]
        public Task<bool> edit([FromBody]CustomerAttributeModel editCust)
        {
            return _service.Edit(editCust);
        }
    }
}
