using Application1.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concrete
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
