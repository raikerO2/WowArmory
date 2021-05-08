using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    [Table("Source")]
    public class SourceModel : IData
    {
        [Key]
        [Column("sourceid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Source Id")]
        public int SourceId { get; set; }

        [Column("s_category")]
        [Display(Name="Category")]
        [StringLength(500)]
        public string Category { get; set; }

        [Column("s_name")]
        [Display(Name="Name")]
        [StringLength(500)]
        public string Name { get; set; }

        [Column("s_faction")]
        [Display(Name="Faction")]
        [StringLength(500)]
        public string Faction { get; set; }

        [Column("s_cost")]
        [Display(Name="Cost")]
        public int Cost { get; set; }

#nullable enable
        [Column("s_quests")]
        [Display(Name="Quests")]
        public ICollection<QuestModel>? Quests { get; set; }
    }
}
