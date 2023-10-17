using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Models;

namespace VietTravelClient.Controllers
{
    public class CityController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public CityController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("cityDetail")]
        public async Task<IActionResult> CityDetail(string cityId)
        {
            string urlEva = domailServer + "evaluate/evaCity/" + cityId; 
            string urlCity = domailServer + "city/" + cityId;
            string urlTour = domailServer + "tour/searchByCityId/" + cityId;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTours.Success && responseDataEva.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
                    ViewData["Evaluates"] = evaluates;
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
        [Route("searchCityDetail")]
        public async Task<IActionResult> SearchCityDetail(string searchCitySelect)
        {
            string urlEva = domailServer + "evaluate/evaCity/" + searchCitySelect;
            string urlCity = domailServer + "city/" + searchCitySelect;
            string urlTour = domailServer + "tour/searchByCityId/" + searchCitySelect;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTours.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
                    ViewData["Evaluates"] = evaluates;
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
            string url = domailServer + "city/page/" + page.ToString();
            string urlTotalPage = domailServer + "city/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
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
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("CityManager");
            string url = domailServer + "city/search/" + searchValue + "/" + page.ToString();
            string urlTotalPage = domailServer + "search/totalPage" + searchValue;
            List<City> cities = new List<City>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
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
                return View();
            }
        }

    }
}
