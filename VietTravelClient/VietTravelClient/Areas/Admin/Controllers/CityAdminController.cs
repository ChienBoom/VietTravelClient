using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VietTravelClient.Controllers;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class CityAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public CityAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("addCity")]
        public IActionResult AddCity()
        {
            return View();
        }

        [HttpGet]
        [Route("cityManager")]
        public IActionResult CityManager()
        {
            return View();
        }

        [HttpPost]
        [Route("searchCityTourDetail")]
        public async Task<IActionResult> SearchCityTourDetail(string searchCitySelect, string UsernameAccount)
        {
            string url = domailServer + "search/" + searchCitySelect;
            City city = new City();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                string result = responseData.Data;
                city = JsonConvert.DeserializeObject<City>(result);
                ViewData["UsernameAccount"] = UsernameAccount;
                ViewData["CityTourDetail"] = city;
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}
