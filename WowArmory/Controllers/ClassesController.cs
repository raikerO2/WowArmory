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
            ClassModel theClass = new ClassModel();
            theClass.Name = "Muie";
            theClass.Color = "Fasole";
            theClass.Icon = "cacat";
            theClass.Spec = new List<SpecModel>() 
            { 
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" },
                new SpecModel { Name = "cacat", Icon = "pisat" }
            };
            _db.Classes.Add(theClass);
            _db.SaveChanges();
            return View();
        }
    }
}
