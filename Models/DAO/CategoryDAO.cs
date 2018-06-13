using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDAO
    {

        BookStoreDbContext db;

        public CategoryDAO()
        {
            db = new BookStoreDbContext();
        }

        public String getNameCategoryByID(long id)
        {
            return db.BookCategories.Find(id).Name;
        }

        public BookCategory getBookCategoryByID(long id)
        {
            return db.BookCategories.Find(id);
        }

        public List<BookCategory> getListAll()
        {
            return db.BookCategories.ToList();
        }

        public IEnumerable<BookCategory> GetListCategoryPaging(string searchString, int page, int pageSize)
        {
            IQueryable<BookCategory> model = db.BookCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(_ => _.Name.Contains(searchString));
            }

            return model.OrderBy(_ => _.DisplayOrder).ToPagedList(page, pageSize);
        }

        public bool Insert(BookCategory category)
        {
            try
            {
                if (category.ParentID == -100) category.ParentID = null;
                db.BookCategories.Add(category);
                db.SaveChanges();
                return db.BookCategories.Count(_ => _.Name == category.Name) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BookCategory category)
        {
            try
            {
                BookCategory categoryy = db.BookCategories.Find(category.ID);
                categoryy.Name = category.Name;
                if (category.ParentID != -100)
                {
                    categoryy.ParentID = category.ParentID;
                    BookCategory child = getBookCategoryByID((long)category.ParentID);
                    if (child.ParentID == category.ID) child.ParentID = null;
                }
                else
                {
                    categoryy.ParentID = null;
                }
                categoryy.DisplayOrder = category.DisplayOrder;
                categoryy.Status = category.Status;
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
                BookCategory category = db.BookCategories.Find(id);

                if (category == null) return false;
                foreach (BookCategory item in db.BookCategories)
                {
                    if (item.ParentID == category.ID) item.ParentID = null;
                }

                db.BookCategories.Remove(category);
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
            BookCategory category = db.BookCategories.Find(id);
            category.Status = !category.Status;
            db.SaveChanges();
            return category.Status;
        }
    }
}
