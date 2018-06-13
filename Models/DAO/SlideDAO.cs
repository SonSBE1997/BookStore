using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class SlideDAO
    {
        BookStoreDbContext db;

        public SlideDAO()
        {
            db = new BookStoreDbContext();
        }

        public Slide getSlideByID(long id)
        {
            return db.Slides.SingleOrDefault(_ => _.ID == id);
        }

        public List<Slide> getListSlide()
        {
            return db.Slides.Where(_ => _.Status).ToList();
        }

        public IEnumerable<Slide> GetListSlidePaging(string searchString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(searchString))
            {
                bool show = false;
                if (searchString == "Hiển thị") show = true;
                model = model.Where(_ => _.Status == show || _.Name.Contains(searchString));
            }

            return model.OrderBy(_ => _.ID).ToPagedList(page, pageSize);
        }

        public bool Insert(Slide slide)
        {
            try
            {
                db.Slides.Add(slide);
                db.SaveChanges();
                return db.Slides.Count(_ => _.Name == slide.Name) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Slide slide)
        {
            try
            {
                Slide sl = db.Slides.Find(slide.ID);
                sl.Name = slide.Name;
                sl.Link = slide.Link;
                sl.Status = slide.Status;
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
                Slide slide = db.Slides.Find(id);
                if (slide == null) return false;
                db.Slides.Remove(slide);
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
            Slide slide = db.Slides.Find(id);
            slide.Status = !slide.Status;
            db.SaveChanges();
            return slide.Status;
        }
    }
}
