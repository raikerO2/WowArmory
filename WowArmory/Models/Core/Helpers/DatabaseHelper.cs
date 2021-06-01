using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Factory;
using WowArmory.Models.Core.Context;

namespace WowArmory.Models.Core.Helpers
{
    public static class DatabaseHelper
    {
        public static DatabaseContext DatabaseRead { get => Database; }
        private static DatabaseContext Database = new DatabaseContext(Build());
        private static List<DataModel> DatabaseList = new();
        private static DbContextOptions<DatabaseContext> Build()
        {
            DbContextOptions<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("data source=.;initial catalog=wow_armory;Integrated security=true")
            .Options;

            return options;
        }

        public static async Task<List<DataModel>> Add(string name)
        {
            DatabaseList = DatabaseList.Count == 0 ? await Database.Data.Select(x =>
            new DataModel
            {
                ItemId = x.ItemId,
                Icon = x.Icon,
                Name = x.Name,
                ItemLevel = x.ItemLevel,
                RequiredLevel = x.RequiredLevel,
                SellPrice = x.SellPrice,
                Subclass = x.Subclass
            }).Where(x => x.Name.Contains(name)).ToListAsync() : new List<DataModel>();
            return DatabaseList;
        }

        public static List<DataModel> SelectBySkip(PageHelper helper)
        {
            var query = DatabaseList.Skip(helper.SkippedItems).Take(helper.PageLimit).ToList();
            return query;
        }

        public static List<DataModel> SelectByPage(PageHelper helper)
        {
            var query = DatabaseList.Take(helper.PageLimit).ToList();
            return query;
        }

        public static void Reset()
        {
            DatabaseList = new();
        }
    }
}
