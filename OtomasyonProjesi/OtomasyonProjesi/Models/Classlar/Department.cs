using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
	public class Department
	{
		[Key]
		public int DepartmentId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string DepartmentName { get; set; }
		public bool State { get; set; }
		public ICollection<Personel> Personels { get; set; }
	}
}