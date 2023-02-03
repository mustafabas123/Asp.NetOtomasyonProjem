using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
    public class CargoTrack
    {
        [Key]
        public int CargoTrackid { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(20)]
        public string TrackingCode { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(200)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}