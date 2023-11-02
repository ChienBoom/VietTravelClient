using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Models;

namespace VietTravelClient.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public RegisterController(CallApi callApi, IConfiguration configuration)
        {
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        public IActionResult Register(int status, string username, string password)
        {
            ViewData["Status"] = status;
            ViewData["Username"] = username;
            ViewData["Password"] = password;
            return View();
        }

        public IActionResult RegisterInfo()
        {
            string value = TempData["Account"].ToString();
            Account account = JsonConvert.DeserializeObject<Account>(value);
            ViewData["AccountEmail"] = account.Username;
            ViewData["AccountPassword"] = account.Password;
            return View();
        }
        public IActionResult ConfirmEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterForm(Account value)
        {
            string url = domainServer + "checkEmailExis";
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success == true) return RedirectToAction("Register", new { status = 1, username = value.Username, password = value.Password });
                if (responseData.Message.Equals("NotFound"))
                {
                    TempData["Account"] = stringValue;
                    return RedirectToAction("RegisterInfo");
                }
                return RedirectToAction("Register", new { status = 2, username = value.Username, password = value.Password });
            }
            catch (HttpRequestException e)
            {
                return RedirectToAction("Register", new { status = 2, username = value.Username, password = value.Password });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister(User value)
        {
            string url = domainServer + "user";
            value.Role = "Customer";
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if (responseData.Success)
                {
                    if (responseData.Message.Equals("Success"))
                    {
                        HttpContext.Session.SetString("UsernameAccount", value.Username);
                        return RedirectToAction("Home", "HomeCustomer", new { area = "Customer", usernameAccount = value.Username});
                    }
                    return RedirectToAction("Error", "HomeCustomer", new { area = "Customer" });
                }
                return RedirectToAction("Error", "HomeCustomer", new { area = "Customer" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeCustomer", new { area = "Customer" });
            }
        }

    }
}
