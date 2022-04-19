using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Service;
using Data;

namespace Console
{
    class Program
    {
        static void Main(string[] args)

        {
            GestionProduitContext context = new GestionProduitContext();
            Product prd = new Product() { Name = "produit1", Price = 50, Quality = 3, DateProd = DateTime.Now };
            context.Products.Add(prd);
            context.SaveChanges();
            
            
            
            
            
            
            
            
            
            
            //crréer un objet provider
          //Provider p1 = new Provider()
          //{ 
          //Password = "12345",
          //ConfirmPassword= "12345",
          //UserName="jaweher",
          //Email= "jaweher@gmail"
          //};

            //bool result = p1.login("jaweher", "12345");
            //bool result1 = p1.login("jaweher", "12345","jaweher@gmail22222222222");



            //*******************************
            //tester les 2fonctions setisapproved
            //c'est une fct static donc on peut l'appeler via la classe

            //Provider.SetIsApproved(p1.Password, p1.ConfirmPassword, p1.IsApproved);
            //System.Console.WriteLine("teste du passge par valeur is approved est égale à : "+p1.IsApproved);
            //    System.Console.ReadKey();
            ////tester le passage par référence:
            //Provider.SetIsApproved(p1);
            //System.Console.WriteLine("teste du passge par valeur is approved este égale à : " + p1.IsApproved);


            //if (result) System.Console.WriteLine("login successful");
            //else System.Console.WriteLine("login failed");
            //System.Console.ReadKey();
            ////****************************************************
            //if (result1) System.Console.WriteLine("login successful");
            //else System.Console.WriteLine("login failed");
            //System.Console.ReadKey();





            //****polymorphisme d'héritage:
            //Product prod = new Product();
            //prod.GetMyType();
            //System.Console.ReadKey();

            //Product prd = new Chemical();
            //prd.GetMyType();
            //System.Console.ReadKey();

            //Product prd1 = new Biological();
            //prd1.GetMyType();
            //System.Console.ReadKey();



            //***************Partie 6 Initialisation de données de Tests :


            /*** Donnees d'initialisation **/
            //Categories
            Category fruit = new Category() { Name = "Fruit" };
            Category Alimentaire = new Category() { Name = "Alimentaire" };

            //Products
            Product acide = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "ACIDE CITRIQUE",
                Description = "Monohydrate - E330 - USP32",
                Category = Alimentaire,
                Price = 90,
                Quality = 30,
                //City = "Sousse"
            };
            Product cacao = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "POUDRE DE CACAO NATURELLE",
                Description = "10% -12%",
                Category = Alimentaire,
                Price = 419,
                Quality = 80,
                //City = "Sfax"
            };

            Product dioxyde = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "DIOXYDE DE TITANE",
                Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique.",
                Category = Alimentaire,
                Price = 200,
                Quality = 50,
                //City = "Tunis"
            };
            Product amidon = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "AMIDON DE MAÏS",
                Description = "Amidon de maïs natif",
                Category = Alimentaire,
                Price = 70,
                Quality = 30,
                //City = "Tunis"
            };
            Product blackberry = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Blackberry",
                Description = "",
                Category = fruit,
                Price = 60,
                ProductId = 0,
                Quality = 0

            };

            Product apple = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = "",
                Category = fruit,
                Name = "Apple",
                Price = 100.00,
                ProductId = 0,
                Quality = 100

            };

            Product avocado = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = "",
                Category = fruit,
                Name = "Avocado",
                Price = 100.00,
                ProductId = 0,
                Quality = 100

            };

            List<Product> products = new List<Product>() { acide, cacao, dioxyde, amidon, blackberry, apple, avocado };
            ManageProduct manageProduct = new ManageProduct(products);

            Provider sater = new Provider() { Id = 1, UserName = "Medical Provider" };
            Provider sudMedical = new Provider() { Id = 2, UserName = "Fruit-SA Provider" };
            Provider palliserSa = new Provider() { Id = 3, UserName = "Fruit-CP  Provider" };
            Provider prov4 = new Provider() { Id = 4, UserName = "Chemical Med-Provider" };
            Provider prov5 = new Provider() { Id = 5, UserName = "Bio Provider" };
            List<Provider> providers = new List<Provider>() { sater, sudMedical, palliserSa, prov4, prov5 };
            ManageProvider manageProvider = new ManageProvider(providers);


            //********Fcts Anonymes:


            //ManageProduct.FindProduct findProduct1 = delegate (string c)
            // {
            //     foreach (Product p in products)
            //         if (p.Name.ToUpper().StartsWith(c.ToUpper()))
            //             p.GetDetails();
            // };
            //findProduct1("a");
            ////faire une attente;
            //System.Console.ReadKey();


            //*****************************LINQ
            //manageProduct.Get5Chemical(50);
            manageProduct.GetAveragePrice();
            System.Console.ReadKey();






        }
    }
}
