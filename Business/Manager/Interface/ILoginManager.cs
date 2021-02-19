using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Manager.Interface
{
    public interface ILoginManager
    {
        bool Login(string Email, string Password);
    }
}
