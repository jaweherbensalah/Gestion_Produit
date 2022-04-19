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
using Service;

namespace Web.Controllers
{
    public class FacturesController : Controller
    {
        private GestionProduitContext db = new GestionProduitContext();
        private FactureService factureService = new FactureService();

        // GET: Factures
        public ActionResult Index(String prix,String name)
        {
            //var factures = db.Factures.Include(f => f.Client).Include(f => f.Product);
            var listFactures = factureService.GetAll();
            if (!String.IsNullOrEmpty(prix) || !String.IsNullOrEmpty(name)) 
            {
                listFactures = factureService.GetFactureByPriceAndName(prix, name);
            }


            return View(listFactures);
        }

        // GET: Factures/Details/5
        public ActionResult Details( int ProductId,int ClientId, DateTime DateDachat)
        {   
            if ((ProductId == 0 ) || (ClientId ==0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = factureService.GetFactureById(ProductId, ClientId, DateDachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(factureService.unitofwork.DataContext.Clients, "CIN", "Mail");
            ViewBag.ProductId = new SelectList(factureService.unitofwork.DataContext.Products, "ProductId", "Description");
            return View();
        }

        // POST: Factures/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateAchat,ClientId,ProductId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                factureService.Create(facture);
                factureService.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(factureService.unitofwork.DataContext.Clients, "CIN", "Mail", facture.ClientId);
            ViewBag.ProductId = new SelectList(factureService.unitofwork.DataContext.Products, "ProductId", "Description", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public ActionResult Edit(int ProductId, int ClientId, DateTime DateDachat)
        {
            if ((ProductId == 0) || (ClientId == 0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = factureService.GetFactureById(ProductId, ClientId, DateDachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = factureService.unitofwork.DataContext.Clients.Where(c => c.CIN == ClientId).FirstOrDefault().Prenom;
            ViewBag.ProductId = factureService.unitofwork.DataContext.Products.Where(c => c.ProductId == ProductId).FirstOrDefault().Name;
            return View(facture);
        }

        // POST: Factures/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateAchat,ClientId,ProductId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(facture).State = EntityState.Modified;
                // db.SaveChanges();
                factureService.Update(facture);
                factureService.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(factureService.unitofwork.DataContext.Clients, "CIN", "Mail", facture.ClientId);
            ViewBag.ProductId = new SelectList(factureService.unitofwork.DataContext.Products, "ProductId", "Description", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(int ProductId, int ClientId, DateTime DateDachat)
        {
            if ((ProductId == 0) || (ClientId == 0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = factureService.GetFactureById(ProductId, ClientId, DateDachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ProductId, int ClientId, DateTime DateDachat)
        {
            Facture facture = factureService.GetFactureById(ProductId,ClientId,DateDachat);
            //db.Factures.Remove(facture);
            //db.SaveChanges();
            factureService.Delete(facture);
            factureService.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
