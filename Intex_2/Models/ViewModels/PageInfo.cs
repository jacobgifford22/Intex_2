using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalCrashes { get; set; }
        public int CrashesPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int) Math.Ceiling((double) TotalCrashes / CrashesPerPage);

        public int LinksPerPage { get; set; }
        public string UrlParams { get; set; }
        public int PagesLeft { get; set; }
        public int PagesRight { get; set; }

        public int FromPage => Math.Max(1, CurrentPage - PagesLeft);
        public int ToPage => Math.Min(TotalPages, CurrentPage + PagesRight);
    }
}
