using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application1.DTOs;

namespace Application1.Abstract
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minutes, Guid userId, string user_name, string fullname, bool? admin);  //Token = Access Token = JWT , aynı şeylerdir
    }
}
