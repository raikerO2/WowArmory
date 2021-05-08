using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;

namespace WowArmory.Models
{
    [Table("Data")]
    public class DataModel : IData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("dataid")]
        [Display(Name="Data Id")]
        public int DataId { get; set; }

        [Column("itemid")]
        [Display(Name ="Item Id")]
        public int ItemId { get; set; }

        [Column("d_name")]
        [Display(Name = "Name")]
        [StringLength(500)]
        public string Name { get; set; }

        [Column("d_icon")]
        [Display(Name = "Icon")]
        [StringLength(500)]
        public string Icon { get; set; }

        [Column("d_class")]
        [Display(Name = "Class")]
        [StringLength(500)]
        public string Class { get; set; }

        [Column("d_subclass")]
        [Display(Name = "Sub Class")]
        [StringLength(500)]
        public string Subclass { get; set; }

        [Column("d_sellprice")]
        [Display(Name = "Sell Price")]
        public int SellPrice { get; set; }

        [Column("d_quality")]
        [Display(Name = "Quality")]
        [StringLength(500)]
        public string Quality { get; set; }

        [Column("d_itemlevel")]
        [Display(Name = "Item Level")]
        public int ItemLevel { get; set; }

        [Column("d_requiredlevel")]
        [Display(Name = "Required Level")]
        public int RequiredLevel { get; set; }

        [Column("d_slot")]
        [Display(Name = "Slot")]
        [StringLength(500)]
        public string Slot { get; set; }

        [Column("d_vendorprice")]
        [Display(Name = "Vendor Price")]
        public int VendorPrice { get; set; }

        [Column("d_source")]
        [Display(Name = "Source")]
        public SourceModel Source { get; set; }

        [Column("d_uniquename")]
        [Display(Name = "Unique Name")]
        [StringLength(500)]
        public string UniqueName { get; set; }

        [Column("d_tooltip")]
        [Display(Name = "Tooltip")]
#nullable enable
        public ICollection<TooltipModel>? Tooltip { get; set; }

        [Column("d_contentphase")]
        [Display(Name = "Content Phase")]
        public int? ContentPhase { get; set; }
    }
}
