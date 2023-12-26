using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class EvaluateCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private string tokenCustomer;

        public EvaluateCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpPost]
        [Route("saveEvaluate")]
        public async Task<IActionResult> SaveEvaluate(Evaluate value, string usernameAccount, string controllerName, string actionName)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            string url = domainServer + "evaluate";
            string urlUser = domainServer + "user/searchUserByUsername/" + usernameAccount;
            User user = new User();
            try
            {
                ResponseData responseDataUser = await _callApi.GetApi(urlUser, tokenCustomer);
                if(!responseDataUser.Success) return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
                user = JsonConvert.DeserializeObject<User>(responseDataUser.Data);
                value.User = user;
                value.UserId = user.Id;
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue, tokenCustomer);
                if(!responseData.Success) return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
                Evaluate evaluate = JsonConvert.DeserializeObject<Evaluate>(responseData.Data);
                return RedirectToAction(actionName, new {area="Customer", controller= controllerName, itemId =value.EvaId, page =1});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

        [HttpPost]
        [Route("saveEvaluateStar")]
        public async Task<IActionResult> SaveEvaluateStar(EvaluateStar value, string usernameAccount, string controllerName, string actionName)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            string url = domainServer + "evaluateStar";
            string urlUser = domainServer + "user/searchUserByUsername/" + usernameAccount;
            User user = new User();
            try
            {
                ResponseData responseDataUser = await _callApi.GetApi(urlUser, tokenCustomer);
                if (!responseDataUser.Success) return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
                user = JsonConvert.DeserializeObject<User>(responseDataUser.Data);
                //value.User = user;
                value.UserId = user.Id;
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue, tokenCustomer);
                if (!responseData.Success) return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
                EvaluateStar evaluatestar = JsonConvert.DeserializeObject<EvaluateStar>(responseData.Data);
                return RedirectToAction(actionName, new { area = "Customer", controller = controllerName, itemId = value.EvaId, page = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

        [HttpPost]
        [Route("updateEvaluateStar")]
        public async Task<IActionResult> UpdateEvaluateStar(EvaluateStar value, string usernameAccount, string controllerName, string actionName)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            string url = domainServer + "evaluateStar/" + value.Id.ToString();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue, tokenCustomer);
                if (!responseData.Success) return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
                Evaluate evaluate = JsonConvert.DeserializeObject<Evaluate>(responseData.Data);
                return RedirectToAction(actionName, new { area = "Customer", controller = controllerName, itemId = value.EvaId, page = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

        [HttpPost]
        [Route("updateEvaluate")]
        public async Task<IActionResult> UpdateEvaluate(Evaluate value, string usernameAccount, string controllerName, string actionName)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            string url = domainServer + "evaluate/" + value.Id.ToString();
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue, tokenCustomer);
                if (!responseData.Success) return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
                Evaluate evaluate = JsonConvert.DeserializeObject<Evaluate>(responseData.Data);
                return RedirectToAction(actionName, new { area = "Customer", controller = controllerName, itemId = value.EvaId, page = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

        [HttpPost]
        [Route("deleteEvaluate")]
        public async Task<IActionResult> DeleteEvaluate(string itemId, string controllerName, string actionName)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            string url = domainServer + "evaluate/" + itemId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url, tokenCustomer);
                if (!responseData.Success) return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
                Evaluate evaluate = JsonConvert.DeserializeObject<Evaluate>(responseData.Data);
                return RedirectToAction(actionName, new { area = "Customer", controller = controllerName, itemId = itemId, page = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

    }
}
