using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class FaturaKalem
	{
		[Key]
		public int FaturaKalemId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string Aciklama { get; set; }
		public int Miktar { get; set; }
		public decimal	BirimFiyat { get; set; }
		public decimal Tutar { get; set; }
		public int Billsid { get; set; }

        public virtual Bills Bills { get; set; }
	}
}