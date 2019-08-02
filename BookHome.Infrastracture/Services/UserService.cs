using BookHome.Core.Entity;
using BookHome.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHome.Infrastracture.Services
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User Insert(User user);
    }
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public List<User> GetAllUser()
        {
            return userRepository.GetAll().ToList();
        }

        public User Insert(User user)
        {
            return userRepository.Insert(user);
        }
    }
}
