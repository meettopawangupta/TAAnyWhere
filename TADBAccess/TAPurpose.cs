using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TravelDataAccess
{
    [Table("TA_Purpose")]
    public class TAPurpose
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 TravelPurposePkId { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string TravelPurpose { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string TravelPurposeDescirption { get; set; }
    }
}