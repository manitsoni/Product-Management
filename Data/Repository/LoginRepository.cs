using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repository.Interface;
using Data.Model;
namespace Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        ProductManagementEntities db = new ProductManagementEntities();   
        public bool Login(string Email, string password)
        {
            var user = db.tblUsers.ToList();
            bool isLogin = false;
            foreach (var item in user)
            {
                if (item.EmailId == Email && item.Password == password)
                {
                    isLogin = true;
                    break;
                }
            }
            return isLogin;
        }
    }
}
