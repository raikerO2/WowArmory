using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowArmory.Models
{
    public class ZoneModelMapper
    {
        public int ZoneId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Territory { get; set; }
#nullable enable
        public string[]? Level { get; set; }
    }
}
