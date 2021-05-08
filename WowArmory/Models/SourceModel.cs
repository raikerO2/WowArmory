using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    public class SourceModel : IData
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Faction { get; set; }
        public int Cost { get; set; }

#nullable enable
        public ICollection<QuestModel>? Quests { get; set; }
    }
}
