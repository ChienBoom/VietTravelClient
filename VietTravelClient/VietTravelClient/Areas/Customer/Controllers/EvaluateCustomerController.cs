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
            string url = domainServer + "evaluate";
            string urlUser = domainServer + "user/searchUserByUsername/" + usernameAccount;
            User user = new User();
            try
            {
                ResponseData responseDataUser = await _callApi.GetApi(urlUser);
                if(!responseDataUser.Success) return RedirectToAction("Error", "Home");
                user = JsonConvert.DeserializeObject<User>(responseDataUser.Data);
                value.User = user;
                value.UserId = user.Id;
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                if(!responseData.Success) return RedirectToAction("Error", "Home");
                Evaluate evaluate = JsonConvert.DeserializeObject<Evaluate>(responseData.Data);
                return RedirectToAction(actionName, new {area="Customer", controller= controllerName});
            }
            catch (Exception ex)
            {
                return RedirectToAction(actionName, new { area = "Customer", controller = controllerName });
            }
        }

    }
}
