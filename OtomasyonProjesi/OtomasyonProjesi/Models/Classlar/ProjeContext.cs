using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace OtomasyonProjesi.Models.Classlar
{
	public class ProjeContext:DbContext
	{
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Bills> Bills { get; set; }
		public DbSet <Category> Categories { get; set; }
		public DbSet <Customer> Customers { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Expenses> Expenses { get; set; }
		public DbSet<FaturaKalem> FaturaKalem { get; set; }
		public DbSet<Personel> Personeles { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<SalesMovements> SalesMovements { get; set;}
		public DbSet<Detail> Details { get; set; }
		public DbSet<ToDoList> ToDoLists { get; set; }
		public DbSet<CargoDetail> cargoDetails { get; set; }
		public DbSet<CargoTrack> cargoTracks { get; set; }
		public DbSet<Message> Messages { get; set; }
        public DbSet<New> News { get; set; }
    }
}