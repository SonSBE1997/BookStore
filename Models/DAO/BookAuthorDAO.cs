using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class BookAuthorDAO
    {
        BookStoreDbContext db;

        public BookAuthorDAO()
        {
            db = new BookStoreDbContext();
        }

        public BookAuthor getAuthorByID(long id)
        {
            return db.BookAuthors.Find(id);
        }

        public List<BookAuthor> getListAll()
        {
            return db.BookAuthors.ToList();
        }

        public IEnumerable<BookAuthor> GetListAuthorPaging(string searchString, int page, int pageSize)
        {
            IQueryable<BookAuthor> model = db.BookAuthors;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(_ => _.Name.Contains(searchString));
            }

            return model.OrderBy(_ => _.ID).ToPagedList(page, pageSize);
        }

        public bool Insert(BookAuthor author)
        {
            try
            {
                db.BookAuthors.Add(author);
                db.SaveChanges();
                return db.BookAuthors.Count(_ => _.Name == author.Name) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BookAuthor author)
        {
            try
            {
                BookAuthor au = db.BookAuthors.Find(author.ID);
                au.Name = author.Name;
                au.Address = author.Address;
                au.PhoneNumber = author.PhoneNumber;
                au.PictureProfile = author.PictureProfile;
                au.Story = author.Story;
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
                BookAuthor author = db.BookAuthors.Find(id);
                if (author == null) return false;
                db.BookAuthors.Remove(author);
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
