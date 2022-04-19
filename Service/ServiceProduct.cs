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
    public class ServiceProduct: EntityService<Product>
    {
        public ServiceProduct() : base() 
        { }
    public IEnumerable<Product> GetProductByName(string Name)
        {
            return this.GetAll().Where(p => p.Name.ToLower().Contains(Name.ToLower()));
        }
    }
}
