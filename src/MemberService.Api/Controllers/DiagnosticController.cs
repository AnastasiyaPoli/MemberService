using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MemberService.Api.Controllers
{
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;

        public DiagnosticController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                _environment.EnvironmentName
            });
        }
    }
}