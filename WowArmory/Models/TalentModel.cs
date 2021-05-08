using System;
using System.Collections.Generic;
using System.Linq;
using WowArmory.Models.Core;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WowArmory.Models
{
    [Table("Talent")]
    public class TalentModel : IData
    {
        [Key]
        [Column("talentid")]
        [Display(Name="Talent Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TalentId { get; set; }

        [Column("id")]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Column("t_name")]
        [Display(Name="Name")]
        [StringLength(200)]
        public string Name { get; set; }

#nullable enable
        [Column("t_tooltip")]
        [Display(Name="Tool Tip")]
        public ICollection<TooltipModel>? ToolTip { get; set; }
    }
}
