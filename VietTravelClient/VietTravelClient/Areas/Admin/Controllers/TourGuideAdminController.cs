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

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class TourGuideAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;
        private readonly string uploadPath;

        public TourGuideAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
            uploadPath = _configuration["UploadPath"];
        }

        [HttpGet]
        [Route("tourGuideManager")]
        public async Task<IActionResult> TourGuideManager()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domailServer + "tourGuide";
            string urlCity = domailServer + "city";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                if (responseData.Success && responseDataCity.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    ViewData["TourGuides"] = JsonConvert.DeserializeObject<List<TourGuide>>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
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
        [Route("saveTourGuide")]
        public async Task<IActionResult> CreateTourGuide(TourGuide value)
        {
            string url = domailServer + "tourGuide";
            TourGuide tourGuide = new TourGuide();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                tourGuide = JsonConvert.DeserializeObject<TourGuide>(responseData.Data);
                return RedirectToAction("TourGuideManager");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [Route("updateTourGuide")]
        public async Task<IActionResult> UpdateTourGuide(TourGuide value)
        {
            string url = domailServer + "tourGuide/" + value.Id.ToString();
            TourGuide tourGuide = new TourGuide();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                tourGuide = JsonConvert.DeserializeObject<TourGuide>(responseData.Data);
                return RedirectToAction("TourGuideManager");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("deleteTourGuide")]
        public async Task<IActionResult> DeleteTourGuide(string tourGuideId)
        {
            string url = domailServer + "tourGuide/" + tourGuideId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return RedirectToAction("TourGuideManager");
            }
            catch (Exception e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
