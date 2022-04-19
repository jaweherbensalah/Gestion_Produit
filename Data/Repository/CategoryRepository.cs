using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Repository
{
    public class CategoryRepository: RepositoryBase<Category>
    {
        private DatabaseFactory DbFactory = new DatabaseFactory();
       public CategoryRepository( DatabaseFactory db):base(db)
        {
            DbFactory = db;
        }
    }
}
