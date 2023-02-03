using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50,ErrorMessage ="En fazla 50 karakterli Olabilir")]
		[Required(ErrorMessage ="Bu Alan Boş geçilemez")]
		public string CustomerName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50,ErrorMessage ="En fazla 50 karakterli Olabilir")]
		[Required(ErrorMessage = "Bu Alan Boş geçilemez")]

		public string CustomerSurname { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50, ErrorMessage = "En fazla 50 karakterli Olabilir")]
		[Required(ErrorMessage = "Bu Alan Boş geçilemez")]

		public string CustomerCity { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50, ErrorMessage = "En fazla 50 karakterli Olabilir")]
		[Required(ErrorMessage = "Bu Alan Boş geçilemez")]
		public string CustomerMail { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string CustomerPassword { get; set; }

        public ICollection<SalesMovements> SalesMovementss { get; set; }
		public bool State { get; set; }


	}
}