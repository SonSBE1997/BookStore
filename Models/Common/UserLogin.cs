using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public String UserName { set; get; }
        public String Name { get; set; }
    }
}
