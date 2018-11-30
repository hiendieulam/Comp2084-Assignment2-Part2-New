using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Book_Store.Controllers;
using Book_Store.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Book_Store.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        // Global variables needed for multiple test in this class
        BooksController controller;
        Mock<IBooksMock> mock;
        List<Book> books;

        [TestInitialize]
        public void TestInitalize()
        {
            // This method runs automatically before each individual test


            // Create a new mock data object to hold a fake list of books
            mock = new Mock<IBooksMock>();

            // Populate mock list 
            books = new List<Book>
            {
                new Book { id = 1, ISBN = "0321683684", title = "The Elements", Author = new Author{ id=1, name="Jesse James Garrett" }, author_id = 1, Category = new Category { id=1, name = "Science"}, category_id = 1, Publisher = new Publisher{id = 1, publish_name = "New Riders" }, publisher_id = 1, prise = new Decimal(25.99), publish_date = new DateTime(2017, 11, 15), url = "https://www.amazon.ca/gp/product/0321683684" } ,
                new Book { id = 2, ISBN = "0321683690", title = "The Times", Author = new Author{ id=1, name="Jesse James Garrett" }, author_id = 1, Category = new Category { id=1, name = "Science"}, category_id = 1, Publisher = new Publisher{id = 1, publish_name = "New Riders" }, publisher_id = 1, prise = new Decimal(20.99), publish_date = new DateTime(2017, 11, 10), url = "https://www.amazon.ca/gp/product/0321683690" } ,
                new Book { id = 3, ISBN = "0321683680", title = "The Gold", Author = new Author{ id=2, name="Stephen King" }, author_id = 2, Category = new Category { id=2, name = "Art"}, category_id = 1, Publisher = new Publisher{id = 2, publish_name = "Pearson" }, publisher_id = 2, prise = new Decimal(30.99), publish_date = new DateTime(2015, 10, 10), url = "https://www.amazon.ca/gp/product/0321683680" }
            };

            // Put list into mock object and pass it to the Books controller
            mock.Setup(m => m.Books).Returns(books.AsQueryable());
            controller = new BooksController(mock.Object);
        }
        // GET : Books/Index
        #region
        [TestMethod]
        public void Index()
        {
            // Arrange
            //BooksController controller = new BooksController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexLoadsView()
        {
            // Arrange
            //BooksController controller = new BooksController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexReturnsBooks()
        {
            // Act
            var result = (List<Book>)((ViewResult)controller.Index()).Model;

            // Assert
            CollectionAssert.AreEqual(books, result);
        }
        #endregion

        // GET : Books/Details/5
        #region
        // id is null
        [TestMethod]
        public void DetailsIdNull()
        {
            // Act
            ViewResult result = (ViewResult)controller.Details(null);

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // book is null
        [TestMethod]
        public void DetailsResultNull()
        {
            // Act
            ViewResult result = (ViewResult)controller.Details(100);

            // Assert
            Assert.AreEqual("Error", result.ViewName);                
        }

        // Valid Id Loads View
        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // Act
            ViewResult result = (ViewResult)controller.Details(1);

            // Assert
            Assert.AreEqual("Details", result.ViewName);
        }

        // Valid Id Loads Book
        [TestMethod]
        public void DetailsValidIdLoadsBook()
        {
            // Act
            var result = (Book)((ViewResult)controller.Details(1)).Model;

            // Assert
            Assert.AreEqual(books[0], result);
        }

        #endregion

        // GET : Books/Edit/5
        #region
        // id is null
        [TestMethod]
        public void EditIdNull()
        {
            // Arrange
            int? id = null;

            // Act
            ViewResult result = (ViewResult)controller.Edit(id);

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // book is null
        [TestMethod]
        public void EditResultNull()
        {
            // Act
            ViewResult result = (ViewResult)controller.Edit(100);

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // Valid Id Loads View
        [TestMethod]
        public void EditValidIdLoadsView()
        {
            // Act
            ViewResult result = (ViewResult)controller.Edit(1);

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        // Valid Id Loads Book
        [TestMethod]
        public void EditValidIdLoadsBook()
        {
            // Act
            var result = (Book)((ViewResult)controller.Edit(1)).Model;

            // Assert
            Assert.AreEqual(books[0], result);
        }

        // ViewBag Artist
        [TestMethod]
        public void EditViewBagArtist()
        {
            // Act
            var result = (ViewResult)controller.Edit(1);

            // Assert
            Assert.IsNotNull(result.ViewBag.author_id);
        }

        // ViewBag Category
        [TestMethod]
        public void EditViewBagCategory()
        {
            // Act
            var result = (ViewResult)controller.Edit(1);

            // Assert
            Assert.IsNotNull(result.ViewBag.category_id);
        }

        // ViewBag Publisher
        [TestMethod]
        public void EditViewBagPublisher()
        {
            // Act
            var result = (ViewResult)controller.Edit(1);

            // Assert
            Assert.IsNotNull(result.ViewBag.publisher_id);
        }

        // Redirect
        [TestMethod]
        public void EditRedirectView()
        {
            // Arrange
            Book book = null;

            // Act
            var result = controller.Edit(book);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        #endregion

        // GET : Books/Create
        #region
        // Loads View
        [TestMethod]
        public void CreateLoadsView()
        {
            // Act
            ViewResult result = (ViewResult)controller.Create();

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        // ViewBag Artist
        [TestMethod]
        public void CreateViewBagArtist()
        {
            // Act
            var result = (ViewResult)controller.Create();

            // Assert
            Assert.IsNotNull(result.ViewBag.author_id);
        }

        // ViewBag Category
        [TestMethod]
        public void CreateViewBagCategory()
        {
            // Act
            var result = (ViewResult)controller.Create();

            // Assert
            Assert.IsNotNull(result.ViewBag.category_id);
        }

        // ViewBag Publisher
        [TestMethod]
        public void CreateViewBagPublisher()
        {
            // Act
            var result = (ViewResult)controller.Create();

            // Assert
            Assert.IsNotNull(result.ViewBag.publisher_id);
        }

        // Loads Redirect View when book is null
        [TestMethod]
        public void CreateLoadsRedirectView()
        {
            // Act
            var result = controller.Create(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        // Loads Redirect View when book is not null
        Book book = new Book { id = 4, ISBN = "0321683100", title = "The New York", Author = new Author { id = 2, name = "Stephen King" }, author_id = 2, Category = new Category { id = 2, name = "Art" }, category_id = 1, Publisher = new Publisher { id = 2, publish_name = "Pearson" }, publisher_id = 2, prise = new Decimal(40.99), publish_date = new DateTime(2019, 10, 10), url = "https://www.amazon.ca/gp/product/0321683100" };
        [TestMethod]
        public void CreateLoadsRedirectViewValidBook()
        {
            // Act
            var result = controller.Create(book);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            Assert.IsNotNull(result);
            //Assert.AreEqual(result.id, book.id);
        }
        

        #endregion

        // GET : Books/Delete/5
        #region
        // id is null
        [TestMethod]
        public void DeleteIdNull()
        {
            // Arrange
            int? id = null;

            // Act
            ViewResult result = (ViewResult)controller.Delete(id);

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // book is null
        [TestMethod]
        public void DeleteResultNull()
        {
            // Act
            ViewResult result = (ViewResult)controller.Delete(100);

            // Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        // Valid Id Loads View
        [TestMethod]
        public void DeleteValidIdLoadsView()
        {
            // Arrange
            int id = 1;

            // Act
            ViewResult result = (ViewResult)controller.Delete(id);

            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        // Valid Id Delete
        [TestMethod]
        public void DeleteValidId()
        {
            // Act
            var result = (Book)((ViewResult)controller.Delete(1)).Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(books[0].id, result.id);
        }

        // Redirect Valid Id DeleteConfirmed
        [TestMethod]
        public void DeleteConfirmedValidIdRedirect()
        {
            // Act
            var result = controller.DeleteConfirmed(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
        #endregion
    }
}
