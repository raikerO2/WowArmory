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
using WowArmory.Models.Core.Helpers;

namespace WowArmory.Controllers
{
    public class ItemsController : Controller
    {
        #region Private Fields
        private static string _name         = null;
        private static int _skippedItems    = 0;
        private static bool _pressedSearch  = false;

        private static int _items   = 0;
        private static int _pages   = 0;
        private static int _page    = 1;
        private const int _limit    = 20;
        private static int _offset  = 0;
        private static int _start   = 0;
        private static int _end     = 0;

        #endregion
        private DatabaseContext _database           = null;
        private readonly        IConfiguration      _config;
        private PageHelper _pageHelper              = null;

        public ItemsController(DatabaseContext database, IConfiguration config, PageHelper pageHelper)
        {
            _config     = config;
            _database   = database;
            _pageHelper = pageHelper;
        }

        [HttpGet]
        [Route("items")]
        public IActionResult Index()
        {
            _name = null;
            _skippedItems = 0;
            _pressedSearch = false;
            ViewBag.nextClicked = _pressedSearch;
            _pageHelper.Dispose();
            //RefreshVariables();
            return View();
        }

        [HttpGet]
        [Route("items/list")]
        public async Task<IActionResult> Items(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                _pressedSearch = false;
                ViewBag.nextClicked = _pressedSearch;
                return View();
            }

            List<DataModel> items = _database.Data.Select(
                x => new DataModel { Name = x.Name }).
                Where(x => x.Name.Contains(name)).
                ToList<DataModel>();

            _pageHelper.Startup<DataModel>(items);
            this.AddToView(_pageHelper);

            _name = name;
            _pressedSearch = false;
            ViewBag.nextClicked = _pressedSearch;

            List<DataModel> itemList = await _database.Data.Select(
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
                Take(_limit).ToListAsync<DataModel>();

            return View(itemList);
        }

        [HttpGet]
        [Route("items/next")]
        public async Task<IActionResult> NextItems()
        {
            _skippedItems += _limit;

            _pressedSearch = true;
            ViewBag.nextClicked = _pressedSearch;
            List<DataModel> nextItems = await ItemsPerPage(_limit);

            if (nextItems.Count() == 0)
            {
                ViewBag.numberOfItems = 0;
                _skippedItems -= _limit;
            }
            else
            {
                if (_page < _pages)
                {
                    _page++;
                    MoveToPage(nextItems);
                }
            }
            return View("Items", nextItems);
        }

        private void MoveToPage(List<DataModel> itemNumber)
        {
            _offset = (_page - 1) * _limit;

            _start = _offset + 1;
            _end = Math.Min((_offset + itemNumber.Count()), _items);

            ViewBag.Start = _start;
            ViewBag.End = _end;

            ViewBag.Page = _page;
            ViewBag.Pages = _pages;
            ViewBag.Offset = _offset;
            ViewBag.NumberOfItems = _items;
        }

        [HttpGet]
        [Route("items/previous")]
        public async Task<IActionResult> PreviousItems()
        {
            if (_skippedItems > 0)
                _skippedItems -= _limit;

            if (_skippedItems > 0)
            {
                _pressedSearch = true;
                ViewBag.nextClicked = _pressedSearch;
                List<DataModel> previousItems = await ItemsPerPage(_limit);

                if (_page > 1)
                {
                    _page--;
                    MoveToPage(previousItems);
                }
                return View("Items", previousItems);
            }
            else
            {
                _pressedSearch = false;
                ViewBag.nextClicked = _pressedSearch;
                List<DataModel> previousItems = await _database.Data.Select(
                    x => new DataModel
                    {
                        ItemId = x.ItemId,
                        Icon = x.Icon,
                        Name = x.Name,
                        ItemLevel = x.ItemLevel,
                        RequiredLevel = x.RequiredLevel,
                        SellPrice = x.SellPrice,
                        Subclass = x.Subclass
                    }).Where(x => x.Name.Contains(_name)).
                Take(_limit).
                ToListAsync<DataModel>();

                MoveToPage(previousItems);
                return View("Items", previousItems);
            }
        }

        private async Task<List<DataModel>> ItemsPerPage(int pages)
        {
            List<DataModel> result = await _database.Data.Select(
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
                x => x.Name.Contains(_name)).
                Skip(_skippedItems).Take(pages).
                ToListAsync<DataModel>();

            return result;
        }

        private void RefreshVariables()
        {
            _items = 0;
            _pages = 0;
            _page = 1;
            _offset = 0;

            _start = 0;
            _end = 0;
        }
    }
}
