using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Personel
	{
		[Key]
		public int PersonelId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string PersonelName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string PersonelSurname { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(350)]
		public string ImageUrl { get; set; }
		public ICollection<SalesMovements> SalesMovementss { get; set; }

		public int Departmentid { get; set; }
		public virtual Department Departments { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelAdress { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string PersonelPhone { get; set; }
	}
}