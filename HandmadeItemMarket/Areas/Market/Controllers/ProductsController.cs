using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using HandmadeItemMarket.Attributes;
using HandmadeItemMarket.Data;
using HandmadeItemMarket.Models;
using HandmadeItemMarket.Models.EntityModels;
using HandmadeItemMarket.Models.ViewModels;
using HandmadeItemMarket.Services;
using Microsoft.AspNet.Identity;

namespace HandmadeItemMarket.Areas.Market.Controllers
{
    [RouteArea("Market", AreaPrefix = "")]
    [RoutePrefix("products")]
    public class ProductsController : Controller
    {
        private HandmadeItemMarketContext db = new HandmadeItemMarketContext();
        private ProductsService service;
            public ProductsController()
        {
            this.service=new ProductsService();
        }
        // GET: Products
        [Route("Index"), AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        [Route("Comment/{id}"), CustomAuthorize(Roles = "Admin,RegisteredUser,BlogAuthor")]
        public ActionResult Comment(int id)
        {
            return View();
        }

        [Route("Comment/{id}"), CustomAuthorize(Roles = "Admin,RegisteredUser,BlogAuthor"), HttpPost]
        public ActionResult Comment([Bind(Include = "Id,Text,Rating,DatePosted,Poster")]Comment comment, int id)
        {
            comment.Rating = 2;
            comment.DatePosted = DateTime.Now;
            var currentUserId = HttpContext.User.Identity.GetUserId();
            comment.Poster = db.Users.FirstOrDefault(u => u.Id == currentUserId);

            if (ModelState.IsValid)
            {
                var product = db.Products.FirstOrDefault(p => p.Id == id);
                product.Comments.Add(comment);
                db.Products.AddOrUpdate(product);
                db.SaveChanges();
                return RedirectToAction("Details", "Products", id);
            }
            return View();
        }

        [Route("UploadImage/{id}"),AuthorizeAdminOrOwnerOfPost]
        public ActionResult UploadImage(int id)
        {
            var lastProduct = db.Products.OrderByDescending(a => a.Id).FirstOrDefault();
            return View(lastProduct);
        }
        [Route("UploadImage/{id}"), AuthorizeAdminOrOwnerOfPost]
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file, int id)
        {
            if (file != null)
            {
                string pic = id.ToString() + ".jpg";//System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/products"), pic);
                var product = db.Products.FirstOrDefault(b => b.Id == id);
                product.Image = "/images/products/" + pic;
                db.Products.AddOrUpdate(product);
                db.SaveChanges();
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Products");
        }
        
        [Route("select/{category}"),AllowAnonymous]
        public ActionResult Select(string category)
        {
            IEnumerable<ProductVM> vms = this.service.RetrieveProductsFromCategory(category);
            return View(vms);
        }

        // GET: Products/Details/5
        [Route("details/{id}"),AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Route("create"),CustomAuthorize(Roles = "RegisteredUser")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("create"), CustomAuthorize(Roles = "RegisteredUser")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,Category")] Product product)
        {
            var userId = HttpContext.User.Identity.GetUserId();
            product.Seller= db.Users.FirstOrDefault(a => a.Id == userId);
            product.Rating = 2;
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                var lastProduct = db.Products.OrderByDescending(a => a.Id).FirstOrDefault();
                return RedirectToAction("UploadImage",lastProduct);
            }

            return View(product);
        }

        // GET: Products/Edit/5
        [Route("edit/{id}"),AuthorizeAdminOrOwnerOfPost]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("edit/{id}"), AuthorizeAdminOrOwnerOfPost]
        [HttpPost]
        [ValidateAntiForgeryToken, AuthorizeAdminOrOwnerOfPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,Rating,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Route("delete/{id}"), AuthorizeAdminOrOwnerOfPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Route("delete/{id}"), AuthorizeAdminOrOwnerOfPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
