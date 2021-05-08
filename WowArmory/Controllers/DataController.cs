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
using WowArmory.Models;
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
            string dataFile = System.IO.File.ReadAllText(_config["JsonData:Data"]);
            List<DataModel> Data = JsonConvert.DeserializeObject<List<DataModel>>(dataFile);
           
            foreach(var data in Data)
            {
                var existingRecord = _database.Data.FirstOrDefault(x => x.ItemId == data.ItemId);
                if (existingRecord == null)
                {
                  _database.Add(data);
                  _database.SaveChanges();
                } 
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody]IFormFile file)
        {
            return View();
        }
    }
}
