using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class OrderController : Controller
    {
        [Authorize(Roles = "Member")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
