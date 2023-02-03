using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string ProductName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string Mark { get; set; }
	

		public int Stock { get; set; }


		public decimal BuyingPrice { get; set; }
		public decimal SellingPrice { get; set; }
		public bool State { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string ImageUrl { get; set; }
		public int Categoryid { get; set; }
		public virtual Category Category { get; set; }

		public ICollection<SalesMovements> SalesMovementss { get; set;}
	}
}