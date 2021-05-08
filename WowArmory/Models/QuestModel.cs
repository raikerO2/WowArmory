using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;


namespace WowArmory.Models
{
    public class QuestModel : IData
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public string Name { get; set; }
        public string Faction { get; set; }
    }
}
