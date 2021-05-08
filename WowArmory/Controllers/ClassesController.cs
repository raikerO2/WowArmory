using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models;
using WowArmory.Models.Core.Context;

namespace WowArmory.Controllers
{
    public class ClassesController : Controller
    {
        private DatabaseContext _database = null;
        public ClassesController(DatabaseContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
