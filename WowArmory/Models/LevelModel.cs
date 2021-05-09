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

#nullable enable
        [Column("level1")]
        [Display(Name = "Level1")]
        public int? Level1 { get; set; }

        [Column("level2")]
        [Display(Name = "Level2")]
        public int? Level2 { get; set; }
    }
}
