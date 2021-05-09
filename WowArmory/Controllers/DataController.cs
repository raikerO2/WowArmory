using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Factory;
using WowArmory.Models;
using WowArmory.Models.Core;
using WowArmory.Models.Core.Context;

namespace WowArmory.Controllers
{
    public class DataController : Controller
    {
        private DatabaseContext _database = null;
        private readonly IConfiguration _config;

        public DataController(DatabaseContext database, IConfiguration config)
        {
            _config = config;
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Data already pressent in DB.

            //DataEntry dataEntry = new DataEntry(_database,_config);
            //dataEntry.InsertRecords<ZoneModel>("Zones");
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody]IFormFile file)
        {
            return View();
        }
    }
}
