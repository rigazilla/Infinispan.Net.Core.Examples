using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Infinispan.Example.Caching.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";
        public const string SessionKeyFirstAccess = "_FirstAccess";
        public static Random RndSource = new Random();
        public string DataSource { get; private set; }
        public void OnGet()
        {

            // Requires: using Microsoft.AspNetCore.Http;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                DataSource = "Computed";
                HttpContext.Session.SetString(SessionKeyName, "Mickey");
                HttpContext.Session.SetInt32(SessionKeyAge, RndSource.Next(100));
                HttpContext.Session.SetString(SessionKeyFirstAccess, DateTime.Now.ToString());
            }
            else
            {
                DataSource = "Cache";
            }

        }
    }
}
