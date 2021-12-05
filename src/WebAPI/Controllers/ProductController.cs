using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Process()
        {
            var response = await _service.Proccess();
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
