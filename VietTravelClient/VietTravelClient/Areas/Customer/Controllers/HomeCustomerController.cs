using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;
using Microsoft.AspNetCore.Http;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class HomeCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public HomeCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("home")]
        public async Task<IActionResult> Home()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCity = domainServer + "city";
            string urlTour = domainServer + "tour";
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTour.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseDataTour.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View()
;
                }
                return RedirectToAction("Error", new {area="Customer", controller="Home"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
        }

        [HttpGet]
        [Route("history")]
        public async Task<IActionResult> History(string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlUser = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = new ResponseData();
                responseData = await _callApi.GetApi(urlUser);
                if (responseData.Success)
                {
                    User user = JsonConvert.DeserializeObject<User>(responseData.Data);
                    string url = domainServer + "ticket/getTicketByUserId/" + user.Id;
                    ResponseData responseDataUser = await _callApi.GetApi(url);
                    ViewData["Tickets"] = JsonConvert.DeserializeObject<List<Ticket>>(responseDataUser.Data);
                    ViewData["Status"] = status;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            
            
        }

        [HttpGet]
        [Route("accountManager")]
        public async Task<IActionResult> AccountManager()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["User"] = JsonConvert.DeserializeObject<User>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View()
;
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        [Route("revenueStatisticsDetail")]
        public IActionResult RevenueStatisticsDetail()
        {
            return View();
        }

        [HttpGet]
        [Route("error")]
        public async Task<IActionResult> Error()
        {
            return View();
        }

    }
}
