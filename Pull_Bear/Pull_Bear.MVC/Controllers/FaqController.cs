﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
