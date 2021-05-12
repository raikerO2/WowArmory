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
        private static int _skippedItems = 0;
        private static bool _firstSearch = false;

        private static int _searchResultCount = 0;

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
            _skippedItems = 0;
            _firstSearch = false;
            ViewBag.nextClicked = _firstSearch;
            _searchResultCount = 0;
            return View();
        }

        [HttpGet]
        [Route("items/list")]
        public IActionResult Items(string name)
        {
            _skippedItems = 0;
            if (String.IsNullOrEmpty(name))
            {
                _firstSearch = false;
                ViewBag.nextClicked = _firstSearch;
                _searchResultCount = 0;
                return View();
            }

            List<DataModel> itemsFound = _database.Data.Select(
                x => new DataModel { Name = x.Name }).
                Where(x => x.Name.Contains(name)).
                ToList<DataModel>();

            _searchResultCount = itemsFound.Count();
            ViewBag.numberOfItems = _searchResultCount;

            _searchedItem = name;
            _firstSearch = false;
            ViewBag.nextClicked = _firstSearch;

            List<DataModel> itemList = _database.Data.Select(
                x => new DataModel
                {
                    ItemId = x.ItemId,
                    Icon = x.Icon,
                    Name = x.Name,
                    ItemLevel = x.ItemLevel,
                    RequiredLevel = x.RequiredLevel,
                    SellPrice = x.SellPrice,
                    Subclass = x.Subclass
                }).Where(x => x.Name.Contains(name)).
                Take(_itemsPerPage).ToList<DataModel>();

            return View(itemList);
        }

        [HttpGet]
        [Route("items/next")]
        public IActionResult NextItems()
        {
            _skippedItems += _itemsPerPage;

            _firstSearch = true;
            ViewBag.nextClicked = _firstSearch;
            List<DataModel> nextItems = GetItemsByPage(_itemsPerPage);

            if (nextItems.Count() == 0)
            {
                ViewBag.numberOfItems = 0;
                _skippedItems -= _itemsPerPage;
            }
            else
            {
                ViewBag.numberOfItems = _searchResultCount;
            }
            return View("Items", nextItems);
        }

        [HttpGet]
        [Route("items/previous")]
        public IActionResult PreviousItems()
        {
            if (_skippedItems > 0)
                _skippedItems -= _itemsPerPage;

            if (_skippedItems > 0)
            {
                _firstSearch = true;
                ViewBag.nextClicked = _firstSearch;
                List<DataModel> previousItems = GetItemsByPage(_itemsPerPage);

                ViewBag.numberOfItems = _searchResultCount;

                return View("Items", previousItems);
            }
            else
            {
                _firstSearch = false;
                ViewBag.nextClicked = _firstSearch;
                List<DataModel> previousItems = _database.Data.Select(
                    x => new DataModel
                    {
                        ItemId = x.ItemId,
                        Icon = x.Icon,
                        Name = x.Name,
                        ItemLevel = x.ItemLevel,
                        RequiredLevel = x.RequiredLevel,
                        SellPrice = x.SellPrice,
                        Subclass = x.Subclass
                    }).Where(x => x.Name.Contains(_searchedItem)).
                Take(_itemsPerPage).
                ToList<DataModel>();

                ViewBag.numberOfItems = _searchResultCount;

                return View("Items", previousItems);
            }
        }

        private List<DataModel> GetItemsByPage(int pages)
        {
            List<DataModel> result = _database.Data.Select(
                x => new DataModel
                {
                    ItemId = x.ItemId,
                    Icon = x.Icon,
                    Name = x.Name,
                    ItemLevel = x.ItemLevel,
                    RequiredLevel = x.RequiredLevel,
                    SellPrice = x.SellPrice,
                    Subclass = x.Subclass
                }).Where(
                x => x.Name.Contains(_searchedItem)).
                Skip(_skippedItems).Take(pages).
                ToList<DataModel>();

            return result;
        }
    }
}
