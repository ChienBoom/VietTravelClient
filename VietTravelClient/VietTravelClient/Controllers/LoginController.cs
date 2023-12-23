using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Models;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;

namespace VietTravelClient.Controllers
{
    public class LoginController : Controller
    {
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string tokenAnonymous;

        public LoginController(CallApi callApi, IConfiguration configuration)
        {
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            tokenAnonymous = _configuration["tokenAnonymous"];
        }

        [HttpGet]
        [Route("/forgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("/recoverPassword")]
        public async Task<IActionResult> RecoverPassword(string EmailAccount)
        {
            string url = domainServer + "recoverPassword";
            try
            {
                Account account = new Account();
                account.Username = EmailAccount;
                account.Password = "ForgotPassword";
                string stringAccount = JsonConvert.SerializeObject(account);
                ResponseData responseData = await _callApi.PostApi(url, stringAccount, tokenAnonymous);
                if (responseData.Success)
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Error", "Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Login(int status, string username, string password)
        {
            ViewData["Status"] = status;
            ViewData["Username"] = username;
            ViewData["Password"] = password;
            return View();
        }

        [HttpPost]
        [Route("/checkLogin")]
        public async Task<IActionResult> CheckLogin(Account value)
        {
            string url = domainServer + "checkLogin";
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                string UsernameAccount = value.Username;
                ResponseData responseData = await _callApi.PostApi(url, stringValue, tokenAnonymous);
                if (responseData.Success)
                {
                    HttpContext.Session.SetString("UsernameAccount", value.Username );
                    HttpContext.Session.SetString("token", responseData.Message);
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
                    //return RedirectToAction("Home", new { area = roleUser, controller = controller, UsernameAccount = UsernameAccount });
                    return RedirectToAction("Home", new { area = roleUser, controller = controller});
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
