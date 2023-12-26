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
    public class RevenueAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private string tokenAdmin;

        public RevenueAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("revenueStatisticsDetail")]
        public async Task<IActionResult> RevenueStatisticsDetail()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("revenueStatisticMonth")]
        public async Task<IActionResult> RevenueStatisticMonth()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("revenueStatisticCity")]
        public async Task<IActionResult> RevenueStatisticCity()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("revenueStatisticTour")]
        public async Task<IActionResult> RevenueStatisticTour()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("visitorStatisticMonth")]
        public async Task<IActionResult> VisitorStatisticMonth()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("visitorStatisticCity")]
        public async Task<IActionResult> VisitorStatisticCity()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("visitorStatisticTour")]
        public async Task<IActionResult> VisitorStatisticTour()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

    }
}
