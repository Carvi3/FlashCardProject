using Microsoft.AspNetCore.Mvc;

namespace FlashCardAPI.Controllers
{
    public class FlashcardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
