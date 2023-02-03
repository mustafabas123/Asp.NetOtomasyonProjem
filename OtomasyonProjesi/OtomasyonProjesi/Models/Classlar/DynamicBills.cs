using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtomasyonProjesi.Models.Classlar
{
    public class DynamicBills
    {
        public IEnumerable<Bills> Bills { get;set; }
        public IEnumerable<FaturaKalem> FaturaKalems { get;set; }
    }
}