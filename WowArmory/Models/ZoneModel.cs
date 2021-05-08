using System;
using System.Collections.Generic;
using System.Linq;
using WowArmory.Models.Core;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WowArmory.Models
{
    [Table("Zone")]
    public class ZoneModel : IData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("zoneid")]
        [Display(Name="Zone Id")]
        public int ZoneId { get; set; }

        [Column("id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("z_name")]
        [Display(Name = "Name")]
        [StringLength(500)]
        public string Name { get; set; }

        [Column("z_category")]
        [Display(Name = "Category")]
        [StringLength(500)]
        public string Category { get; set; }

        [Column("z_territory")]
        [Display(Name = "Territory")]
        [StringLength(500)]
        public string Territory { get; set; }

        [Column("z_level")]
        [Display(Name = "Level")]
#nullable enable
        public LevelModel? Level { get; set; }
    }
}
