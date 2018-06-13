using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class BookDAO
    {

        BookStoreDbContext db;

        public BookDAO()
        {
            db = new BookStoreDbContext();
        }
        /////////////////// FOE SINGLE Book
        public Book getBookByID(long id)
        {
            return db.Books.Find(id);
        }

        public List<Book> getListSimilarProduct(long categoryID, int top)
        {
            return db.Books.Where(_ => _.BookCategory == categoryID).Take(top).ToList();
        }

        public List<Book> getListSameAuthor(long authorID, int top)
        {
            return db.Books.Where(_ => _.BookAuthor == authorID).Take(top).ToList();
        }

        //////////////////////////////// HOME Client
        public List<Book> getListBookNormal()
        {
            return db.Books.Where(_ => _.Status && !_.TopHot && !_.New).ToList();
        }

        public List<Book> getListHotBook()
        {
            return db.Books.Where(_ => _.Status && _.TopHot).ToList();
        }

        public List<Book> getListNewBook()
        {
            return db.Books.Where(_ => _.Status && _.New).ToList();
        }



        ////////////////////////////List Product
        public List<Book> getListAll()
        {
            return db.Books.Where(_ => _.Status).ToList();
        }


        public List<Book> getListBookByCategoryID(long categoryID, ref int totalBook, int page, int pageSize)
        {
            List<Book> ls = new List<Book>();
            var temp = db.BookCategories.Where(_ => _.ID == categoryID || _.ParentID == categoryID);
            foreach (var item in temp)
            {
                ls.AddRange(db.Books.Where(_ => _.BookCategory == item.ID).ToList());
            }

            totalBook = ls.Count();
            return ls.OrderBy(_ => _.Price).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }


        public List<Book> GetListBookNewPagingSortByPrice(ref int totalBook, int page, int pageSize)
        {
            IQueryable<Book> model = db.Books;
            totalBook = model.Where(_ => _.New).Count();
            return model.Where(_ => _.New).OrderBy(_ => _.Price).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Book> GetListBookHotPagingSortByPrice(ref int totalBook, int page, int pageSize)
        {
            IQueryable<Book> model = db.Books;
            totalBook = model.Where(_ => _.TopHot).Count();
            return model.Where(_ => _.TopHot).OrderBy(_ => _.Price).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Book> GetListBookPagingSortByPrice(String searchString, ref int totalBook, int page, int pageSize)
        {
            searchString = searchString.ToLower();
            IQueryable<Book> model = db.Books;
            if (!String.IsNullOrEmpty(searchString))
            {
                model = from t1 in model
                        join t2 in db.BookAuthors on t1.BookAuthor equals t2.ID
                        join t3 in db.BookCategories on t1.BookCategory equals t3.ID
                        join t4 in db.BookPublishers on t1.BookPublisher equals t4.ID
                        where t1.Name.ToLower().Contains(searchString) || t2.Name.ToLower().Contains(searchString) || t3.Name.ToLower().Contains(searchString) || t4.Name.ToLower().Contains(searchString)
                        select t1;

                //model = model.Where(_ => _.Name.ToLower().Contains(searchString));
            }


            totalBook = model.Count();
            return model.OrderBy(_ => _.Price).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }


        ///////////////////////Admin
        public IEnumerable<Book> GetListBookPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Book> model = db.Books;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(_ => _.Name.Contains(searchString));
            }

            return model.OrderBy(_ => _.ID).ToPagedList(page, pageSize);
        }

        public bool Insert(Book book)
        {
            try
            {
                db.Books.Add(book);
                db.SaveChanges();
                return db.Books.Count(_ => _.Name == book.Name) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Book book)
        {
            try
            {
                Book newBook = db.Books.Find(book.ID);
                newBook.Name = book.Name;
                newBook.Code = book.Code;
                newBook.Description = book.Description;
                newBook.CoverPhoto = book.CoverPhoto;
                newBook.Price = book.Price;
                newBook.Quantity = book.Quantity;
                newBook.Detail = book.Detail;
                newBook.BookAuthor = book.BookAuthor;
                newBook.BookCategory = book.BookCategory;
                newBook.BookPublisher = book.BookPublisher;
                newBook.TopHot = book.TopHot;
                newBook.New = book.New;
                newBook.Status = book.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long? id)
        {
            try
            {
                Book book = db.Books.Find(id);
                if (book == null) return false;
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            Book book = db.Books.Find(id);
            book.Status = !book.Status;
            db.SaveChanges();
            return book.Status;
        }

        public bool ChangeNewProduct(long id)
        {
            Book book = db.Books.Find(id);
            book.New = !book.New;
            db.SaveChanges();
            return (bool)book.New;
        }

        public bool ChangeHotProduct(long id)
        {
            Book book = db.Books.Find(id);
            book.TopHot = !book.TopHot;
            db.SaveChanges();
            return (bool)book.TopHot;
        }

        public List<BookCategory> getTreeCategoryByIDChild(long categoryChildID)
        {
            List<BookCategory> ls = new List<BookCategory>();
            CategoryDAO dao = new CategoryDAO();
            BookCategory child = dao.getBookCategoryByID(categoryChildID);
            while (child.ParentID != null)
            {
                child = dao.getBookCategoryByID((long)child.ParentID);
                ls.Add(child);
            }

            return ls;
        }

        public bool SaleBook(long bookID, int quantity)
        {
            try
            {
                Book book = db.Books.Find(bookID);
                book.Quantity -= quantity;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
