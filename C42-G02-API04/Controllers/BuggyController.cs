using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C42_G02_API04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly StoreDbContext _context;
        public BuggyController(StoreDbContext context)
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public async Task<IActionResult> GetNotFoundRequestErorr()
        {
            var brand = await _context.Brands.FindAsync(100);
            if (brand == null) return NotFound(new ApiErorrResponse(404,"brand with Id:100"));
            return Ok(brand);
        }

        [HttpGet("servererorr")]
        public async Task<IActionResult> GetServerErorr()
        {
            var brand = await _context.Brands.FindAsync(100);
            var brandToString =brand.ToString();
            return Ok(brand);
        }
        [HttpGet("badrequest")]
        public async Task<IActionResult> GetBadRequestErorr(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ApiErorrResponse(400)); }  
        }
        [HttpGet("unaithorized")]
        public async Task<IActionResult> GetErorr(int id)
        {
            return Unauthorized();
        }
    }
}
