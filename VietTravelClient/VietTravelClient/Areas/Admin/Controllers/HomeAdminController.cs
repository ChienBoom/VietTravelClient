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

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HomeAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public HomeAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("home")]
        public async Task<IActionResult> Home(string UsernameAccount)
        {
            string urlCity = domailServer + "city";
            string urlTour = domailServer + "tour";
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTour.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseDataTour.Data);
                    ViewData["UsernameAccount"] = UsernameAccount;
                    return View()
;
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [Route("revenueStatisticsDetail")]
        public IActionResult RevenueStatisticsDetail()
        {
            return View();
        }

    }
}
