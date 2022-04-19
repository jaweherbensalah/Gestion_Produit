using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class Category
    {  [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //many prods to one cat
        public virtual ICollection<Product> Products { get; set; }

    //    public override void GetDetails()
    //    { Console.WriteLine("CategoryId: " + CategoryId + "Name :" + Name); }
    }
}
