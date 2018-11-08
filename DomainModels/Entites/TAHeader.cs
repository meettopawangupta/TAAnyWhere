using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModels.Entites
{
    [Table("TA_Header")]
    public class TAHeader
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 TAHeaderPkId { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string TAName { get; set; }

        [Required]
        public Int64 TATravelTypePkId { get; set; }

        [ForeignKey("TATravelTypePkId")]
        public virtual TATravelType  TravelType { get; set; }

        [Required]
        public Int64 TAPurposePkId { get; set; }

        [ForeignKey("TAPurposePkId")]
        public virtual TAPurpose TravelPurpose { get; set; }
        [Required]
        [Column(TypeName ="Datetime")]
        public DateTime DateFrom { get; set; }

        [Required]
        [Column(TypeName = "Datetime")]
        public DateTime DateTo { get; set; }

        [Required]
        public Int64 EmployeePkId { get; set; }

        [ForeignKey("EmployeePkId")]
        public virtual TAEmployee Employee { get; set; }

        [Required]
        [Column(TypeName = "Datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


        [Required]
        [Column(TypeName = "Datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "Datetime")]
         public DateTime DeletedOn { get; set; }
    }
}