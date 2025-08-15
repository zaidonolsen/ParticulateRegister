using Microsoft.AspNetCore.Mvc;
using ParticulateRegister.Contracts.Enums;

namespace ParticulateRegister.Server.Controllers
{
    [ApiController]
    [Route("api/enums")]
    public class EnumsController : ControllerBase
    {
        [HttpGet("particulate-types")]
        public IActionResult GetParticulateTypes()
        {
            var types = Enum.GetNames(typeof(ParticulateType));
            return Ok(types);
        }

        [HttpGet("detection-statuses")]
        public IActionResult GetDetectionStatuses()
        {
            var statuses = Enum.GetNames(typeof(DetectionStatus));
            return Ok(statuses);
        }
    }
}
