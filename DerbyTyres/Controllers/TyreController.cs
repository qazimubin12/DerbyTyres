using DerbyTyres.Entities;
using DerbyTyres.Services;
using DerbyTyres.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DerbyTyres.Controllers
{
    public class TyreController : Controller
    {
        // GET: Tyre
        public ActionResult Index(string SearchTerm = "")
        {
            TyreListingViewModel model = new TyreListingViewModel();
            model.Tyres = TyreServices.Instance.GetTyres(SearchTerm);
            return View(model);
        }




        [HttpGet]
        public ActionResult Import()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please Select Excel File";
                return View();
            }
            else
            {
                bool isPresent = false;
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    excelfile.SaveAs(path);

                    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Open(path);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;
                    List<Tyre> list = new List<Tyre>();
                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        var Tyre = new Tyre();
                        Tyre.TireSizeDesignation = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 1]).Text;
                        Tyre.ODmm = int.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 2]).Text);
                        Tyre.ODin = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 3]).Text);
                        Tyre.SWmm = int.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 4]).Text);
                        Tyre.SWin = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 5]).Text);
                        Tyre.AR = int.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 6]).Text);
                        Tyre.SHmm = int.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 7]).Text);
                        Tyre.SHin = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 8]).Text);
                        Tyre.CLmm = int.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 9]).Text);
                        Tyre.CLin = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 10]).Text);
                        Tyre.REkm = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 11]).Text);
                        Tyre.REmile = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 12]).Text);
                        Tyre.UsedTyres = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 13]).Text;
                        Tyre.UsedStock = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 14]).Text);
                        Tyre.BrandNewTyres = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 15]).Text;
                        Tyre.NewStock = float.Parse(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 16]).Text);
                        Tyre.Brand = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 17]).Text;
                        Tyre.LocatedIn = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 18]).Text;
                        var List = TyreServices.Instance.GetTyres();

                        if (List.Count != 0)
                        {
                            foreach (var item in List)
                            {
                                if (item.TireSizeDesignation == Tyre.TireSizeDesignation && item.ODmm == Tyre.ODmm && item.Brand == Tyre.Brand)
                                {
                                    isPresent = true;
                                    break;
                                }
                                else
                                {
                                    isPresent = false;
                                }




                            }
                            if (isPresent == false)
                            {
                                list.Add(Tyre);
                                TyreServices.Instance.SaveTyre(Tyre);
                            }


                        }
                        else
                        {
                            list.Add(Tyre);
                            TyreServices.Instance.SaveTyre(Tyre);
                        }

                    }
                    ViewBag.ListTyres = list;
                    return View();
                }
                else
                {
                    ViewBag.Error = "Incorrect File";

                    return View();
                }
            }

            //var Prcoess = Process.GetProcessesByName("EXCEL.EXE").FirstOrDefault();
            //Prcoess.Kill();

        }



        [HttpPost]
        public ActionResult NewAction(int id, string propertyname, string value)
        {
            var status = false;
            var message = "";

            var Tyre = TyreServices.Instance.GetTyre(id);


            if (Tyre != null)
            {


                if (propertyname == "TireSizeDesignation")
                {
                    Tyre.TireSizeDesignation = value;
                }
                if (propertyname == "BrandNewTyres")
                {
                    Tyre.BrandNewTyres = "£" + value;
                }
                if (propertyname == "UsedTyres")
                {
                    Tyre.UsedTyres = "£" + value;
                }
                if (propertyname == "AR")
                {
                    Tyre.AR = int.Parse(value);
                }
                if (propertyname == "ODmm")
                {
                    Tyre.ODmm = int.Parse(value);
                }
                if (propertyname == "SWmm")
                {
                    Tyre.SWmm = int.Parse(value);
                }
                if (propertyname == "SHmm")
                {
                    Tyre.SHmm = int.Parse(value);
                }
                if (propertyname == "CLmm")
                {
                    Tyre.CLmm = int.Parse(value);
                }
                if (propertyname == "ODin")
                {
                    Tyre.ODin = float.Parse(value);
                }
                if (propertyname == "SWin")
                {
                    Tyre.SWin = float.Parse(value);
                }
                if (propertyname == "SHin")
                {
                    Tyre.SHin = float.Parse(value);
                }
                if (propertyname == "CLin")
                {
                    Tyre.CLin = float.Parse(value);
                }
                if (propertyname == "REkm")
                {
                    Tyre.REkm = float.Parse(value);
                }
                if (propertyname == "REmile")
                {
                    Tyre.REmile = float.Parse(value);
                }
                if (propertyname == "UsedStock")
                {
                    Tyre.UsedStock = float.Parse(value);

                }
                if (propertyname == "NewStock")
                {
                    Tyre.NewStock = float.Parse(value);
                }
                if (propertyname == "UsedSold")
                {
                    Tyre.UsedSold = float.Parse(value);

                }
                if (propertyname == "NewSold")
                {
                    Tyre.NewStock = float.Parse(value);
                }
                if (propertyname == "Brand")
                {
                    Tyre.BrandNewTyres = value;
                }
                if (propertyname == "LocatedIn")
                {
                    Tyre.LocatedIn = value;
                }



                TyreServices.Instance.UpdateTyre(Tyre);
                status = true;
            }
            else
            {
                message = "error!";
            }


            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
            return Content(o.ToString());
        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            TyreListingViewModel model = new TyreListingViewModel();
            var ad = TyreServices.Instance.GetTyre(ID);
            model.ID = ad.ID;
            return View("Delete", model);
        }

        [HttpPost]
        public ActionResult Delete(TyreListingViewModel model)
        {

            if (model.ID != 0) //we are trying to delete a record
            {
                var ad = TyreServices.Instance.GetTyre(model.ID);
                TyreServices.Instance.DeleteTyre(ad.ID);

            }
            return RedirectToAction("Index", "Ads");

        }


    }
}