using Microsoft.AspNetCore.Mvc;
using ncqa_lab08.Models;
using System.Diagnostics;

namespace ncqa_lab08.Controllers
{
    public class ncqaHomeController : Controller
    {
        private readonly ILogger<ncqaHomeController> _logger;

        public ncqaHomeController(ILogger<ncqaHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ncqaIndex()
        {
            return View();
        }

        public IActionResult ncqaAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
