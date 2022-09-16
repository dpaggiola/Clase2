using Domain;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        private ContextDb _contextDb;

        public UserRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public void Add(User user)
        {
            _contextDb.Users.Add(user);
            _contextDb.SaveChanges();
        }

        public User Find(Predicate<User> condition)
        {
            List<User> users = _contextDb.Users.ToList();
            foreach (User user in users)
            {
                var condResult = condition(user);
                if (condResult)
                {
                    return user;
                }
            }

            throw new KeyNotFoundException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Update(User oldUser, User newUser)
        {
            _contextDb.Users.Update(newUser);
            _contextDb.SaveChanges();
            return newUser;
        }
    }
}
