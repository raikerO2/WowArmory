using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    public class ProfessionsModel : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
