using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Models;
using VietTravelClient.Models.WeatherModel;

namespace VietTravelClient.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string tokenAnonymous;
        private readonly string keyWeather;

        public WeatherController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            tokenAnonymous = _configuration["tokenAnonymous"];
            keyWeather = _configuration["KeyWeatherApi"];
        }

        [HttpGet]
        [Route("weatherOpen")]
        public async Task<IActionResult> Weather()
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?lat=20.73&lon=107.05&appid=e1a5c2e30fb63c7574678a5c27b029a9";
            try
            {
                ResponseData response = await _callApi.GetApi(url, tokenAnonymous);
                if (response.Success)
                {
                    WeatherOpen weatherOpen = JsonConvert.DeserializeObject<WeatherOpen>(response.Data);
                }
                else return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            return View();
        }
    }
}
