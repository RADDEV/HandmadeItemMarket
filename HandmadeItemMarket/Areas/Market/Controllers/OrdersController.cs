using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using HandmadeItemMarket.Attributes;
using HandmadeItemMarket.Data;
using HandmadeItemMarket.Models.EntityModels;
using HandmadeItemMarket.Models.ViewModels;
using HandmadeItemMarket.Services;
using Microsoft.AspNet.Identity;

namespace HandmadeItemMarket.Areas.Market.Controllers
{
    [RouteArea("Market", AreaPrefix = "")]
    [RoutePrefix("Orders")]
    [CustomAuthorize(Roles = "RegisteredUser, Admin")]
    public class OrdersController : Controller
    {
        private HandmadeItemMarketContext db = new HandmadeItemMarketContext();
        private OrderService service;

        public OrdersController()
        {
            this.service=new OrderService();
        }
        [Route("Index")]
        // GET: Orders
        public ActionResult Index()
        {
            var currentUserId = HttpContext.User.Identity.GetUserId();
            IEnumerable<OrderVM> vms = this.service.RetrieveRecievedOrders(currentUserId);
            return View(vms);

            
            //var orders = db.Orders.Where(a => a.Seller.Id == currentUserId).ToList();
            //return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        [Route("Create/{id}")]
        // GET: Orders/Create
        public ActionResult Create(int id)
        {
            var currentUserId = HttpContext.User.Identity.GetUserId();
            Order order = new Order()
            {
                Product = db.Products.FirstOrDefault(p => p.Id == id),
                OrderedOn = DateTime.Now,
                Buyer = db.Users.FirstOrDefault(u => u.Id == currentUserId)
            };
            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderedOn,FullAddress,AditionalInfo")] Order order,int id)
        {
            order.Product = db.Products.FirstOrDefault(p => p.Id == id);
            order.OrderedOn = DateTime.Now;
            var currentUserId = HttpContext.User.Identity.GetUserId();
            order.Buyer = db.Users.FirstOrDefault(u => u.Id == currentUserId);
            order.Seller = db.Products.FirstOrDefault(p => p.Id == id).Seller;
            this.service.SendMail(order.Seller.Id);
            
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.Users.FirstOrDefault(u => u.Id == order.Seller.Id).OrdersReceived.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index","Products");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderedOn,FullAddress,AditionalInfo")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
