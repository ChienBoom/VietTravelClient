using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VietTravelClient.Controllers;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class TimePackageAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string uploadPath;

        public TimePackageAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
            uploadPath = _configuration["UploadPath"];
        }

        [HttpGet]
        [Route("timePackageManager")]
        public async Task<IActionResult> TimePackageManager()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "timepackage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["TimePackages"] = JsonConvert.DeserializeObject<List<TimePackage>>(responseData.Data);
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
        [Route("saveTimePackage")]
        public async Task<IActionResult> CreateTimePackage(TimePackage value)
        {
            string url = domainServer + "timepackage";
            TimePackage timePackage = new TimePackage();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                timePackage = JsonConvert.DeserializeObject<TimePackage>(responseData.Data);
                return RedirectToAction("timePackageManager");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [Route("updateTimePackage")]
        public async Task<IActionResult> UpdateTimePackage(TimePackage value)
        {
            string url = domainServer + "timepackage/" + value.Id.ToString();
            TimePackage timePackage = new TimePackage();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                timePackage = JsonConvert.DeserializeObject<TimePackage>(responseData.Data);
                return RedirectToAction("timePackageManager");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("deleteTimePackage")]
        public async Task<IActionResult> DeleteTimePackage(string TimePackageId)
        {
            string url = domainServer + "timepackage/" + TimePackageId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return RedirectToAction("timePackageManager");
            }
            catch (Exception e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
