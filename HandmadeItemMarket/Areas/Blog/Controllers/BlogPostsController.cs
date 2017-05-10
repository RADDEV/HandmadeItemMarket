using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HandmadeItemMarket.Attributes;
using HandmadeItemMarket.Data;
using HandmadeItemMarket.Models;
using HandmadeItemMarket.Models.EntityModels;
using Microsoft.AspNet.Identity;

namespace HandmadeItemMarket.Areas.Blog.Controllers
{
    using Services;

    [RouteArea("Blog",AreaPrefix = "")]
    [RoutePrefix("blog")]
    public class BlogPostsController : Controller
    {
        private HandmadeItemMarketContext db = new HandmadeItemMarketContext();
        private BlogPostService service;

        public BlogPostsController()
        {
            this.service = new BlogPostService();
        }
        // GET: BlogPosts
        [AllowAnonymous]
        [Route("index")]
        public ActionResult Index()
        {
            return View(db.BlogPosts.ToList());
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
                var blogPost = db.BlogPosts.FirstOrDefault(p => p.Id == id);
                blogPost.Comments.Add(comment);
                db.BlogPosts.AddOrUpdate(blogPost);
                db.SaveChanges();
                return RedirectToAction("Details", "BlogPosts", id);
            }
            return View();
        }
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        [Route("UploadImage/{id}")]
        public ActionResult UploadImage(int id)
        {
            var lastPost = this.service.GetLastPost(id);
            return View(lastPost);
        }
        [Route("UploadImage/{id}")]
        [HttpPost]
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        public ActionResult UploadImage(HttpPostedFileBase file,int id)
        {
            if (file != null)
            {
                string pic = id.ToString()+".jpg";//System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/blogpost"), pic);
                var post = db.BlogPosts.FirstOrDefault(b=>b.Id==id);
                post.Image = "/images/blogpost/"+ pic;
                db.BlogPosts.AddOrUpdate(post);
                db.SaveChanges();
                // file is uploaded
                file.SaveAs(path);
            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "BlogPosts");
        }

        // GET: BlogPosts/Details/5
        [AllowAnonymous]
        [Route("details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Create
        [Route("create")]
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("create")]
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,ImageUrl")] BlogPost blogPost)
        {
            var userId = HttpContext.User.Identity.GetUserId();
            blogPost.DatePosted=DateTime.Now;
            blogPost.Poster = db.Users.FirstOrDefault(a => a.Id == userId);//HttpContext.User.Identity.Name;
            
            if (ModelState.IsValid)
            {
                db.BlogPosts.Add(blogPost);
                db.SaveChanges();
                var lastPost = db.BlogPosts.OrderByDescending(a=>a.Id).FirstOrDefault();
                return RedirectToAction("UploadImage",lastPost);
            }
            return RedirectToAction("Index");
            //return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        [Route("edit/{id}")]
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        public ActionResult Edit([Bind(Include = "Id,DatePosted,Title,Content,Rating")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Route("delete/{id}")]
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin,BlogAuthor")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogPost);
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
