using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using NetSolutionWorkSample.Entity;
using System.Web;
using NetSolutionWorkSample.Services;
using NetSolutionWorkSample.Entities;

namespace NetSolutionWorkSample.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
