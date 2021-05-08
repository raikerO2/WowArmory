using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    [Table("Profession")]
    public class ProfessionModel : IData
    {
        [Key]
        [Column("professionid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Profession Id")]
        public int ProfessionId { get; set; }

        [Column("id")]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Column("p_name")]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Column("i_icon")]
        [StringLength(50)]
        [Display(Name="Icon")]
        public string Icon { get; set; }
    }
}
