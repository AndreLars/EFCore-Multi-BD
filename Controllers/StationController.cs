using Microsoft.AspNetCore.Mvc;
using EFCore_Multi_BD.Interfaces.Entity;
using System.Threading.Tasks;
using EFCore_Multi_BD.Input;

namespace EFCore_Multi_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationDomainService _stationDomainService;
        public StationController(
            IStationDomainService stationDomainService
        )
        {
            _stationDomainService = stationDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] StationInput input)
        {
            var station = await _stationDomainService
                                    .InsertAsync(input)
                                    .ConfigureAwait(false);

            return Created("", station);
        }
    }
}