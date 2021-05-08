using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowArmory.Controllers
{
    public class ProfessionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
