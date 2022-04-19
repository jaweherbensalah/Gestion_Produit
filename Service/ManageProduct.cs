using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Service
{
    public class ManageProduct
    { //*************Ctor par défaut:
        private List<Product> Products;
        public ManageProduct(List <Product> products)
        {
            this.Products = products;
        }

        public delegate void FindProduct(string c);
        public delegate void ScanProduct(Category category);

        //*******Partie 7 LINQ:
        public void Get5Chemical(double price)
        { var query = (from p in Products where p is Chemical && (p.Price > price) select p).ToList().Take(5);
          
            //foreach(Product pr in query) { pr.GetDetails(); }
        }

        public void GetProductPrice(double price)
        { var query = (from p in Products where (p.Price > price) select p).ToList().Skip(2);
           // foreach (Product pr in query) { pr.GetDetails(); }
        }

        public void GetAveragePrice(double price)
        {
            var query = (from p in Products where (p.Price > price) select p).ToList().Skip(2);
        }
        //*******************************************************************
        public double GetAveragePrice()
        {
            return (from product in Products
                    select product.Price)
                    .Average();
        }



        public double GetMaxPrice()
        {
            return (from product in Products
                    select product.Price).Max();
        }

        //public int GetCountProduct(string city)
        //{
        //    return (from product in products
        //            where product is Chemical && ((Chemical)product).City == city
        //            select product).Count();
        //}
    }
}
