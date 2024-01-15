using Application1.DTOs;
using Application1.Repository.IUserRepository;
using Application1.ViewModels.User;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Dernek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;
        
        public UsersController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_userReadRepository.GetAll(false)); 

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _userReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vm_User_Create model)
        {
            string same_username = "Bu kullanıcı adı daha önceden alınmış. Başka bir kullanıcı adı seçiniz.";
            string same_mail = "Bu mail adresiyle kayıtlı bir üyelik bulunmakta. Şifrenizi mi unuttunuz ?";
            string success = "Kayıt Başarılı! Giriş yapabilirsiniz.";


            User checkUser = await _userReadRepository.GetWhere(student => student.Username.Equals(model.Username)).FirstOrDefaultAsync();

            User checkMail = await _userReadRepository.GetWhere(student => student.Email.Equals(model.Email)).FirstOrDefaultAsync();

            if (checkUser?.Username == model.Username)
            {
                return Ok(same_username);
            }

            else if (checkMail?.Email == model.Email)
            {
                return Ok(same_mail);
            }

            else   //Başarılı
            {
                await _userWriteRepository.AddAsync(new()
                {
                    Name = model.Name,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    Admin = model.Admin,

                });

                await _userWriteRepository.SaveAsync();

                return Ok(success);

            }


        }

        [HttpPost("userControl")]
        public async Task<ActionResult<string>> userControl(Vm_User_Control model)
        {

            string success = "true";
            string error = "Kullanıcı adı veya şifre hatalı!";

            Response.Headers.Add("Custom-Header", "Custom-Value");


            User user2 = await _userReadRepository.GetWhere(user => user.Username.Equals(model.Username)).FirstOrDefaultAsync(); //username'i eşit olan varsa getir
            if (user2 == null || user2.Password != model.Password)
            {

                return Ok(error);
            }

            else  //Başarılı
            {
                string fullname = user2.Name + " " + user2.Lastname;

                //string department2 = "";

                //if (!string.IsNullOrEmpty(user2.department))
                //{
                //    department2 = user2.department;

                //}

                //else
                //{
                //    department2 = "empty";
                //}


                //Token token = _tokenHandler.CreateAccessToken(30, student2.Id, student2.user_name, fullname, "student", department2);

                // return Ok(token);  //success dönüyordu!
                return Ok(success);  //success dönüyordu!
            }


        }

        [HttpPut]
        public async Task<IActionResult> Put(Vm_User_Update model)
        {
            string success = "Güncellendi";
            User user = await _userReadRepository.GetByIdAsync(model.Id);

            user.Name = model.Name;
            user.Lastname = model.Lastname;
            user.Email = model.Email;
            user.Username = model.Username;
            user.Password = model.Password;
            user.Admin = model.Admin;

            await _userWriteRepository.SaveAsync();

            return Ok(success);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userWriteRepository.RemoveAsync(id);
            await _userWriteRepository.SaveAsync();
            return Ok();
        }



    }
}
