using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Abstract
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
