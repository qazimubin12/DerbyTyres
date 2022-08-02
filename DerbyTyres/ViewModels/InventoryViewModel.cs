using DerbyTyres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DerbyTyres.ViewModels
{
    public class InventoryViewModel
    {
        public string SearchTerm { get; set; }
        public List<Tyre> StockAvailableTires { get; set; }
    }
}