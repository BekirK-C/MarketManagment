using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SCustomersController : ControllerBase
    {
        ISiempreService _siempreService;

        public SCustomersController(ISiempreService siempreService)
        {
            _siempreService = siempreService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _siempreService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _siempreService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
