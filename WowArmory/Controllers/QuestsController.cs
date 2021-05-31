using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Factory;
using WowArmory.Models;
using WowArmory.Models.Core.Context;
using WowArmory.Models.Core.Helpers;

namespace WowArmory.Controllers
{
    public class QuestsController : Controller
    {
        private DatabaseContext _db = null;
        private PageHelper _pageHelper;

        public QuestsController(DatabaseContext db, PageHelper pageHelper)
        {
            _db = db;
            _pageHelper = pageHelper;
        }

        public IActionResult Index()
        {
            var quests = SelectQuests(20);

            _pageHelper.Startup<SourceModel>(quests);
            //this.BindToView(_pageHelper);

            return View(quests);
        }

        private List<SourceModel> SelectQuests(int number)
        {
            var quests = _db.Sources.Select(x => new SourceModel
            {
                Category = x.Category,
                Quests = x.Quests.Select(y => new QuestModel
                {
                    Name = y.Name,
                    Faction = y.Faction,
                }).ToList()
            }).Take(number).ToList();

            return quests;
        }
    }
}
