using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;
using UnidecodeSharpCore;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HotelAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string uploadPath;
        private string tokenAdmin;

        public HotelAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("addHotel")]
        public async Task<IActionResult> AddHotel()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCities = domainServer + "city";
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities, tokenAdmin);
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
        [Route("hotelManager")]
        public async Task<IActionResult> HotelManager(int page, string status)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "hotel/page/" + page.ToString();
            string urlTotalPage = domainServer + "hotel/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAdmin);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseData.Data);
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
        [Route("searchHotelPost")]
        public async Task<IActionResult> SearchHotelPost(string searchValue, int page)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchHotel", new { area = "Admin", controller = "HotelAdmin", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchHotel")]
        public async Task<IActionResult> SearchHotel(string searchValue, int page)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "hotel/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domainServer + "hotel/search/totalPage/" + searchValue.Unidecode();
            List<Hotel> hotels = new List<Hotel>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAdmin);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    string result = responseData.Data;
                    hotels = JsonConvert.DeserializeObject<List<Hotel>>(result);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["hotels"] = hotels;
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

        [HttpPost]
        [Route("saveHotel")]
        public async Task<IActionResult> CreateHotel(Hotel value, IFormFile file)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            string url = domainServer + "hotel";
            Hotel hotel = new Hotel();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            value.Pictures = _uploadFile.SaveFile(file).Message;
            value.UniCodeName = value.Name.Unidecode();
            try
            {
                value.Description = "";
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue, tokenAdmin);
                hotel = JsonConvert.DeserializeObject<Hotel>(responseData.Data);
                return RedirectToAction("HotelManager", new { area = "Admin", controller = "HotelAdmin", page = 1, status = "CreateSuccess" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("HotelManager", new { area = "Admin", controller = "HotelAdmin", page = 1, status = "CreateFaild" });
            }
        }

        [HttpPost]
        [Route("updateHotel")]
        public async Task<IActionResult> UpdateHotel(Hotel value, IFormFile file)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            string url = domainServer + "hotel/" + value.Id.ToString();
            Hotel Hotel = new Hotel();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            value.UniCodeName = value.Name.Unidecode();
            try
            {
                value.Description = "";
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue, tokenAdmin);
                Hotel = JsonConvert.DeserializeObject<Hotel>(responseData.Data);
                return RedirectToAction("HotelManager", new { area = "Admin", controller = "HotelAdmin", page = 1, status = "UpdateSuccess" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("HotelManager", new { area = "Admin", controller = "HotelAdmin", page = 1, status = "UpdateFaild" });
            }
        }

        [HttpGet]
        [Route("hotelInfo")]
        public async Task<IActionResult> HotelInfo(long HotelId)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCities = domainServer + "city";
            string urlHotel = domainServer + "hotel/" + HotelId.ToString();
            Hotel hotel = new Hotel();
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities, tokenAdmin);
                ResponseData response = await _callApi.GetApi(urlHotel, tokenAdmin);
                string result = response.Data;
                hotel = JsonConvert.DeserializeObject<Hotel>(result);
                ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCities.Data);
                ViewData["Hotel"] = hotel;
                ViewData["UsernameAccount"] = usernameAccount;
                return View();
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        //[HttpGet]
        //[Route("HotelById")]
        //public async Task<IActionResult> GetHotelById(long id)
        //{
        //    string url = domainServer + "Hotel/" + id.ToString();
        //    Hotel Hotel = new Hotel();
        //    try
        //    {
        //        ResponseData response = await _callApi.GetApi(url);
        //        string result = response.Data;
        //        Hotel = JsonConvert.DeserializeObject<Hotel>(result);
        //        return View();
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"HttpRequestException: {e.Message}");
        //        return View();
        //    }
        //}

        [HttpPost]
        [Route("deleteHotel")]
        public async Task<IActionResult> DeleteHotel(string HotelId)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            string url = domainServer + "hotel/" + HotelId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url, tokenAdmin);
                return RedirectToAction("HotelManager", new { area="Admin", controller="HotelAdmin", page=1, status = "DeleteSuccess"});
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("HotelManager", new { area = "Admin", controller = "HotelAdmin", page = 1, status = "DeleteFaild" });
            }
        }

    }
}
