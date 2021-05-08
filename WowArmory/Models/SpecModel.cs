using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    [Table("Spec")]
    public class SpecModel : IData
    {
        [Column("specid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Column("s_name")]
        [Display(Name="Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("s_icon")]
        [Display(Name="Icon")]
        [StringLength(50)]
        public string Icon { get; set; }
    }
}
