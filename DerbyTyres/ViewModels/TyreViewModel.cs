using DerbyTyres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DerbyTyres.ViewModels
{
    public class TyreListingViewModel
    {
        public List<Tyre> Tyres { get; set; }
        public string SearchTerm { get; set; }
        public int ID { get; set; }
        public string TireSizeDesignation { get; set; }
        public int ODmm { get; set; }
        public float ODin { get; set; }
        public int SWmm { get; set; }
        public float SWin { get; set; }
        public int AR { get; set; }
        public int SHmm { get; set; }
        public float SHin { get; set; }
        public int CLmm { get; set; }
        public float CLin { get; set; }
        public float REkm { get; set; }
        public float REmile { get; set; }
        public string UsedTyres { get; set; }
        public string BrandNewTyres { get; set; }
        public float Stock { get; set; }
    }

   
}