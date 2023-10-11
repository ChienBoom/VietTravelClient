using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Models;

namespace VietTravelClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public HomeController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
        }

        //[HttpGet]
        //[Route("/home")]
        public async Task<IActionResult> Home()
        {
            string urlCity = domailServer + "city";
            string urlTour = domailServer + "tour";
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                if(responseDataCity.Success && responseDataTour.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseDataTour.Data);
                    return View()
;                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
