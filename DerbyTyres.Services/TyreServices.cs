using DerbyTyres.Database;
using DerbyTyres.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerbyTyres.Services
{
    public class TyreServices
    {
        #region Singleton
        public static TyreServices Instance
        {
            get
            {
                if (instance == null) instance = new TyreServices();
                return instance;
            }
        }
        private static TyreServices instance { get; set; }
        private TyreServices()
        {
        }
        #endregion


        public Tyre GetTyre(int ID)
        {
            using (var context = new DSContext())
            {
                return context.Tyres.Find(ID);
            }
        }

        public Tyre GetTyre(string TireSizeDesignation)
        {
            using (var context = new DSContext())
            {
                return context.Tyres.Where(x => x.TireSizeDesignation == TireSizeDesignation).FirstOrDefault();
            }
        }

        public List<Tyre> GetTyres(string SearchTerm = "")
        {
            List<Tyre> Tyres = null;
            using (var context = new DSContext())
            {
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Tyres = context.Tyres.Where(x => x.TireSizeDesignation != null && x.TireSizeDesignation.ToLower().Contains(SearchTerm.ToLower())).ToList();
                }
                else
                {
                    Tyres = context.Tyres.ToList();
                }
            }
            return Tyres;
        }


        public List<Tyre> GetTyresLowStocks(string SearchTerm = "")
        {
            List<Tyre> Tyres = null;
            using (var context = new DSContext())
            {
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Tyres = context.Tyres.Where(x => x.Stock < 10 && x.TireSizeDesignation.ToLower().Contains(SearchTerm.ToLower())).ToList();
                }
                else
                {
                    Tyres = context.Tyres.Where(x => x.Stock < 10).ToList();

                }
            }
            return Tyres;
        }


        public void SaveTyre(Tyre Tyre)
        {
            using (var context = new DSContext())
            {
                context.Tyres.Add(Tyre);
                context.SaveChanges();
            }
        }

        public void UpdateTyre(Tyre Tyre)
        {
            using (var context = new DSContext())
            {
                context.Entry(Tyre).State = EntityState.Modified;
                context.SaveChanges();
            }
        }



        public void DeleteTyre(int ID)
        {
            using (var context = new DSContext())
            {

                var Tyre = context.Tyres.Find(ID);
                context.Tyres.Remove(Tyre);
                context.SaveChanges();
            }
        }

    }
}
