using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnidecodeSharpCore;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class RestaurantAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string uploadPath;

        public RestaurantAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("addRestaurant")]
        public async Task<IActionResult> AddRestaurant()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCities = domainServer + "city";
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities);
                ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCities.Data);
                ViewData["UsernameAccount"] = usernameAccount;
                return View();
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpGet]
        [Route("RestaurantManager")]
        public async Task<IActionResult> RestaurantManager(int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "restaurant/page/" + page.ToString();
            string urlTotalPage = domainServer + "restaurant/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Restaurants"] = JsonConvert.DeserializeObject<List<Restaurant>>(responseData.Data);
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

        [HttpPost]
        [Route("searchRestaurantPost")]
        public async Task<IActionResult> SearchRestaurantPost(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchRestaurant", new { area = "Admin", controller = "RestaurantAdmin", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchRestaurant")]
        public async Task<IActionResult> SearchRestaurant(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "restaurant/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domainServer + "restaurant/search/totalPage/" + searchValue.Unidecode();
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    string result = responseData.Data;
                    restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(result);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["Restaurants"] = restaurants;
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

        [HttpPost]
        [Route("saveRestaurant")]
        public async Task<IActionResult> CreateRestaurant(Restaurant value, IFormFile file)
        {
            string url = domainServer + "restaurant";
            Restaurant restaurant = new Restaurant();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            value.UniCodeName = value.Name.Unidecode();
            try
            {
                value.Description = "";
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                restaurant = JsonConvert.DeserializeObject<Restaurant>(responseData.Data);
                return RedirectToAction("RestaurantManager");
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("updateRestaurant")]
        public async Task<IActionResult> UpdateRestaurant(Restaurant value, IFormFile file)
        {
            string url = domainServer + "restaurant/" + value.Id.ToString();
            Restaurant restaurant = new Restaurant();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                value.Description = "";
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                restaurant = JsonConvert.DeserializeObject<Restaurant>(responseData.Data);
                return RedirectToAction("RestaurantManager");
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpGet]
        [Route("restaurantInfo")]
        public async Task<IActionResult> RestaurantInfo(long restaurantId)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCities = domainServer + "city";
            string urlRestaurant = domainServer + "restaurant/" + restaurantId.ToString();
            Restaurant restaurant = new Restaurant();
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities);
                ResponseData response = await _callApi.GetApi(urlRestaurant);
                string result = response.Data;
                restaurant = JsonConvert.DeserializeObject<Restaurant>(result);
                ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCities.Data);
                ViewData["Restaurant"] = restaurant;
                ViewData["UsernameAccount"] = usernameAccount;
                return View();
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        //[HttpGet]
        //[Route("RestaurantById")]
        //public async Task<IActionResult> GetRestaurantById(long id)
        //{
        //    string url = domainServer + "Restaurant/" + id.ToString();
        //    Restaurant Restaurant = new Restaurant();
        //    try
        //    {
        //        ResponseData response = await _callApi.GetApi(url);
        //        string result = response.Data;
        //        Restaurant = JsonConvert.DeserializeObject<Restaurant>(result);
        //        return View();
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"HttpRequestException: {e.Message}");
        //        return View();
        //    }
        //}

        [HttpPost]
        [Route("deleteRestaurant")]
        public async Task<IActionResult> DeleteRestaurant(string restaurantId)
        {
            string url = domainServer + "restaurant/" + restaurantId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return RedirectToAction("RestaurantManager");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
