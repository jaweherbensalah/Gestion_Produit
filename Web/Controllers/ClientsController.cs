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
using System.IO;
using Data.Infrastructure;
using Data.Repository;

namespace Web.Controllers
{
    public class ClientsController : Controller
    {
        private GestionProduitContext db = new GestionProduitContext();
        private ClientService clientService = new ClientService();


        // GET: Clients
        public ActionResult Index()
        {
            return View(clientService.GetAll());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = clientService.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CIN,DateNaissance,Mail,Nom,Prenom")] Client client)
        {
            if (ModelState.IsValid)
            {
                //db.Clients.Add(client);
                //db.SaveChanges();
                clientService.Create(client);
                clientService.Commit();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = clientService.GetById(id);


            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CIN,DateNaissance,Mail,Nom,Prenom")] Client client)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(client).State = EntityState.Modified;
                clientService.Update(client);
                clientService.Commit();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = clientService.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = clientService.GetById(id);
            clientService.Delete(client);
            clientService.Commit();

           // db.Clients.Remove(client);
           // db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*
                protected override void Dispose(bool disposing)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    base.Dispose(disposing);
                }*/

        public ActionResult InfoClient(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = clientService.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return PartialView(client);
        }
    }
}
