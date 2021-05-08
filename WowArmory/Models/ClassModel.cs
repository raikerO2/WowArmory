using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    [Table("Class")]
    public class ClassModel : IData
    {
        [Column("classid")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Class Id")]
        public int ClassId { get; set; }

        [Column("id")]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Column("c_name")]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("c_color")]
        [Display(Name = "Color")]
        [StringLength(50)]
        public string Color { get; set; }

        [Column("c_icon")]
        [Display(Name = "Icon")]
        [StringLength(50)]
        public string Icon { get; set; }

        [Column("specsid")]
        [Display(Name = "Specs")]
        public ICollection<SpecModel> Spec { get; set; }
    }
}
