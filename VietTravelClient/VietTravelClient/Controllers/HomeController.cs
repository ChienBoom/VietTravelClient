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
        private readonly string domainServer;

        public HomeController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        //[HttpGet]
        //[Route("/home")]
        public async Task<IActionResult> Home()
        {
            string urlCity = domainServer + "city";
            string urlTour = domainServer + "tour";
            string urlHotCity = domainServer + "city/hotCity";
            string urlHotTour = domainServer + "tour/hotTour";
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                ResponseData responseHotCity = await _callApi.GetApi(urlHotCity);
                ResponseData responseHotTour = await _callApi.GetApi(urlHotTour);
                if(responseDataCity.Success && responseDataTour.Success && responseHotCity.Success && responseHotTour.Success)
                {

                    List<City> cities = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    List<Tour> tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTour.Data);
                    ViewData["Cities"] = cities.OrderByDescending(o => o.Name).ToList();
                    ViewData["Tours"] = tours.OrderByDescending(o => o.NumberOfEvaluate).ToList();
                    List <City> hotCity = JsonConvert.DeserializeObject<List<City>>(responseHotCity.Data);
                    List<Tour> hotTour = JsonConvert.DeserializeObject<List<Tour>>(responseHotTour.Data);
                    ViewData["HotCities"] = hotCity;
                    ViewData["HotTours"] = hotTour;
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
