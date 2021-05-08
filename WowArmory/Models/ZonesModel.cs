using System;
using System.Collections.Generic;
using System.Linq;
using WowArmory.Models.Core;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WowArmory.Models
{
    public class ZonesModel : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        [NotMapped]
        public ICollection<int> Level { get; set; }

        public string Territory { get; set; }

    }
}
