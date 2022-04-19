using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service
{
    class ManageCategory
    {
        private List<Category> Categories;
         public ManageCategory(List<Category> categories)
        {
            this.Categories = categories;
        }
    }
}
