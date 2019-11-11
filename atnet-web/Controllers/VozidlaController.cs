using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using atnet_web.Models;
using Microsoft.AspNetCore.Mvc;

namespace atnet_web.Controllers
{
    public class VozidlaController : Controller
    {
        public IActionResult Index()
        {
            Vehicle vozidlo = new Vehicle();
            return View(vozidlo);
        }

        [HttpPost]
        public IActionResult Index(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.SpocitejStari();
            }

            return View(vehicle);
        }
    }
}