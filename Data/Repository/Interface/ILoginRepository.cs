using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
namespace Data.Repository.Interface
{
   public interface ILoginRepository
    {
        bool Login(string Email, string password);
    }
}
