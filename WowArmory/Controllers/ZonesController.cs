using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models;
using WowArmory.Models.Core.Context;

namespace WowArmory.Controllers
{
    public class ZonesController : Controller
    {
        private DatabaseContext _database = null;
        private static List<string> maps = new List<string>();
        private static List<Tuple<string,string>> specialNames = new List<Tuple<string,string>>()
        {
            new Tuple<string,string>("Zul'Gurub","Zulgurub"),
            new Tuple<string,string>("Zul'Farrak","Zulfarrak"),
            new Tuple<string,string>("Un'Goro","Ungoro"),
            new Tuple<string,string>("Ahn'Qiraj","Ahnqiraj")
        };
        
        public ZonesController(DatabaseContext db)
        {
            _database = db;
        }

        private IQueryable<ZoneModel> SelectZone()
        {
            return _database.Zones
                .Select(x => new ZoneModel
                {
                    Name = x.Name,
                    Category = x.Category,
                    Territory = x.Territory,
                    Level = new LevelModel
                    {
                        Level1 = x.Level.Level1,
                        Level2 = x.Level.Level2
                    }
                });
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ZoneModel> zones = SelectZone()
                .Distinct()
                .ToList();
            return View(zones);
        }

        [HttpGet]
        public IActionResult Zone(string name)
        {
            if(maps.Count() == 0)
                GetImgNames();

            if (String.IsNullOrEmpty(name))
                return View();

            ZoneModel zone = SelectZone()
                .Where(x=> x.Name.Contains(name)).FirstOrDefault();

            ViewBag.Name = name;

            foreach (var i in maps)
            {
                foreach(var x in specialNames)
                {
                    if(name.Contains(x.Item1))
                    {
                        zone.Name = x.Item2;
                        break;
                    }
                }

                int start = 4;
                int end = i.Length - start;

                string trimmer = i.Remove(start,end);
                if (name.Contains(trimmer))
                {
                    zone.Name = i;
                    break;
                }
            }
            return View(zone);
        }

        private void GetImgNames()
        {
            List<string> fileNames = new List<string>();
            var myDirectory = Directory.GetFiles(@".\wwwroot\Maps\");
            string fromFolder;

            foreach (var file in myDirectory)
            {
                fromFolder = Path.GetFileNameWithoutExtension(file);
                maps.Add(fromFolder);
            }
        }

    }
}
