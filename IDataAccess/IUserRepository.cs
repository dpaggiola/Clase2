using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDataAccess
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> GetAll();
        User Find(Predicate<User> condition);
        User Update(User oldUser, User newUser);
    }
}
