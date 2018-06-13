using Models.Common;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDAO
    {
        BookStoreDbContext db;

        public UserDAO()
        {
            db = new BookStoreDbContext();
        }

        public User GetUserByUsername(String username)
        {
            return db.Users.SingleOrDefault(_ => _.Username == username);
        }

        public User GetUserByID(long id)
        {
            return db.Users.Find(id);
        }

        public int CheckLogin(String username, String password)
        {
            var result = db.Users.SingleOrDefault(_ => _.Username == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == Encryptor.Encrypt(password))
                    {
                        if (result.Role == "Admin")
                        {
                            return 1;
                        }
                        return -3;
                    }
                    else
                        return -2;
                }
            }
        }

        public int CheckLoginClient(String username, String password)
        {
            var result = db.Users.SingleOrDefault(_ => _.Username == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == Encryptor.Encrypt(password))
                    {
                        if (result.Role != "Admin")
                        {
                            return 1;
                        }
                        return -3;
                    }
                    else
                        return -2;
                }
            }
        }

        public bool Insert(User user)
        {
            try
            {
                if (db.Users.SingleOrDefault(_ => _.Username == user.Username) != null)
                    return false;
                if (String.IsNullOrEmpty(user.Password)) return false;
                user.Password = Encryptor.Encrypt(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
                return db.Users.Count(_ => _.Username == user.Username) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(User user)
        {
            try
            {
                User userr = db.Users.Find(user.ID);
                userr.Name = user.Name;
                if (!string.IsNullOrEmpty(user.Password))
                {
                    userr.Password = Encryptor.Encrypt(user.Password);
                }
                userr.Address = user.Address;
                userr.Email = user.Email;
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
                User user = db.Users.Find(id);
                db.Users.Remove(user);
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
            User user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public String ChangeRole(long id)
        {
            User user = db.Users.Find(id);
            if (user.Role == "Admin") user.Role = "Người dùng";
            else user.Role = "Admin";
            db.SaveChanges();
            return user.Role;
        }

        public IEnumerable<User> GetListUserPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(_ => _.Username.Contains(searchString) || _.Name.Contains(searchString));
            }

            return model.OrderBy(_ => _.ID).ToPagedList(page, pageSize);
        }

        public bool Register(User user)
        {
            try
            {
                if (db.Users.SingleOrDefault(_ => _.Username == user.Username) != null)
                    return false;
                if (String.IsNullOrEmpty(user.Password)) return false;
                if (!user.Status) return false;
                user.Password = Encryptor.Encrypt(user.Password);
                user.Role = "Người dùng";
                db.Users.Add(user);
                db.SaveChanges();
                return db.Users.Count(_ => _.Username == user.Username) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
