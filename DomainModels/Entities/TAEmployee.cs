using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModels.Entites
{
    [Table("TA_Employee")]
    public class TAEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 EmployeePkId { get; set; }

        [Required]
        [Column(TypeName ="Nvarchar")]
        [StringLength(50)]
        public String EmployeeName { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public String UserName { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

       
        [Column(TypeName = "bigint")]
         public Int64 Phone { get; set; }
    }
}