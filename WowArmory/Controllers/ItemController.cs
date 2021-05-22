using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models;
using WowArmory.Models.Core.Context;

namespace WowArmory.Controllers
{
    public class ItemController : Controller
    {
        private DatabaseContext _database;

        public ItemController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Item(int id)
        {
            if (id != 0)
            {
                var itemResult = await _database.Data.Select(x => new DataModel
                {
                    ItemId = x.ItemId,
                    Icon = x.Icon,
                    Name = x.Name,
                    ItemLevel = x.ItemLevel,
                    RequiredLevel = x.RequiredLevel,
                    SellPrice = x.SellPrice,
                    Subclass = x.Subclass,
                    Source = x.Source != null ? new SourceModel
                    {
                        SourceId = x.Source.SourceId,
                        Category = x.Source.Category,
                        Cost = x.Source.Cost,
                        Faction = x.Source.Faction,
                        Name = x.Source.Name,
                        Quests = x.Source.Quests.Select(z => new QuestModel
                        {
                            Id = z.Id,
                            Faction = z.Faction,
                            Name = z.Name,
                            QuestId = z.QuestId
                        }).ToList(),
                    } : x.Source,
                    Class = x.Class,
                    ContentPhase = x.ContentPhase,
                    Quality = x.Quality,
                    Slot = x.Slot,
                    Tooltip = x.Tooltip,
                    VendorPrice = x.VendorPrice
                }).Where(x => x.ItemId == id).FirstOrDefaultAsync();

                //TO DO - join sourceid with the quest table id to show all of the quests with that id
                // var resultQuery = from studentid in  

                if (itemResult != null)
                    return View("Index", itemResult);
            }
            return View("Index");
        }
    }
}
