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
   public class ServiceCategory: EntityService<Category>
    { 
        public ServiceCategory(): base()
            { }
    }
}
