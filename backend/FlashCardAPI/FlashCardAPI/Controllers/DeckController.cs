using Microsoft.AspNetCore.Mvc;

namespace FlashCardAPI.Controllers
{
    public class DeckController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
