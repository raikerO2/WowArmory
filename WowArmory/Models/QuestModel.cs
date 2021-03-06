using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WowArmory.Models.Core;


namespace WowArmory.Models
{
    [Table("Quest")]
    public class QuestModel : IData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Column("questid")]
        [Display(Name="Quest Id")]
        public int QuestId { get; set; }

        [Column("q_name")]
        [Display(Name="Name")]
        [StringLength(500)]
        public string Name { get; set; }
        
        [Column("q_faction")]
        [Display(Name="Faction")]
        [StringLength(500)]
        public string Faction { get; set; }
    }
}
