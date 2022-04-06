using Intex_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Components
{
    public class CountyViewComponent : ViewComponent
    {
        private ICrashRepository _repo { get; set; }

        public CountyViewComponent(ICrashRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCounty = RouteData?.Values["county"];

            var counties = _repo.Crashes
                .Select(x => x.COUNTY_NAME)
                .Distinct()
                .OrderBy(x => x);

            return View(counties);
        }
    }
}
