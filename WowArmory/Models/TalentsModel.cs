using System;
using System.Collections.Generic;
using System.Linq;
using WowArmory.Models.Core;
using System.Threading.Tasks;

namespace WowArmory.Models
{
    public class TalentsModel : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TooltipModel> ToolTip { get; set; }
    }
}
