using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Business.Manager.Interface;
using Data.Repository;
using Data.Repository.Interface;
using AutoMapper;
namespace Business.Manager
{
    public class LoginManager : ILoginManager
    {
        ILoginRepository LoginRepository;
        public LoginManager(ILoginRepository login)
        {
            LoginRepository = login;
        }
        public bool Login(string Email, string Password)
        {
            bool isLogin = LoginRepository.Login(Email, Password);
            return isLogin;
        }
    }
}
