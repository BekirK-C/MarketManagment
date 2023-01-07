using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HCustomersController : ControllerBase
    {
        IHermasoService _hermasoService;

        public HCustomersController(IHermasoService hermasoService)
        {
            _hermasoService = hermasoService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _hermasoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _hermasoService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
