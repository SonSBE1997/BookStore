using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PublisherDAO
    {

        BookStoreDbContext db;

        public PublisherDAO()
        {
            db = new BookStoreDbContext();
        }

        public BookPublisher getPublisherByID(long id)
        {
            return db.BookPublishers.Find(id);
        }

        public List<BookPublisher> getListAll()
        {
            return db.BookPublishers.ToList();
        }

        public IEnumerable<BookPublisher> GetListPublisherPaging(string searchString, int page, int pageSize)
        {
            IQueryable<BookPublisher> model = db.BookPublishers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(_ => _.Name.Contains(searchString));
            }

            return model.OrderBy(_ => _.ID).ToPagedList(page, pageSize);
        }

        public bool Insert(BookPublisher publisher)
        {
            try
            {
                db.BookPublishers.Add(publisher);
                db.SaveChanges();
                return db.BookPublishers.Count(_ => _.Name == publisher.Name) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BookPublisher publisher)
        {
            try
            {
                BookPublisher pu = db.BookPublishers.Find(publisher.ID);
                pu.Name = publisher.Name;
                pu.Address = publisher.Address;
                pu.PhoneNumber = publisher.PhoneNumber;
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
                BookPublisher publisher = db.BookPublishers.Find(id);
                if (publisher == null) return false;
                db.BookPublishers.Remove(publisher);
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
