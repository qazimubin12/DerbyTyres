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

            return RedirectToAction("Index", "Inventory");
        }
    }
}