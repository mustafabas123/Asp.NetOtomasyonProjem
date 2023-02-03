using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
    public class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }


        [Column(TypeName ="Varchar")]
        [StringLength(250)]
        public string Title { get; set; }

        public bool State { get; set; } 
    }
}