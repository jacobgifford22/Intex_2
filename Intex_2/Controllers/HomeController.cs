using Intex_2.Models;
using Intex_2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult ViewCrashes(string crashSeverity, int pageNum = 1)
        {
            int pageSize = 25;

            var x = new CrashesViewModel
            {
                Crashes = _repo.Crashes
                    .Include(x => x.Severity)
                    .Where(x => x.Severity.SEVERITY_NAME == crashSeverity || crashSeverity == null)
                    .OrderBy(x => x.CRASH_ID)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalCrashes = 
                        (crashSeverity == null 
                            ? _repo.Crashes.Count()
                            : _repo.Crashes
                                .Include(x => x.Severity)
                                .Where(x => x.Severity.SEVERITY_NAME == crashSeverity)
                                .Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum,
                    LinksPerPage = 8,
                    UrlParams = "Page-",
                    PagesLeft = 2,
                    PagesRight = 2
                }
            };

            return View(x);
        }

        public IActionResult CrashDetails(int crashId, int returnPage)
        {
            ViewBag.CrashId = crashId;
            ViewBag.ReturnPage = returnPage;

            Crash crash = _repo.Crashes
                .Include(x => x.Severity)
                .Where(x => x.CRASH_ID == crashId)
                .Single();

            return View(crash);
        }

        public IActionResult MLModel()
        {
            return View();
        }

        public IActionResult FunFacts()
        {
            return View();
        }

        public IActionResult CrashCount()
        {
            return View();
        }
    }
}
