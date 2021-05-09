using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models;
using WowArmory.Models.Core;
using WowArmory.Models.Core.Context;

namespace WowArmory.Factory
{
    public class DataEntry
    {
        private IConfiguration _configuration;
        private DatabaseContext _database;

        public DataEntry(DatabaseContext database, IConfiguration configuration)
        {
            _database = database;
            _configuration = configuration;
        }
        public void InsertRecords<T>(string data)
        {
            string jsonFile = System.IO.File.ReadAllText(_configuration[$"JsonData:{data}"]);
            if (data == "Zones")
            {
                MapData(data);
            }
            else
            {
                List<T> Data = JsonConvert.DeserializeObject<List<T>>(jsonFile);
                foreach (var model in Data)
                {
                    _database.Add(model);
                    _database.SaveChanges();
                }
            }
        }

        private void MapData(string data)
        {
            string zonesJsonFile = System.IO.File.ReadAllText(_configuration[$"JsonData:{data}"]);
            List<ZoneModelMapper> zoneMapperData = new List<ZoneModelMapper>();
            List<ZoneModel> zoneData = new List<ZoneModel>();
            zoneMapperData = JsonConvert.DeserializeObject<List<ZoneModelMapper>>(zonesJsonFile);

            foreach (var model in zoneMapperData)
            {
                if (String.IsNullOrEmpty(model.Level[0]) || String.IsNullOrEmpty(model.Level[1]))
                {
                    model.Level[0] = 0.ToString();
                    model.Level[1] = 0.ToString();
                }
                var level = new LevelModel
                {
                    Level1 = Int32.Parse(model?.Level[0]),
                    Level2 = Int32.Parse(model?.Level[1])
                };
                var mapping = new ZoneModel
                {
                    Id = model.Id,
                    Category = model.Category,
                    ZoneId = model.ZoneId,
                    Level = level,
                    Name = model.Name,
                    Territory = model.Territory
                };

                _database.Add(mapping);
                _database.SaveChanges();
            }
        }
    }
}

    
