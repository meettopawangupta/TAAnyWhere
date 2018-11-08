using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entites
{
    [Table("TA_I18NResource")]
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ResourcePkId { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(4000)]
        public string Value { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(10)]
        public string Culture { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(25)]
        public string Type { get; set; }


        public Resource() {
            //Type = "string";  
        }
    }
}
