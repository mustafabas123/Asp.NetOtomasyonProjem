using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
    public class New
    {
        [Key]
        public int NewId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string NewKonu { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2500)]
        public string NewIcerik { get; set; }
        public DateTime Date { get; set; }
    }
}