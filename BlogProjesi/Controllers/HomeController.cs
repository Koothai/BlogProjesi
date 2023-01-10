using BlogProjesi.Filters;
using BlogProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjesi.Controllers
{
    // [LoggedUser]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [LoggedUser]
        public IActionResult Privacy()
        {
            return View();
        }

        [LoggedUser]
        public IActionResult Profile()
        {
            return View();
        }

        [LoggedUser]
        public IActionResult Articles()
        {
            return View(); // return View(_context.Articles.ToList()); olr belki
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
