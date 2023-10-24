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
        private readonly string domainServer;
        private readonly string uploadPath;

        public TourGuideAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
            uploadPath = _configuration["UploadPath"];
        }

        [HttpGet]
        [Route("tourGuideManager")]
        public async Task<IActionResult> TourGuideManager(string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "tourGuide";
            string urlCity = domainServer + "city";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                if (responseData.Success && responseDataCity.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    ViewData["TourGuides"] = JsonConvert.DeserializeObject<List<TourGuide>>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["Status"] = status;
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

        [HttpPost]
        [Route("saveTourGuide")]
        public async Task<IActionResult> CreateTourGuide(TourGuide value)
        {
            string url = domainServer + "tourGuide";
            TourGuide tourGuide = new TourGuide();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    tourGuide = JsonConvert.DeserializeObject<TourGuide>(responseData.Data);
                    return RedirectToAction("TourGuideManager", new { area="Admin", controller="TourGuideAdmin", status="CreateSuccess"});
                }
                return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "CreateFaild" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "CreateFaild" });
            }
        }

        [HttpPost]
        [Route("updateTourGuide")]
        public async Task<IActionResult> UpdateTourGuide(TourGuide value)
        {
            string url = domainServer + "tourGuide/" + value.Id.ToString();
            TourGuide tourGuide = new TourGuide();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                if(responseData.Success)
                {
                    tourGuide = JsonConvert.DeserializeObject<TourGuide>(responseData.Data);
                    return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "UpdateSuccess" });
                }
                return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "UpdateFaild" });
            }
            catch (Exception e)
            {
                return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "UpdateFaild" });
            }
        }

        [HttpPost]
        [Route("deleteTourGuide")]
        public async Task<IActionResult> DeleteTourGuide(string tourGuideId)
        {
            string url = domainServer + "tourGuide/" + tourGuideId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                if (responseData.Success)
                {
                    return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "DeleteSuccess" });
                }
                return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "DeleteFaild" });
            }
            catch (Exception e)
            {
                return RedirectToAction("TourGuideManager", new { area = "Admin", controller = "TourGuideAdmin", status = "DeleteFaild" });
            }
        }

    }
}
