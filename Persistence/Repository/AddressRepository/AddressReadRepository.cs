using Application1.Repository.IAddressRepository;
using Application1.Repository.IUserRepository;
using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.AddressRepository
{
    public class AddressReadRepository : ReadRepository<Address>, IAddressReadRepository
    {
        public AddressReadRepository(DernekDbContext context) : base(context)
        {
        }
    }
}
