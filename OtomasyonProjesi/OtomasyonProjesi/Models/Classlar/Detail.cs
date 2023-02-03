﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
    public class Detail
    {
        [Key]
        public int DetailId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]

        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string ProductDescription { get; set; }
    }
}