using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Expenses
	{
		[Key]
		public int ExpensesId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public decimal Price { get; set; }
	}
}