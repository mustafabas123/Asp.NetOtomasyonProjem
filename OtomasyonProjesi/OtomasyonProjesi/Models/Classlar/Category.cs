using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Category
	{
		[Key] //bu propotriessin 1. anahtar olmasını sağladı
		public int CategoryId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string CategoryName { get; set; }
		public ICollection<Product> Products { get; set;}
	}
}