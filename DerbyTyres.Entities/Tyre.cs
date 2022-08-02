using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerbyTyres.Entities
{
    public class Tyre:BaseEntity
    {
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
        public float UsedStock { get; set; }
        public float NewStock { get; set; }
        public float UsedSold { get; set; }
        public float NewSold { get; set; }
        public string Brand { get; set; }
        public string LocatedIn { get; set; }
    }
}
