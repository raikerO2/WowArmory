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
        private DatabaseContext _database = null;
        private PageHelper _pageHelper = null;

        public ItemsController(DatabaseContext database, PageHelper pageHelper)
        {
            _database = database;
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
            DatabaseHelper.Reset();
            if (String.IsNullOrEmpty(name))
            {
                _pageHelper.Dispose(null);
                this.BindToView(_pageHelper);
                return View();
            }

            var query = await DatabaseHelper.Add(name);
            _pageHelper.Startup<DataModel>(query, contains: name);

            List<DataModel> items = DatabaseHelper.SelectByPage(_pageHelper);
            this.BindToView(_pageHelper);

            return View(items);
        }

        [HttpGet]
        [Route("items/next")]
        public IActionResult NextItems()
        {
            _pageHelper.SkipNext(_pageHelper.PageLimit);
            List<DataModel> nextItems = DatabaseHelper.SelectBySkip(_pageHelper);
            _pageHelper.NextPage(nextItems);

            this.BindToView(_pageHelper);
            return View("Items", nextItems);
        }

        [HttpGet]
        [Route("items/previous")]
        public IActionResult PreviousItems()
        {
            //_pageHelper.SkipPrevious(_pageHelper.PageLimit);
            List<DataModel> previousItems = DatabaseHelper.SelectBySkip(_pageHelper);
            var previousPage = _pageHelper.PreviousPage<DataModel>(previousItems);

            if (previousPage)
            {
                previousItems = DatabaseHelper.SelectBySkip(_pageHelper);
                this.BindToView(_pageHelper);
                return View("Items", previousItems);
            }
            else
            {
                this.BindToView(_pageHelper);
                return View("Items", previousItems);
            }
        }
    }
}
