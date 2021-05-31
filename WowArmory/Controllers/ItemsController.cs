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
        private static bool _pressedNext  = false;

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
            _pageHelper.Dispose(null);
            this.BindToView(_pageHelper);
            return View();
        }

        [HttpGet]
        [Route("items/list")]
        public async Task<IActionResult> Items(string name)
        {
            //Dump if string empty or null.
            if (String.IsNullOrEmpty(name))
            {
                _pageHelper.Dispose(null);
                this.BindToView(_pageHelper);
                return View();
            }

            //Get all items that contain the queried name.
            List<DataModel> allItemsWithName = await SelectByName(name);

            //Initialize and build pagination.
            _pageHelper.Startup<DataModel>(allItemsWithName, contains: name);

            //Return specified items per page limit. Bind the results to ViewBag and send it to view.
            List<DataModel> items = await SelectByNamePerPage(name, _pageHelper.PageLimit);
            this.BindToView(_pageHelper);

            return View(items);
        }

        [HttpGet]
        [Route("items/next")]
        public async Task<IActionResult> NextItems()
        {
            List<DataModel> nextItems = await SelectByNameSkip(_pageHelper);
            _pageHelper.NextPage<DataModel>(nextItems);

            this.BindToView(_pageHelper);
            return View("Items", nextItems);
        }

        [HttpGet]
        [Route("items/previous")]
        public async Task<IActionResult> PreviousItems()
        {
            List<DataModel> previousItems = await SelectByNameSkip(_pageHelper);    //await ItemsPerPage(_limit);

            if (_pageHelper.PreviousPage<DataModel>(previousItems))
            {
                this.BindToView(_pageHelper);
                return View("Items", previousItems);
            }
            else
            {
                this.BindToView(_pageHelper);
                return View("Items", previousItems);
            }
        }

        private async Task<List<DataModel>> ItemsPerPage(int number)
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
                Skip(_skippedItems).Take(number).
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

        public async Task<List<DataModel>> SelectByName(string name)
        {
            return await _database.Data.Select(
                x => new DataModel { Name = x.Name }).
                Where(x => x.Name.Contains(name)).
                ToListAsync<DataModel>();
        }

        public async Task<List<DataModel>> SelectByNameSkip(PageHelper helper)
        {
            return await _database.Data.Select(
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
                x => x.Name.Contains(helper.Name)).
                Skip(helper.SkippedItems).Take(helper.PageLimit).
                ToListAsync<DataModel>();
        }

        public async Task<List<DataModel>> SelectByNamePerPage(string name, int itemsPerPage)
        {
            return await _database.Data.Select(
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
                Take(itemsPerPage).ToListAsync<DataModel>();
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
    }
}
