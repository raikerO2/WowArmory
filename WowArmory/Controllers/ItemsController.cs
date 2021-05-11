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
    public class ItemsController : Controller
    {
        private const int _itemsPerPage = 20;
        private static string _searchedItem = null;
        private static int _skipItems = 0;
        private static bool _firstTime = false;

        private DatabaseContext _database = null;
        private readonly IConfiguration _config;

        public ItemsController(DatabaseContext database, IConfiguration config)
        {
            _config = config;
            _database = database;
        }

        [HttpGet]
        [Route("items")]
        public IActionResult Index()
        {
            _searchedItem = null;
            _skipItems = 0;
            _firstTime = false;
            ViewBag.nextClicked = _firstTime;
            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        [Route("items/list")]
        public IActionResult Items(string name)
        {
            _skipItems = 0;
            if (String.IsNullOrEmpty(name))
            {
                _firstTime = false;
                ViewBag.nextClicked = _firstTime;
                return View();
            }

            _searchedItem = name;
            _firstTime = false;
            ViewBag.nextClicked = _firstTime;
            List<DataModel> itemList = _database.Data.Select(x => new DataModel
            {
                ItemId = x.ItemId,
                Icon = x.Icon,
                Name = x.Name,
                ItemLevel = x.ItemLevel,
                RequiredLevel = x.RequiredLevel,
                SellPrice = x.SellPrice,
                Subclass = x.Subclass
            }).Where(x => x.Name.Contains(name)).Take(_itemsPerPage).ToList<DataModel>();

            return View(itemList);
        }

        [HttpGet]
        [Route("items/next")]
        [AutoValidateAntiforgeryToken]
        public IActionResult NextItems()
        {
            _skipItems += _itemsPerPage;
            _firstTime = true;
            ViewBag.nextClicked = _firstTime;
            List<DataModel> nextItems = GetItemsByPage(_itemsPerPage);

            return View("Items",nextItems);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        [Route("items/previous")]
        public IActionResult PreviousItems()
        {
            if (_skipItems >= 0)
                _skipItems -= _itemsPerPage;

            if (_skipItems > 0)
            {
                _firstTime = true;
                ViewBag.nextClicked = _firstTime;
                List<DataModel> previousItems = GetItemsByPage(_itemsPerPage);

                return View("Items",previousItems);
            }
            else
            {
                _firstTime = false;
                ViewBag.nextClicked = _firstTime;
                List<DataModel> previousItems = _database.Data.Select(x => new DataModel
                {
                    ItemId = x.ItemId,
                    Icon = x.Icon,
                    Name = x.Name,
                    ItemLevel = x.ItemLevel,
                    RequiredLevel = x.RequiredLevel,
                    SellPrice = x.SellPrice,
                    Subclass = x.Subclass
                }).Where(x => x.Name.Contains(_searchedItem)).Take(_itemsPerPage).ToList<DataModel>();

                return View("Items",previousItems);
            }
        }

        private List<DataModel> GetItemsByPage(int pages)
        {
            return _database.Data.Select(x => new DataModel
            {
                ItemId = x.ItemId,
                Icon = x.Icon,
                Name = x.Name,
                ItemLevel = x.ItemLevel,
                RequiredLevel = x.RequiredLevel,
                SellPrice = x.SellPrice,
                Subclass = x.Subclass
            }).Where(x => x.Name.Contains(_searchedItem)).Skip(_skipItems).Take(pages).ToList<DataModel>();
        }
    }
}
