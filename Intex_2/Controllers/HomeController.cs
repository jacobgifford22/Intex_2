using Intex_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Controllers
{
    public class HomeController : Controller
    {
        private ICrashRepository _repo { get; set; }

        public HomeController(ICrashRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewCrashes()
        {
            List<Crash> crashes = _repo.Crashes
                .Where(x => x.CRASH_ID <= 10805710)
                .OrderBy(x => x.CRASH_DATETIME)
                .ToList();

            return View(crashes);
        }

    }
}
