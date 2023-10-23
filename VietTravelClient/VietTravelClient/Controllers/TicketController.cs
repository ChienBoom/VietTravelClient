using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VietTravelClient.Common;
using VietTravelClient.Models;

namespace VietTravelClient.Controllers
{
    public class TicketController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public TicketController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpPost]
        [Route("saveTicket")]
        public IActionResult SaveTicket(TourPackage tourPackage)
        {
            return View();
        }

    }
}
