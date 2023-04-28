using Microsoft.AspNetCore.Mvc;
using Paviza_Zapocet.Data.Model;
using Paviza_Zapocet.Filters;
using Paviza_Zapocet.Services;
using Paviza_Zapocet.Services.Interfaces;

namespace Paviza_Zapocet.Controllers
{

    [ApiController]
    [Route("Data")]
    public class ClientDataController : Controller
    {

        IClientDataService _clientDataService;
        public ClientDataController(IClientDataService clientDataService)
        {
            _clientDataService = clientDataService;
        }

        [IdentityFilter]
        [HttpPost]
        [Route("Add")]
        public IActionResult PostData(List<ClientDataDto> ClientDataDto)
        {
            return Ok(_clientDataService.AddClientData(ClientDataDto));
        }

        [IdentityFilter]
        [HttpGet]
        [Route("Get")]
        public IActionResult GetData()
        {
            return Ok(_clientDataService.GetClientData());
        }
    }
}
