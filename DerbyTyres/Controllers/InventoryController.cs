using DerbyTyres.Services;
using DerbyTyres.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DerbyTyres.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index(string Search = "")
        {
            InventoryViewModel model = new InventoryViewModel();
            model.StockAvailableTires = TyreServices.Instance.GetTyres(Search);
            return View(model);
        }


        [HttpPost]
        public ActionResult Action(int ID, int Sold)
        {
            var Tyre = TyreServices.Instance.GetTyre(ID);
            float TyreNewStock = Tyre.NewStock - Sold;
            float TyreNewSold = Tyre.NewSold + Sold;
            Tyre.NewSold = TyreNewSold;
            Tyre.NewStock = TyreNewStock;
            TyreServices.Instance.UpdateTyre(Tyre);
            return RedirectToAction("Index", "Inventory");
        }


        [HttpPost]
        public ActionResult ActionUsed(int ID, int Sold)
        {
            var Tyre = TyreServices.Instance.GetTyre(ID);
            float TyreUsedStock = Tyre.UsedStock - Sold;
            float TyreUsedSold = Tyre.UsedSold + Sold;
            Tyre.UsedSold = TyreUsedSold;
            Tyre.UsedStock = TyreUsedStock;
            TyreServices.Instance.UpdateTyre(Tyre);

            return RedirectToAction("Index", "Inventory");
        }
    }
}