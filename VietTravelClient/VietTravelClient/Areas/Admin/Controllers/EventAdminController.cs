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
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;
using Newtonsoft.Json.Linq;


namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class EventAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public EventAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
        }

        //[HttpGet]
        //[Route("addEvent")]
        //public async Task<IActionResult> AddEvent()
        //{
        //    if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
        //    string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
        //    try
        //    {
        //        ViewData["UsernameAccount"] = usernameAccount;
        //        return View();
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        return View();
        //    }
        //}

        [HttpGet]
        [Route("EventTourManager")]
        public async Task<IActionResult> EventTourManager(string TourId, string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "event/searchEventByTourId/" + TourId;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(responseData.Data);
                    ViewData["TourId"] = TourId;
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["Status"] = status;
                    return View();
                }
                return RedirectToAction("Error", new { area="Admin", controller="HomeAdmin"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        //[HttpPost]
        //[Route("searchEvent")]
        //public async Task<IActionResult> SearchEvent(string searchValue)
        //{
        //    if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
        //    string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
        //    if (searchValue != null || !searchValue.Trim().Equals(""))
        //    {
        //        string url = domainServer + "Event/search/" + searchValue;
        //        List<Event> Events = new List<Event>();
        //        try
        //        {
        //            ResponseData responseData = await _callApi.GetApi(url);
        //            string result = responseData.Data;
        //            Events = JsonConvert.DeserializeObject<List<Event>>(result);
        //            ViewData["UsernameAccount"] = usernameAccount;
        //            ViewData["Events"] = Events;
        //            return View();
        //        }
        //        catch (Exception e)
        //        {
        //            return View();
        //        }
        //    }
        //    return RedirectToAction("EventManager");
        //}

        [HttpPost]
        [Route("saveEvent")]
        public async Task<IActionResult> CreateEvent(Event value, IFormFile file)
        {
            string url = domainServer + "event";
            Event Event = new Event();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if(responseData.Success)
                {
                    Event = JsonConvert.DeserializeObject<Event>(responseData.Data);
                    return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = value.TourId, status = "CreateSuccess" });
                }
                return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = value.TourId, status = "CreateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = value.TourId, status = "CreateFaild" });
            }
        }

        [HttpPost]
        [Route("updateEvent")]
        public async Task<IActionResult> UpdateEvent(Event value, IFormFile file)
        {
            string url = domainServer + "event/" + value.Id.ToString();
            Event Event = new Event();
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
                    Event = JsonConvert.DeserializeObject<Event>(responseData.Data);
                    return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = value.TourId, status = "UpdateSuccess" });
                }
                return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = value.TourId, status = "UpdateFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = value.TourId, status = "UpdateFaild" });
            }
        }


        //[HttpGet]
        //[Route("EventById")]
        //public async Task<IActionResult> GetEventById(long id)
        //{
        //    string url = domainServer + "Event/" + id.ToString();
        //    Event Event = new Event();
        //    try
        //    {
        //        ResponseData response = await _callApi.GetApi(url);
        //        string result = response.Data;
        //        Event = JsonConvert.DeserializeObject<Event>(result);
        //        return View();
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"HttpRequestException: {e.Message}");
        //        return View();
        //    }
        //}

        [HttpPost]
        [Route("deleteEvent")]
        public async Task<IActionResult> DeleteEvent(string Id)
        {
            string url = domainServer + "event/" + Id;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                if (responseData.Success)
                {
                    return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = Id, status = "DeleteSuccess" });
                }
                return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = Id, status = "DeleteFaild" });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("EventTourManager", new { area = "Admin", controller = "EventAdmin", TourId = Id, status = "DeleteFaild" });
            }
        }

    }
}
