using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book_Store.Models;

namespace Book_Store.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        // Disable the automatic database connection
        //private Bookstore db = new Bookstore();

        private IBooksMock db;

        // Default constructor, use the real database
        public  BooksController()
        {
            this.db = new EFBooks();
        }

        // Mock constructor
        public BooksController(IBooksMock mock)
        {
            this.db = mock;
        }

        // GET: Books
        [AllowAnonymous]
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            //return View(books.ToList());
            return View("Index", books.ToList());
        }

        // GET: Books/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }

            // Old scaffold code doesn't work with our mock
            //Book book = db.Books.Find(id);

            // New code that work with both ef and mock respositories
            Book book = db.Books.SingleOrDefault(b => b.id == id);
            
            if (book == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Details", book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.author_id = new SelectList(db.Authors, "id", "name");
            ViewBag.category_id = new SelectList(db.Categories, "id", "name");
            ViewBag.publisher_id = new SelectList(db.Publishers, "id", "publish_name");
            return View("Create");
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ISBN,title,category_id,publisher_id,publish_date,author_id,prise,url")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Books.Add(book);
                //db.SaveChanges();
                db.Save(book);
                return RedirectToAction("Index");
            }

            ViewBag.author_id = new SelectList(db.Authors, "id", "name", book.author_id);
            ViewBag.category_id = new SelectList(db.Categories, "id", "name", book.category_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "id", "publish_name", book.publisher_id);
            return View("Create", book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //Book book = db.Books.Find(id);
            Book book = db.Books.SingleOrDefault(b => b.id == id);
            if (book == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            ViewBag.author_id = new SelectList(db.Authors, "id", "name", book.author_id);
            ViewBag.category_id = new SelectList(db.Categories, "id", "name", book.category_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "id", "publish_name", book.publisher_id);
            return View("Edit", book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ISBN,title,category_id,publisher_id,publish_date,author_id,prise,url")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(book).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(book);
                return RedirectToAction("Index");
            }
            ViewBag.author_id = new SelectList(db.Authors, "id", "name", book.author_id);
            ViewBag.category_id = new SelectList(db.Categories, "id", "name", book.category_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "id", "publish_name", book.publisher_id);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //Book book = db.Books.Find(id);
            Book book = db.Books.SingleOrDefault(b => b.id == id);
            if (book == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Delete", book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Book book = db.Books.Find(id);
            Book book = db.Books.SingleOrDefault(b => b.id == id);
            //db.Books.Remove(book);
            //db.SaveChanges();
            db.Delete(book);
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
