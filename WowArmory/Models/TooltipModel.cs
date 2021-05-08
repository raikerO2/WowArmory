using System;
using System.Collections.Generic;
using System.Linq;
using WowArmory.Models.Core;
using System.Threading.Tasks;

namespace WowArmory.Models
{
    public class TooltipModel : IData
    {
        public int Id { get; set; }
        public string Label { get; set; }
#nullable enable
        public string? Format { get; set; }
    }
}
