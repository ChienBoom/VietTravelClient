using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Models;

namespace VietTravelClient.Controllers
{
    public class LoginController : Controller
    {
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public LoginController(CallApi callApi, IConfiguration configuration)
        {
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Login(int status, string username, string password)
        {
            ViewData["Status"] = status;
            ViewData["Username"] = username;
            ViewData["Password"] = password;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckLogin(Account value)
        {
            string url = domailServer + "checkLogin";
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                string UsernameAccount = value.Username;
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    var roleUser = string.Empty;
                    var controller = string.Empty;
                    switch (responseData.Data)
                    {
                        case "Admin":
                            roleUser = "Admin";
                            controller = "HomeAdmin";
                            break;
                        default:
                            roleUser = "Customer";
                            controller = "HomeCustomer";
                            break;
                    }
                    return RedirectToAction("Home", new { area = roleUser, controller = controller, UsernameAccount = UsernameAccount });
                }
                return RedirectToAction("Login", new { status = 1, username = value.Username, password = value.Password });
            }
            catch (Exception e)
            {
                return RedirectToAction("Login", new { status = 2, username = value.Username, password = value.Password });
            }
        }

    }
}
