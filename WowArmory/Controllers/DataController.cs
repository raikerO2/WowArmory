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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData(string dataItem)
        {
            if (dataItem == null)
                return View();

            try
            {
                int? parser = Int32.Parse(dataItem);
            }
            catch (Exception e)
            {
                List<DataModel> nameList = _database.Data.Select(x => new DataModel
                {
                    DataId = x.DataId,
                    Icon = x.Icon,
                    Class = x.Class,
                    ContentPhase = x.ContentPhase,
                    ItemId = x.ItemId,
                    ItemLevel = x.ItemLevel,
                    Name = x.Name,
                    Quality = x.Quality,
                    RequiredLevel = x.RequiredLevel,
                    SellPrice = x.SellPrice,
                    Slot = x.Slot,
                    Source = x.Source,
                    Subclass = x.Subclass,
                    Tooltip = x.Tooltip,
                    UniqueName = x.UniqueName,
                    VendorPrice = x.VendorPrice
                }).Where(x => x.Name.Contains(dataItem)).ToList<DataModel>();

                return View("GetData",nameList);
            }

            List<DataModel> itemIdList = _database.Data.Select(x => new DataModel
            {
                DataId = x.DataId,
                Icon = x.Icon,
                Class = x.Class,
                ContentPhase = x.ContentPhase,
                ItemId = x.ItemId,
                ItemLevel = x.ItemLevel,
                Name = x.Name,
                Quality = x.Quality,
                RequiredLevel = x.RequiredLevel,
                SellPrice = x.SellPrice,
                Slot = x.Slot,
                Source = x.Source,
                Subclass = x.Subclass,
                Tooltip = x.Tooltip,
                UniqueName = x.UniqueName,
                VendorPrice = x.VendorPrice
            }).Where(x => x.ItemId == Int32.Parse(dataItem)).ToList<DataModel>();
            
            return View("GetData", itemIdList);
        }
    }
}
