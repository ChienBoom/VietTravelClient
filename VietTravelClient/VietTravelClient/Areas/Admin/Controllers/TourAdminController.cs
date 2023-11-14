using Microsoft.AspNetCore.Mvc;
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
using System.Net.Http;
using UnidecodeSharpCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class TourAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string uploadPath;

        public TourAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
            uploadPath = _configuration["UploadPath"];
        }

        [HttpGet]
        [Route("addTour")]
        public async Task<IActionResult> AddTour()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "city";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View()
;
                }
                return RedirectToAction("Error", new { area="Admin", controller="HomeAdmin"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("tourManager")]
        public async Task<IActionResult> TourManager(int page, string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "tour/page/" + page.ToString();
            string urlTotalPage = domainServer + "tour/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["Status"] = status;
                    return View()
;
                }
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpPost]
        [Route("searchTourPost")]
        public async Task<IActionResult> SearchTourPost(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchTour", new { area = "Admin", controller = "TourAdmin", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchTour")]
        public async Task<IActionResult> SearchTour(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            if (!searchValue.Trim().Equals("") || searchValue != null)
            {
                string url = domainServer + "tour/search/" + searchValue.Unidecode() + "/" + page.ToString();
                string urlTotalPage = domainServer + "tour/search/totalPage/" + searchValue.Unidecode();
                List<Tour> tours = new List<Tour>();
                try
                {
                    ResponseData responseData = await _callApi.GetApi(url);
                    ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                    if (responseDataTotalPage.Success && responseData.Success)
                    {
                        string result = responseData.Data;
                        tours = JsonConvert.DeserializeObject<List<Tour>>(result);
                        ViewData["UsernameAccount"] = usernameAccount;
                        ViewData["Tours"] = tours;
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
            return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
        }

        [HttpPost]
        [Route("saveTour")]
        public async Task<IActionResult> CreateTour(Tour value, IFormFile file)
        {
            string url = domainServer + "tour";
            Tour Tour = new Tour();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            value.UniCodeName = value.Name.Unidecode();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if(responseData.Success)
                {
                    Tour = JsonConvert.DeserializeObject<Tour>(responseData.Data);
                    return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "CreateSuccess" });
                }
                return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "CreateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "CreateFaild" });
            }
        }

        [HttpGet]
        [Route("tourInfo")]
        public async Task<IActionResult> TourInfo(long tourId)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCities = domainServer + "city";
            string urlTour = domainServer + "tour/" + tourId.ToString();
            Tour tour = new Tour();
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities);
                ResponseData response = await _callApi.GetApi(urlTour);
                string result = response.Data;
                tour = JsonConvert.DeserializeObject<Tour>(result);
                ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCities.Data);
                ViewData["Tour"] = tour;
                ViewData["UsernameAccount"] = usernameAccount;
                return View();
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpPost]
        [Route("updateTour")]
        public async Task<IActionResult> UpdateTour(Tour value, IFormFile file)
        {
            string url = domainServer + "tour/" + value.Id.ToString();
            Tour city = new Tour();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            value.UniCodeName = value.Name.Unidecode();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                if (responseData.Success)
                {
                    city = JsonConvert.DeserializeObject<Tour>(responseData.Data);
                    return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "UpdateSuccess" });
                }
                return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "UpdateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "UpdateFaild" });
            }
        }

        [HttpGet]
        [Route("TourById")]
        public async Task<IActionResult> GetTourById(long id)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "Tour/" + id.ToString();
            Tour Tour = new Tour();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.Data;
                Tour = JsonConvert.DeserializeObject<Tour>(result);
                ViewData["UsernameAccount"] = usernameAccount;
                return View();
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpPost]
        [Route("deleteTour")]
        public async Task<IActionResult> DeleteTour(string TourId)
        {
            string url = domainServer + "tour/" + TourId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                if (responseData.Success)
                {
                    return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "DeleteSuccess" });
                }
                return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "DeleteFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("TourManager", new { area = "Admin", controller = "TourAdmin", page = 1, status = "DeleteFaild" });
            }
        }

    }
}
