﻿using Microsoft.AspNetCore.Mvc;
using LovelyLocks.Models;

namespace LovelyLocks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
           
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
