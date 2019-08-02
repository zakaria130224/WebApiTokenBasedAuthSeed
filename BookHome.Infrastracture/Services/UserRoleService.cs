using BookHome.Core.Entity;
using BookHome.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHome.Infrastracture.Services
{
   
        public interface IUserRoleService
        {
            List<UserRole> GetAllUserRole();
        }
    public class UserRoleService : IUserRoleService
    {
        private readonly IRepository<UserRole> UserRoleRepository;

        public UserRoleService(IRepository<UserRole> UserRoleRepository)
        {
            this.UserRoleRepository = UserRoleRepository;

        }
        public List<UserRole> GetAllUserRole()
        {
            return UserRoleRepository.GetAll().ToList();
        }
    }
}
