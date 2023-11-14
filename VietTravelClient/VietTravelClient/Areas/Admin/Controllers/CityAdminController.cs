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
using UnidecodeSharpCore;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;

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
        private readonly string domainServer;
        private readonly string uploadPath;

        public CityAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("addCity")]
        public IActionResult AddCity()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            ViewData["UsernameAccount"] = usernameAccount;
            return View();
        }

        [HttpGet]
        [Route("cityManager")]
        public async Task<IActionResult> CityManager(int page, string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "city/page/" + page.ToString();
            string urlTotalPage = domainServer + "city/totalPage";
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
                    ViewData["Status"] = status;
                    return View()
;
                }
                return RedirectToAction("Error", new {area="Admin", controller="HomeAdmin"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpPost]
        [Route("searchCityPost")]
        public async Task<IActionResult> SearchCityPost(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchCity", new { area = "Admin", controller = "CityAdmin", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchCity")]
        public async Task<IActionResult> SearchCity(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("CityManager");
            string url = domainServer + "city/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domainServer + "city/search/totalPage/" + searchValue.Unidecode();
            List<City> cities = new List<City>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    string result = responseData.Data;
                    cities = JsonConvert.DeserializeObject<List<City>>(result);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["cities"] = cities;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["SearchValue"] = searchValue;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        //[HttpPost]
        //[Route("searchCityTourDetail")]
        //public async Task<IActionResult> SearchCityTourDetail(string searchCitySelect, string UsernameAccount)
        //{
        //    string url = domainServer + "search/" + searchCitySelect;
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
            string url = domainServer + "city";
            City city = new City();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.UniCodeName = value.Name.Unidecode();
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseData.Data);
                    return RedirectToAction("CityManager", new { area = "Admin", controller = "CityAdmin",page=1, status = "CreateSuccess" });
                }
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin",page=1, status = "CreateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin",page=1, status = "CreateFaild"});
            }
        }

        [HttpPost]
        [Route("updateCity")]
        public async Task<IActionResult> UpdateCity(City value, IFormFile file)
        {
            string url = domainServer + "city/" + value.Id.ToString();
            City city = new City();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            value.UniCodeName = value.Name.Unidecode();
            try
            {
                value.Tours = new List<Tour>();
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                if (responseData.Success)
                {
                    city = JsonConvert.DeserializeObject<City>(responseData.Data);
                    return RedirectToAction("CityManager", new { area = "Admin", controller = "CityAdmin", page = 1, status = "UpdateSuccess" });
                }
                return RedirectToAction("CityManager", new { area = "Admin", controller = "CityAdmin", page = 1, status = "UpdateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("CityManager", new { area = "Admin", controller = "CityAdmin",page=1, status = "UpdateFaild" });
            }
        }

        [HttpGet]
        [Route("cityInfo")]
        public async Task<IActionResult> CityInfo(long cityId)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "city/" + cityId.ToString();
            City city = new City();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.Data;
                city = JsonConvert.DeserializeObject<City>(result);
                ViewData["City"] = city;
                ViewData["UsernameAccount"] = usernameAccount;
                return View();
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        //[HttpGet]
        //[Route("CityById")]
        //public async Task<IActionResult> GetCityById(long id)
        //{
        //    string url = domainServer + "city/" + id.ToString();
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
            string url = domainServer + "city/" + CityId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                if (responseData.Success)
                {
                    return RedirectToAction("CityManager", new { area = "Admin", controller = "CityAdmin",page=1, status = "DeleteSuccess" });
                }
                return RedirectToAction("CityManager", new { area = "Admin", controller = "CityAdmin", page = 1, status = "DeleteFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("CityManager", new { area = "Admin", controller = "CityAdmin",page=1, status = "DeleteFaild" });
            }
        }

    }
}
