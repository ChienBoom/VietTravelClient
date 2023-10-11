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
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class CityAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;
        private readonly string uploadPath;

        public CityAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("addCity")]
        public IActionResult AddCity()
        {
            return View();
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

        [HttpPost]
        [Route("searchCity")]
        public async Task<IActionResult> SearchCity(string searchValue, string UsernameAccount)
        {
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("CityManager");
            string url = domailServer + "city/search/" + searchValue;
            List<City> cities = new List<City>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                string result = responseData.Data;
                cities = JsonConvert.DeserializeObject<List<City>>(result);
                ViewData["UsernameAccount"] = UsernameAccount;
                ViewData["cities"] = cities;
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //[HttpPost]
        //[Route("searchCityTourDetail")]
        //public async Task<IActionResult> SearchCityTourDetail(string searchCitySelect, string UsernameAccount)
        //{
        //    string url = domailServer + "search/" + searchCitySelect;
        //    City city = new City();
        //    try
        //    {
        //        ResponseData responseData = await _callApi.GetApi(url);
        //        string result = responseData.Data;
        //        city = JsonConvert.DeserializeObject<City>(result);
        //        ViewData["UsernameAccount"] = UsernameAccount;
        //        ViewData["CityTourDetail"] = city;
        //        return View();
        //    }
        //    catch (Exception e)
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        [Route("saveCity")]
        public async Task<IActionResult> CreateCity(City value, IFormFile file)
        {
            string url = domailServer + "city";
            City city = new City();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                city = JsonConvert.DeserializeObject<City>(responseData.Data);
                return RedirectToAction("CityManager");
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("updateCity")]
        public async Task<IActionResult> UpdateCity(City value, IFormFile file)
        {
            string url = domailServer + "city/" + value.Id.ToString();
            City city = new City();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                value.Tours = new List<Tour>();
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                city = JsonConvert.DeserializeObject<City>(responseData.Data);
                return RedirectToAction("CityManager");
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpGet]
        [Route("cityInfo")]
        public async Task<IActionResult> CityInfo(long cityId)
        {
            string url = domailServer + "city/" + cityId.ToString();
            City city = new City();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.Data;
                city = JsonConvert.DeserializeObject<City>(result);
                ViewData["City"] = city;
                return View();
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        //[HttpGet]
        //[Route("CityById")]
        //public async Task<IActionResult> GetCityById(long id)
        //{
        //    string url = domailServer + "city/" + id.ToString();
        //    City city = new City();
        //    try
        //    {
        //        ResponseData response = await _callApi.GetApi(url);
        //        string result = response.Data;
        //        city = JsonConvert.DeserializeObject<City>(result);
        //        return View();
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"HttpRequestException: {e.Message}");
        //        return View();
        //    }
        //}

        [HttpPost]
        [Route("deleteCity")]
        public async Task<IActionResult> DeleteCity(string CityId)
        {
            string url = domailServer + "city/" + CityId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return RedirectToAction("CityManager");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
