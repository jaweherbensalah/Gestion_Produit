using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Product
        
    {     [Display(Name="production date")]
        [DataType(DataType.Date)]
        public DateTime  DateProd{ get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
       
        [Required( ErrorMessage = "name Not Matched")]
        [StringLength (25)]
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int ProductId { get; set; }
        [Range ( 1 ,100)]
        public int  Quality { get; set; }

        public string ImageName { get; set; }
    
       
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        //one category to many products
        public virtual Category Category { get; set; }
        //many providers to many products
        public virtual ICollection<Provider> Providers { get; set; }

        //many factures to one product:
        public ICollection<Facture> Factures { get; set; }





        //public override void GetDetails()
        //    { Console.WriteLine("ProductId: " + ProductId+"Name :"+Name+"DateProd :"+DateProd +"Description :"+Description); }

        //polymorphisme d'héritage:

        public  virtual void GetMyType()
        {
            Console.WriteLine("unknown");        }
    
    
    }
}
