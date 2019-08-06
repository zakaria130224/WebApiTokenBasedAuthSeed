using BookHome.Core.Entity;
using BookHome.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookHome.Infrastracture.Services
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User Insert(User user);
        User Update(User user);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public List<User> GetAllUser()
        {
            return userRepository.GetAll().ToList();
        }

        public User Insert(User user)
        {
            return userRepository.Insert(user);
        }
        public User Update(User user)
        {
            return userRepository.Update(user);
        }
    }
}
