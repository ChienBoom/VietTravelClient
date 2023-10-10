﻿using Microsoft.AspNetCore.Mvc;
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
            string urlCity = domailServer + "city/" + cityId;
            string urlTour = domailServer + "tour/searchByCityId/" + cityId;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTours.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
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
            string urlCity = domailServer + "city/" + searchCitySelect;
            string urlTour = domailServer + "tour/searchByCityId/" + searchCitySelect;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTours.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
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
        public async Task<IActionResult> CityManager()
        {
            string url = domailServer + "city";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseData.Data);
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
        [Route("searchCity")]
        public async Task<IActionResult> SearchCity(string searchValue)
        {
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("CityManager");
            string url = domailServer + "city/search/" + searchValue;
            List<City> cities = new List<City>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                string result = responseData.Data;
                cities = JsonConvert.DeserializeObject<List<City>>(result);
                ViewData["cities"] = cities;
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}
