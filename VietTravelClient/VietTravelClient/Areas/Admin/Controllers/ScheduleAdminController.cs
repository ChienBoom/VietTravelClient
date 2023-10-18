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
        private readonly string domailServer;
        private readonly string uploadPath;

        public ScheduleAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("scheduleManager")]
        public async Task<IActionResult> ScheduleManager(int TourId)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domailServer + "schedule/getByTourId/" + TourId.ToString();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(responseData.Data);
                    ViewData["Schedules"] = schedules;
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["TourId"] = TourId.ToString();
                    return View();
                }
                return RedirectToAction("Error", "Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
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
            string url = domailServer + "schedule";
            Schedule schedule = new Schedule();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    schedule = JsonConvert.DeserializeObject<Schedule>(responseData.Data);
                    return RedirectToAction("ScheduleManager", new {controller = "ScheduleAdmin", TourId = value.TourId});
                }
                return RedirectToAction("Error", "Home");
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [Route("updateSchedule")]
        public async Task<IActionResult> UpdateSchedule(Schedule value, IFormFile file)
        {
            string url = domailServer + "schedule/" + value.Id.ToString();
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
                    return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId });
                }
                return RedirectToAction("Error", "Home");
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [Route("deleteSchedule")]
        public async Task<IActionResult> DeleteSchedule(Schedule value)
        {
            string url = domailServer + "schedule/" + value.Id.ToString();
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return RedirectToAction("ScheduleManager", new { controller = "ScheduleAdmin", TourId = value.TourId });
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
