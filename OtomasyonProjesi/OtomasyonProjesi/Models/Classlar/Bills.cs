using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Bills
	{
		[Key]
		public int BillsId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string  BillsSeriNo { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string BillsSiraNo { get; set; }
		public DateTime BillsDate { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string TaxAdministration { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Clock { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string submitterName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string deliveryName { get; set; }

		public decimal Total { get; set; }
		public ICollection<FaturaKalem> FaturaKalems {get; set; } 
	}
}