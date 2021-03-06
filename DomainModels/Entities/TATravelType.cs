﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModels.Entites
{
    [Table("TA_TravelType")]
    public class TATravelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Int64 TravelTypePkId { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string TravelType { get; set; }

        [Required]
        [Column(TypeName = "Nvarchar")]
        [StringLength(50)]
        public string TravelTypeDescirption { get; set; }
    }
}