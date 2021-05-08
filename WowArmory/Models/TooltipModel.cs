using System;
using System.Collections.Generic;
using System.Linq;
using WowArmory.Models.Core;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WowArmory.Models
{
    [Table("Tooltip")]
    public class TooltipModel : IData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tooltipid")]
        [Display(Name ="Tooltip")]
        public int TooltipId { get; set; }

        [Column("id")]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Column("t_label")]
        [Display(Name ="Label")]
        [StringLength(1000)]

        public string Label { get; set; }
#nullable enable
        [Column("t_format")]
        [Display(Name ="Format")]
        [StringLength(500)]
        public string? Format { get; set; }
    }
}
