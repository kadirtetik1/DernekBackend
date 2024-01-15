using Application1.Repository.IAddressRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dernek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        readonly private IAddressReadRepository _addressReadRepository;
        readonly private IAddressWriteRepository _addressWriteRepository;

        public AddressesController(IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;

        }

        [HttpGet]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _addressReadRepository.GetByIdAsync(id, false));
        }
    }
}
