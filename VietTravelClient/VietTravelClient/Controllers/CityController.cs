using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnidecodeSharpCore;
using VietTravelClient.Common;
using VietTravelClient.Models;
using VietTravelClient.Models.WeatherModel;

namespace VietTravelClient.Controllers
{
    public class CityController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string keyWeather;
        private readonly string tokenAnonymous;

        public CityController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            keyWeather = _configuration["KeyWeatherApi"];
            tokenAnonymous = _configuration["tokenAnonymous"];
        }

        [HttpGet]
        [Route("cityDetail")]
        public async Task<IActionResult> CityDetail(string itemId, int page)
        {
            string urlEva = domainServer + "evaluate/evaCity/" + itemId; 
            string urlCity = domainServer + "city/" + itemId;
            string urlTour = domainServer + "tour/searchByCityId/" + itemId + "/" + page.ToString();
            string urlTotalPage = domainServer + "tour/searchByCityId/totalPage/" + itemId;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity, tokenAnonymous);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenAnonymous);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseDataCity.Success && responseDataTours.Success && responseDataTotalPage.Success && responseDataEva.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    string urlWeather = "https://api.openweathermap.org/data/2.5/weather?lat=" + city.CoordLat + "&lon=" + city.CoordLon + "&appid=" + keyWeather;
                    ResponseData responseDataWeather = await _callApi.GetApi(urlWeather, tokenAnonymous);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
                    ViewData["Evaluates"] = evaluates;
                    ViewData["CurrentPage"] = page;
                    if (responseDataWeather.Data != null) ViewData["Weather"] = JsonConvert.DeserializeObject<WeatherOpen>(responseDataWeather.Data);
                    else ViewData["Weather"] = new List<WeatherOpen>();
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    return View();
                }
                return RedirectToAction("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        //Search với Id của City
        [HttpPost]
        [Route("searchCityDetailPost")]
        public async Task<IActionResult> SearchCityDetailPost(string itemId, int page)
        {
            return RedirectToAction("SearchCityDetail", new { controller = "City", itemId = itemId, page = page });
        }

        [HttpGet]
        [Route("searchCityDetail")]
        public async Task<IActionResult> SearchCityDetail(string itemId, int page)
        {
            string urlEva = domainServer + "evaluate/evaCity/" + itemId;
            string urlCity = domainServer + "city/" + itemId;
            string urlTour = domainServer + "tour/searchByCityId/" + itemId + "/" + page.ToString();
            string urlTotalPage = domainServer + "tour/searchByCityId/totalPage/" + itemId;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity, tokenAnonymous);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenAnonymous);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseDataCity.Success && responseDataTours.Success && responseDataTotalPage.Success && responseDataEva.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    string urlWeather = "https://api.openweathermap.org/data/2.5/weather?lat=" + city.CoordLat + "&lon=" + city.CoordLon + "&appid=" + keyWeather;
                    ResponseData responseDataWeather = await _callApi.GetApi(urlWeather, tokenAnonymous);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
                    ViewData["Evaluates"] = evaluates;
                    ViewData["CurrentPage"] = page;
                    if (responseDataWeather.Data != null) ViewData["Weather"] = JsonConvert.DeserializeObject<WeatherOpen>(responseDataWeather.Data);
                    else ViewData["Weather"] = new List<WeatherOpen>();
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    return View();
                }
                return RedirectToAction("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        [Route("cityManager")]
        public async Task<IActionResult> CityManager(int page)
        {
            string url = domainServer + "city/page/" + page.ToString();
            string urlTotalPage = domainServer + "city/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseData.Data);
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
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

        //Search với từ khóa là tên của City
        [HttpPost]
        [Route("searchCityPost")]
        public async Task<IActionResult> SearchCityPost(string searchValue, int page)
        {
            return RedirectToAction("SearchCity", new { controller = "City", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchCity")]
        public async Task<IActionResult> SearchCity(string searchValue, int page)
        {
            string url = domainServer + "city/search/" + searchValue + "/" + page.ToString();
            string urlTotalPage = domainServer + "city/search/totalPage/" + searchValue.Unidecode();
            List<City> cities = new List<City>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    string result = responseData.Data;
                    cities = JsonConvert.DeserializeObject<List<City>>(result);
                    ViewData["cities"] = cities;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["SearchValue"] = searchValue;
                    return View();
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
