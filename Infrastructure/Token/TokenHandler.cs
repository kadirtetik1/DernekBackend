using Application1.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application1.DTOs.Token CreateAccessToken(int minute, Guid userId, string user_name, string fullname, bool? admin)  //parametre olarak userId al, controllerdan çek, tokena at(?)...
        {
            Application1.DTOs.Token token = new();

            // SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"])); // Hata veriyordu.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes("6442349872398rısduhfuıy429853y72398hrew9f8y243608795yhıufewho97236578yhwrfıu2yh43875y32rfıuh32o746y3278rhfd23477fo7892y347895ry8327yhruı792y3")); //Security key simetriğini alıyor.

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256); // Security key şifrelendi. - "HmacSha256" algoritmalar içinden seçilen bir algoritmadır. Başkası da seçilebilirdi.

            token.Expiration = DateTime.UtcNow.AddMinutes(minute);  //Token üretilme fnc. çağırılırken (Itokenhandlerdaki CreateAccessToken) içerisine dakika parametresi alacak.

            JwtSecurityToken securityToken = new(

                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: token.Expiration,
                claims: new List<Claim> { new Claim("id", userId.ToString()), new Claim("username", user_name), new Claim("fullname", fullname), new Claim("admin", admin.ToString()) },
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials

                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;


        }
    }
}
