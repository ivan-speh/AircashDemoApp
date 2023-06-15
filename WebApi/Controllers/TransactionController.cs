using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public TransactionController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Initiate()
        {
            return Ok();
        }

    }
}
