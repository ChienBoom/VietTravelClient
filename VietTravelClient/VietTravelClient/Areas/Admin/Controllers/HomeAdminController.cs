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
using System.Linq;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HomeAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public HomeAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("home")]
        public async Task<IActionResult> Home()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCity = domainServer + "city";
            string urlTour = domainServer + "tour";
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTour.Success)
                {
                    List<City> cities = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    List<Tour> tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTour.Data);
                    ViewData["Cities"] = cities.OrderByDescending(o => o.Name).ToList();
                    ViewData["Tours"] = tours.OrderByDescending(o => o.NumberOfEvaluate).ToList();
                    List<City> hotCity = cities.OrderBy(o => o.Name).Take(4).ToList();
                    List<Tour> hotTour = tours.OrderBy(o => o.Name).Take(3).ToList();
                    ViewData["HotCities"] = hotCity;
                    ViewData["HotTours"] = hotTour;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View()
;
                }
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("accountManager")]
        public async Task<IActionResult> AccountManager(string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["User"] = JsonConvert.DeserializeObject<User>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["Status"] = status;
                    return View()
;
                }
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpPost]
        [Route("updatePassword")]
        public async Task<ActionResult> UpdatePassword(string oldPassword, string newPassword)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/updatePassword/" + usernameAccount + "/" + oldPassword + "/" + newPassword;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["User"] = JsonConvert.DeserializeObject<User>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdatePasswordSuccess" })
;
                }
                return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdatePasswordFaild" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdatePasswordFaild" });
            }
        }

        [HttpPost]
        [Route("updateInfo")]
        public async Task<ActionResult> UpdateInfo(User value)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/" + value.Id.ToString();
            try
            {
                value.Username = "notnull";
                value.Password = "notnull";
                value.Role = "Admin";
                value.Picture = "File null";
                ResponseData responseData = await _callApi.PutApi(url, JsonConvert.SerializeObject(value));
                if (responseData.Success)
                {
                    ViewData["User"] = JsonConvert.DeserializeObject<User>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdateInfoSuccess" })
;
                }
                return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdateInfoFaild" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdateInfoFaild" });
            }
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [Route("updatePictureUser")]
        public async Task<IActionResult> UpdatePictureUser(IFormFile file, User value)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Picture = _uploadFile.SaveFile(file).Message;
            string url = domainServer + "user/" + value.Id.ToString();
            try
            {
                value.Username = "notnull";
                value.Password = "notnull";
                value.Role = "Admin";
                ResponseData response = await _callApi.PutApi(url, JsonConvert.SerializeObject(value));
                if (response.Success)
                {
                    ViewData["User"] = JsonConvert.DeserializeObject<User>(response.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdateInfoSuccess" });
                }
                else return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdateInfoFaild" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("AccountManager", new { area = "Admin", controller = "HomeAdmin", status = "UpdateInfoFaild" });
            }
        }

    }
}
