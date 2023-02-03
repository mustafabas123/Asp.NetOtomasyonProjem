using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class SalesMovements
	{
		[Key]
		public int SalesId { get; set; }
		public DateTime Date { get; set; }
		public int Piece { get; set; }
		public decimal Price { get; set; }
		public decimal Total { get; set; }
		public int Productid { get; set; }
		public int Customerid { get; set; }
		public virtual Product Products { get; set; }
		public virtual Customer Customers { get; set; }
		public int Personelid { get; set; }
		public  virtual Personel Personels { get; set; }
	}
}