using Microsoft.AspNetCore.Mvc;
using SmartCitySecurity.Data.Contexts;
using SmartCitySecurity.Models;
using System.Diagnostics;

namespace SmartCitySecurity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_databaseContext = databaseContext;
        }

        public IActionResult Index()
        {

            //var lista = _databaseContext.Habitantes.ToList();

            return View();
        }

        public IActionResult Privacy()
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
