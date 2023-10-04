using Microsoft.AspNetCore.Mvc;

namespace VietTravelClient.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Cities()
        {
            return View();
        }
    }
}
