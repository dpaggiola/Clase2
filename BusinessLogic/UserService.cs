using Domain;
using IBusinessLogic;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IGuidService _guidService;

        public UserService(IUserRepository userRepository, IGuidService guidService)
        {
            _userRepository = userRepository;
            _guidService = guidService;
        }

        public User AddUser(User user)
        {
            _userRepository.Add(user);
            return user;
        }

        public User GetUserById(int userId)
        {
            try
            {
                return _userRepository.Find(x => x.Id == userId);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException();
            }
        }

        public User GetUserByToken(string token)
        {
            try
            {
                return _userRepository.Find(x => x.Token == token);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException();
            }
        }

        public string Login(string email, string password)
        {
            try
            {
                User user = _userRepository.Find(x => x.Email == email && x.Password == password);

                user.Token = _guidService.NewGuid().ToString();
                UpdateUser(user, user.Id);
                return user.Token;
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException();
            }
        }

        public User UpdateUser(User newUser, int id)
        {
            User oldUser = GetUserById(id);
            return _userRepository.Update(oldUser, newUser);
        }
    }
}
