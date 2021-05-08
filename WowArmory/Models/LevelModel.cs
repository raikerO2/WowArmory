using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WowArmory.Models
{
    [Table("Level")]
    public class LevelModel
    {
        [Key]
        [Column("levelid")]
        [Display(Name="Level Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelId { get; set; }

        [Column("val1")]
        [Display(Name = "Val1")]
        public int Val1 { get; set; }

        [Column("val2")]
        [Display(Name = "Val2")]
        public int Val2 { get; set; }
    }
}
