using Intex_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Components
{
    public class SeverityViewComponent : ViewComponent
    {
        private ICrashRepository _repo { get; set; }

        public SeverityViewComponent(ICrashRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedSeverity = RouteData?.Values["crashSeverity"];
            
            var severities = _repo.Severities
                .Select(x => x.SEVERITY_NAME)
                .Distinct()
                .OrderBy(x => x);
            
            return View(severities);
        }
    }
}
