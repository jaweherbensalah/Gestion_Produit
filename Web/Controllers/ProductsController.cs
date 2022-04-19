using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Data.Infrastructure;
using Service;
using System.IO;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //  private GestionProduitContext db = new GestionProduitContext();
        private ServiceProduct serviceProduct = new ServiceProduct();
        // GET: Products
        public ActionResult Index( String filter)
        {
            // var products = db.Products.Include(p => p.Category);
            // return View(unitOfWork.GetRepository<Product>().GetAll());
            var listProduct = serviceProduct.GetAll();
            if (!String.IsNullOrEmpty(filter))
            {
                listProduct = serviceProduct.GetProductByName(filter).ToList();
            }
            return View(listProduct);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = serviceProduct.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Products/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,DateProd,Description,Name,Price,Quality,ImageName,CategoryId")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    product.ImageName = file.FileName;
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }

                serviceProduct.Create(product);
                serviceProduct.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product =serviceProduct.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,DateProd,Description,Name,Price,Quality,ImageName,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                //  db.Entry(product).State = EntityState.Modified;
                serviceProduct.Update(product);
                serviceProduct.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(serviceProduct.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product =serviceProduct.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = serviceProduct.GetById(id);
         serviceProduct.Delete(product);
            serviceProduct.Commit();
            return RedirectToAction("Index");
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
       
        public ActionResult Index2()
        {
            var ListProduct = serviceProduct.GetAll().ToList();
            return View(ListProduct);
        }

        public ActionResult _Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = serviceProduct.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }


    }
}
