﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TestPermitMicroFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string testPermitNumber { get; set; }

        public string clientMVID { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (testPermitNumber != null && testPermitNumber != "")
            {
                //clientMVID = testPermitNumber;
                //ViewData["clientMVID"] = testPermitNumber;
                return Redirect("/TestPermitDisplay?testpermitno=" + testPermitNumber);
                //return Page();
            }
            else
            {
                return Page();
            }
            //return Page();
        }

    }
}
