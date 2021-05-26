using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core.Context;

namespace WowArmory.Models.Core
{
    public class DataHelper
    {
        private DatabaseContext _database = null;

        public DataHelper(DatabaseContext db)
        {
            _database = db;
        }

        public List<DataModel> GetByName(string name)
        {
            return SelectDataModel()
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

        public List<DataModel> GetPerPage(string name, int limit)
        {
            return SelectDataModel()
                .Take(limit)
                .Where(x => x.Name.Contains(name))
                .ToList();
        }

        public async Task<List<DataModel>> GetPerPageAsync(string name, int limit)
        {
            return await SelectDataModel()
                .Where(x => x.Name.Contains(name))
                .Take(limit)
                .ToListAsync();
        }

        public List<DataModel> GetAllItems(string name)
        {
            if(String.IsNullOrEmpty(name))
                return new List<DataModel>();
                
            return SelectDataModel()
                .Where(x => x.Name.Contains(name))
                .ToList();
        }
        
        public async Task<List<DataModel>> GetAllItemsAsync(string name)
        {
            return await SelectDataModel()
                .Where(x => x.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<List<DataModel>> GetByNameAsync(string name)
        {
            return await SelectDataModel()
                .Where(x => x.Name.Contains(name))
                .ToListAsync();
        }

        public List<DataModel> GetSkip(string name, int limit, int skip)
        {
            return SelectDataModel()
                .Where(x => x.Name.Contains(name))
                .Skip(skip).Take(limit)
                .ToList();
        }

        public async Task<List<DataModel>> GetSkipAsync(string name, int limit, int skip)
        {
            return await SelectDataModel()
                .Where(x => x.Name.Contains(name))
                .Skip(skip).Take(limit)
                .ToListAsync();
        }
            
        public IQueryable<DataModel> SelectDataModel()
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
            });
        }
    }
}
