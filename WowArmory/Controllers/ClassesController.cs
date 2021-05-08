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
        private DatabaseContext _db = null;
        public ClassesController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ClassModel classes = new ClassModel();
            classes.Id = 1;
            classes.Name = "Fasole";
            classes.Icon = "Fasole2";
            classes.Color = "Fasole3";
            classes.Spec = new List<SpecModel>() { new SpecModel { Id = 1, Name = "Name1", Icon = "Icon1" } };

            _db.Classes.Add(classes);
            _db.SaveChanges();
            return View();
        }
    }
}
