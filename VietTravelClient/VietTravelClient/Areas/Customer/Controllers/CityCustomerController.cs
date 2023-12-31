﻿using Microsoft.AspNetCore.Mvc;
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
using UnidecodeSharpCore;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class CityCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public CityCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
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
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCity = domailServer + "city/" + cityId;
            string urlEva = domailServer + "evaluate/evaCity/" + cityId;
            string urlTour = domailServer + "tour/searchByCityId/" + cityId;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva);
                if (responseDataCity.Success && responseDataTours.Success && responseDataEva.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
                    ViewData["Evaluates"] = evaluates;
                    ViewData["UsernameAccount"] = usernameAccount;
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
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCity = domailServer + "city/" + searchCitySelect;
            string urlTour = domailServer + "tour/searchByCityId/" + searchCitySelect;
            string urlEva = domailServer + "evaluate/evaCity/" + searchCitySelect;
            City city = new City();
            List<Tour> tours = new List<Tour>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTours = await _callApi.GetApi(urlTour);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva);
                if (responseDataCity.Success && responseDataTours.Success && responseDataEva.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseDataCity.Data);
                    tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    ViewData["City"] = city;
                    ViewData["Tours"] = tours;
                    ViewData["Evaluates"] = evaluates;
                    ViewData["UsernameAccount"] = usernameAccount;
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
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domailServer + "city/page/" + page.ToString();
            string urlTotalPage = domailServer + "city/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
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
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchCity", new { area = "Customer", controller = "CityCustomer", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchCity")]
        public async Task<IActionResult> SearchCity(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            //if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("CityManager");
            string url = domailServer + "city/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domailServer + "search/totalPage" + searchValue.Unidecode();
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
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["SearchValue"] = searchValue;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
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
