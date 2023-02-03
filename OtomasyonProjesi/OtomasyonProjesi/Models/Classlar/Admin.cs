using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }

		[Column(TypeName ="Varchar")]
		[StringLength(50)]
		public string AdminName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string AdminPassword { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string authorized { get; set; }
	}
}