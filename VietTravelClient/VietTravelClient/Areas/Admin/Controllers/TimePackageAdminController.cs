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
        private string tokenAdmin;

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
        public async Task<IActionResult> TimePackageManager(string status)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "timepackage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    ViewData["TimePackages"] = JsonConvert.DeserializeObject<List<TimePackage>>(responseData.Data);
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
        [Route("saveTimePackage")]
        public async Task<IActionResult> CreateTimePackage(TimePackage value)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            string url = domainServer + "timepackage";
            TimePackage timePackage = new TimePackage();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue, tokenAdmin);
                if(responseData.Success)
                {
                    timePackage = JsonConvert.DeserializeObject<TimePackage>(responseData.Data);
                    return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "CreateSuccess" });
                }
                return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "CreateFaild" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "CreateFaild" });
            }
        }

        [HttpPost]
        [Route("updateTimePackage")]
        public async Task<IActionResult> UpdateTimePackage(TimePackage value)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            string url = domainServer + "timepackage/" + value.Id.ToString();
            TimePackage timePackage = new TimePackage();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue, tokenAdmin);
                if(responseData.Success)
                {
                    timePackage = JsonConvert.DeserializeObject<TimePackage>(responseData.Data);
                    return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "UpdateSuccess" });
                }
                return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "UpdateFaild" });
            }
            catch (Exception e)
            {
                return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "UpdateFaild" });
            }
        }

        [HttpPost]
        [Route("deleteTimePackage")]
        public async Task<IActionResult> DeleteTimePackage(string TimePackageId)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            string url = domainServer + "timepackage/" + TimePackageId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url, tokenAdmin);
                if(responseData.Success)
                {
                    return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "DeleteSuccess" });
                }
                return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "DeleteFaild" });
            }
            catch (Exception e)
            {
                return RedirectToAction("timePackageManager", new { area = "Admin", controller = "TimePackageAdmin", status = "DeleteFaild" });
            }
        }

    }
}
