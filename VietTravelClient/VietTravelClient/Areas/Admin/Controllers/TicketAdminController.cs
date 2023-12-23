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
using UnidecodeSharpCore;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class TicketAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string uploadPath;
        private string tokenAdmin;

        public TicketAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("ticketManager")]
        public async Task<IActionResult> TicketManager()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "ticket/getTicketNew";
            try
            {
                ResponseData response = await _callApi.GetApi(url, tokenAdmin);
                if (response.Success)
                {
                    List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(response.Data);
                    ViewData["Tickets"] = tickets;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpPost]
        [Route("searchTicketCustomer")]
        public async Task<IActionResult> SearchTicketCustomer(SearchTicketCusParam value)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "ticket/searchTicketCustomer";
            try
            {
                ResponseData response = await _callApi.PostApi(url, JsonConvert.SerializeObject(value), tokenAdmin);
                if (response.Success)
                {
                    List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(response.Data);
                    ViewData["Tickets"] = tickets;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpPost]
        [Route("changeTicketStatus")]
        public async Task<IActionResult> ChangeTicketStatus(string ticketId)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "ticket/changeTicketStatus/" + ticketId + "/" + usernameAccount;
            try
            {
                ResponseData response = await _callApi.GetApi(url, tokenAdmin);
                if (response.Success)
                {
                    return RedirectToAction("TicketManager", new { area = "Admin", controller = "TicketAdmin" });
                }
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

    }
}
