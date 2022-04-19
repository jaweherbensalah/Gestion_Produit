using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Data.Repository;
using Domain.Entities;

namespace Service
{
     public class FactureService:EntityService<Facture> {
        public FactureService():base()
        { }
        public Facture GetFactureById(int ProductId, int ClientId, DateTime DateAchat)
        { return this.GetAll().Where(f => f.ProductId == ProductId && f.ClientId == ClientId && f.DateAchat == DateAchat).FirstOrDefault(); }
        public IEnumerable<Facture> GetFactureByPrice(String prix)
        {
            return this.GetAll().Where(p => p.Prix >= float.Parse(prix));
        }

        public IEnumerable<Facture> GetFactureByPriceAndName(String prix,String name)
        {   if (!String.IsNullOrEmpty(prix) && String.IsNullOrEmpty(name))

                return this.GetAll().Where(p => p.Prix >= float.Parse(prix));
            else if (String.IsNullOrEmpty(prix) && !String.IsNullOrEmpty(name))
                return this.GetAll().Where(p => p.Product.Name.ToLower().Contains(name.ToLower()));
            else
            return this.GetAll().Where(p => p.Prix >= float.Parse(prix)&&  p.Product.Name.ToLower().Contains(name.ToLower()));
        }



    }
}
