using Application1.Repository.IAddressRepository;
using Application1.ViewModels.Address;
using Application1.ViewModels.User;
using Domain;
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
        public async Task<IActionResult> Get()
        {
            return Ok(_addressReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _addressReadRepository.GetByIdAsync(id, false));
        }

        //[HttpGet("getByTeacherId")]
        //public async Task<IActionResult> GetTeacher(string TeacherId)
        //{

        //    return Ok(await _addressReadRepository.GetByIdAsyncTeacher(TeacherId, false));

        //}

        //[HttpGet("GetWithTeacherInfo")]
        //public async Task<IActionResult> GetWithTeacherInfo()
        //{
        //    return Ok(await _courseReadRepository.GetWithTeacherInfo(false));
        //}

        [HttpPost]
        public async Task<IActionResult> Post(Vm_Address_Create model)
        {
            Address address = new()
            {
                Name = model.Name,
                Lastname = model.Lastname,
                FatherName = model.FatherName,
                address = model.address,
                Phone = model.Phone,
                WorkInfo = model.WorkInfo,
                Unvan = model.Unvan,
                UserID= model.UserID,
                Family= model.Family,


            };
            await _addressWriteRepository.AddAsync(address);

            await _addressWriteRepository.SaveAsync();

            return Ok(address);

        }


        [HttpPut]
        public async Task<IActionResult> Put(Vm_Address_Update model)
        {
            string success = "Güncellendi";
            Address address = await _addressReadRepository.GetByIdAsync(model.Id);

            address.Name = model.Name;
            address.Lastname = model.Lastname;
            address.FatherName = model.FatherName;
            address.address = model.address;
            address.Phone = model.Phone;
            address.WorkInfo = model.WorkInfo;
            address.Unvan = model.Unvan;
            address.UserID = model.UserID;
            address.Family = model.Family;
           

            await _addressWriteRepository.SaveAsync();

            return Ok(success);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _addressWriteRepository.RemoveAsync(id);
            await _addressWriteRepository.SaveAsync();
            return Ok();
        }





    }
}
