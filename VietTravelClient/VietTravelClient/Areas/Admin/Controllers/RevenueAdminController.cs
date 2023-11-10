﻿using Microsoft.AspNetCore.Mvc;
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
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("revenueStatisticMonth")]
        public async Task<IActionResult> RevenueStatisticMonth()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("revenueStatisticCity")]
        public async Task<IActionResult> RevenueStatisticCity()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("revenueStatisticTour")]
        public async Task<IActionResult> RevenueStatisticTour()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("visitorStatisticMonth")]
        public async Task<IActionResult> VisitorStatisticMonth()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("visitorStatisticCity")]
        public async Task<IActionResult> VisitorStatisticCity()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("visitorStatisticTour")]
        public async Task<IActionResult> VisitorStatisticTour()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    ViewData["Revenue"] = revenue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

    }
}