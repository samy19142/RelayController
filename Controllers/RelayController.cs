using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relay_controller_app.Interfaces;
using Relay_controller_app.Models;

namespace Relay_controller_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelayController : ControllerBase
    {

        private readonly IRelayService _relayService;
        private readonly ILogger<RelayController> _logger;

        public RelayController(IRelayService relayService, ILogger<RelayController> logger)
        {
            _relayService = relayService;
            _logger = logger;
        }

        [HttpGet]
        [Route("listAll")]
        public IActionResult Get()
        {
            return Ok(
                _relayService.GetAllRelaysAsync()
                );
        }

        [HttpPost]
        [Route("{id}/status")]

        public IActionResult Post(int id,bool status) {
            try {
                var resultado = _relayService.SetRelayStatusAsync(id, status);
                return Ok(
               resultado
                );

            } catch (Exception ex) {
                _logger.LogError($"{ex.Message} Error in controller");
                return BadRequest(ex.Message );
            }
            
            
        }


    }
}
