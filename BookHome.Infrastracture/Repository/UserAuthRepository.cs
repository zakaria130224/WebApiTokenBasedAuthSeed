using BookHome.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHome.Infrastracture.Repository
{
   public class UserAuthRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        DBContext context = new DBContext();

        //This method is used to check and validate the user credentials
        public User ValidateUser(string username, string password)
        {
            return context.User.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.Password == password);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
