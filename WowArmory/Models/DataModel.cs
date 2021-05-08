using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    public class DataModel : IData
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }
        public string Subclass { get; set; }
        public int SellPrice { get; set; }
        public string Quality { get; set; }
        public int ItemLevel { get; set; }
        public int RequiredLevel { get; set; }
        public string Slot { get; set; }
        public ICollection<TooltipModel> Tooltip { get; set; }
        public int VendorPrice { get; set; }
#nullable enable
        public int? ContentPhase { get; set; }
#nullable disable
        public SourceModel Source { get; set; }
        public string UniqueName { get; set; }
    }
}
