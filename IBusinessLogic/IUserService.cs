using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessLogic
{
    public interface IUserService
    {
        User AddUser(User user);
        User GetUserById(int userId);
        User UpdateUser(User newUser, int id);
        string Login (string email, string password);
        User GetUserByToken(string token);
    }
}
