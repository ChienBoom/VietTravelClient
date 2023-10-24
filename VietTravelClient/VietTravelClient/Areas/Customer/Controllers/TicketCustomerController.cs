using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class TicketCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public TicketCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpPost]
        [Route("saveTicket")]
        public async Task<IActionResult> SaveTicket(string tourPackageId)
        {
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = new ResponseData();
                responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    User user = JsonConvert.DeserializeObject<User>(responseData.Data);
                    Ticket ticket = new Ticket();
                    ticket.UserId = user.Id;
                    ticket.TourPackageId = long.Parse(tourPackageId);
                    ticket.BookingDate = DateTime.Now;
                    string urlTicket = domainServer + "ticket";
                    string stringTicket = JsonConvert.SerializeObject(ticket);
                    ResponseData responseDataTicket = await _callApi.PostApi(urlTicket, stringTicket);
                    if(responseDataTicket.Success)
                    {
                        return RedirectToAction("History", new {area = "Customer", controller= "HomeCustomer", status = 1 });
                    }
                    return RedirectToAction("TourDetail", new {area = "Customer", controller="TourCustomer", status = 2});
                }
                return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 2 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 3 });
            }
        }
    }
}
