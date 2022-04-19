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
using Data.Repository;
using Service;
namespace Web.Controllers
    
   
{
    public class CategoriesController : Controller
    {
        private ServiceCategory serviceCategory = new ServiceCategory();
       // private UnitOfWork unitOfWork = new UnitOfWork();
        //private CategoryRepository CatRepo = new CategoryRepository(new DatabaseFactory());
       // private GestionProduitContext db = new GestionProduitContext();

        // GET: Categories
        public ActionResult Index()
        {
            // return View(db.Categories.ToList());
            //return View(unitOfWork.GetRepository<Category>().GetAll());
            return View(serviceCategory.GetAll());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Category category = db.Categories.Find(id);
            //  Category category = unitOfWork.GetRepository<Category>().GetById(id);
            Category category = serviceCategory.GetById(id);


            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                // db.Categories.Add(category);
                //db.SaveChanges();
                // unitOfWork.GetRepository<Category>().Add(category);
                // unitOfWork.Commit();
                serviceCategory.Create(category);
                serviceCategory.Commit();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  Category category = db.Categories.Find(id);
            Category category = serviceCategory.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(category).State = EntityState.Modified;
                // db.SaveChanges();
                serviceCategory.Update(category);
                serviceCategory.Commit();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  Category category = db.Categories.Find(id);

            Category category = serviceCategory.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Category category = db.Categories.Find(id);
            //  db.Categories.Remove(category);
            // db.SaveChanges();
            Category category = serviceCategory.GetById(id);
            serviceCategory.Delete(category);
            serviceCategory.Commit();
            return RedirectToAction("Index");
        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
