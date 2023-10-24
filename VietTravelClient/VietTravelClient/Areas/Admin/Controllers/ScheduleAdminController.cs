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
using Newtonsoft.Json.Linq;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class ScheduleAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string uploadPath;

        public ScheduleAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("scheduleManager")]
        public async Task<IActionResult> ScheduleManager(int TourId, string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "schedule/getByTourId/" + TourId.ToString();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(responseData.Data);
                    ViewData["Schedules"] = schedules;
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["TourId"] = TourId.ToString();
                    ViewData["Status"] = status;
                    return View();
                }
                return RedirectToAction("Error", new {area="Admin", controller="HomeAdmin"});
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            
        }

        [HttpGet]
        [Route("scheduleDetail")]
        public IActionResult ScheduleDetail()
        {
            return View();
        }

        [HttpGet]
        [Route("scheduleUpdate")]
        public IActionResult ScheduleUpdate()
        {
            return View();
        }

        [HttpPost]
        [Route("saveSchedule")]
        public async Task<IActionResult> CreateSchedule(Schedule value, IFormFile file)
        {
            string url = domainServer + "schedule";
            Schedule schedule = new Schedule();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    schedule = JsonConvert.DeserializeObject<Schedule>(responseData.Data);
                    return RedirectToAction("ScheduleManager", new {controller = "ScheduleAdmin", TourId = value.TourId, status="CreateSuccess"});
                }
                return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "CreateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "CreateFaild" });
            }
        }

        [HttpPost]
        [Route("updateSchedule")]
        public async Task<IActionResult> UpdateSchedule(Schedule value, IFormFile file)
        {
            string url = domainServer + "schedule/" + value.Id.ToString();
            Schedule schedule = new Schedule();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                if(responseData.Success)
                {
                    schedule = JsonConvert.DeserializeObject<Schedule>(responseData.Data);
                    return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "UpdateSuccess" });
                }
                return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "UpdateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "UpdateFaild" });
            }
        }

        [HttpPost]
        [Route("deleteSchedule")]
        public async Task<IActionResult> DeleteSchedule(Schedule value)
        {
            string url = domainServer + "schedule/" + value.Id.ToString();
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                if(responseData.Success)
                {
                    return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "DeleteSuccess" });
                }
                return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "DeleteFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId, status = "DeleteFaild" });
            }
        }

    }
}
