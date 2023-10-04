using Microsoft.AspNetCore.Mvc;

namespace VietTravelClient.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Tours()
        {
            return View();
        }
    }
}
