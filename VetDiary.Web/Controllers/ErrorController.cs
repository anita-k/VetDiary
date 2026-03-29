using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VetDiary.Controllers
{
    [AllowAnonymous]
    public class ErrorController : BaseController
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index(int? statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }

            if (statusCode == 500)
            {
                return View("InternalError");
            }

            return View("InternalError");
        }
    }
}
