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
        private readonly string domailServer;

        public TourAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("addTour")]
        public IActionResult AddTour()
        {
            return View();
        }

        [HttpGet]
        [Route("tourManager")]
        public async Task<IActionResult> TourManager()
        {
            string url = domailServer + "tour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseData.Data);
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
        [Route("searchTour")]
        public async Task<IActionResult> SearchTour(string searchValue, string UsernameAccount)
        {
            string url = domailServer + "tour/search/" + searchValue;
            List<Tour> tours = new List<Tour>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                string result = responseData.Data;
                tours = JsonConvert.DeserializeObject<List<Tour>>(result);
                ViewData["UsernameAccount"] = UsernameAccount;
                ViewData["Tours"] = tours;
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("saveTour")]
        public async Task<IActionResult> CreateTour(Tour value, IFormFile file)
        {
            string url = domailServer + "Tour";
            Tour Tour = new Tour();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                Tour = JsonConvert.DeserializeObject<Tour>(responseData.Data);
                return RedirectToAction("TourManager");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("TourById")]
        public async Task<IActionResult> GetTourById(long id)
        {
            string url = domailServer + "Tour/" + id.ToString();
            Tour Tour = new Tour();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.Data;
                Tour = JsonConvert.DeserializeObject<Tour>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        [Route("DeleteTour")]
        public async Task<IActionResult> DeleteTour(long id)
        {
            string url = "https://localhost:44348/api/Tour/" + id.ToString();
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
