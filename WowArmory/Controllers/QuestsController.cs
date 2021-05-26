using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models;
using WowArmory.Models.Core.Context;

namespace WowArmory.Controllers
{
    public class QuestsController : Controller
    {
        private DatabaseContext _db = null;

        public QuestsController(DatabaseContext db)
        {
            _db = db;
        }


        private IQueryable<SourceModel> SelectQuests()
        {
            var quests = _db.Sources.Select(x => new SourceModel
            {
                Category = x.Category,
                Quests = x.Quests.Select(y => new QuestModel
                {
                    Name = y.Name,
                    Faction = y.Faction,
                }).ToList()
            });

            return quests;
        }

        public IActionResult Index()
        {
            var quests = SelectQuests().Take(350).ToList();

            return View(quests);
        }
    }
}
