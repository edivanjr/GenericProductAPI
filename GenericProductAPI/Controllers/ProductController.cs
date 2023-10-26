using Microsoft.AspNetCore.Mvc;

namespace GenericProductAPI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
