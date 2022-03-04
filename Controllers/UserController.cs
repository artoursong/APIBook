using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using bookAPI.Service;
using bookAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserService userService;
        private readonly IConfiguration _config; // to get key, issuer from appsettings.json

        public UserController(IConfiguration config)
        {
            userService = new UserService();
            _config = config;
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userService.Get();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userService.Get(id);
        }

        [HttpPost]
        public bool Post(User user)
        {
            return userService.Post(user);
        }

        [HttpPut("{id}")]
        public LoginData Put(int id, [FromBody] User user)
        {
            User userinfo = userService.Put(id, user);
            LoginData loginData = new LoginData
            {
                ID_User = userinfo.ID_User,
                name = userinfo.Name,
                username = userinfo.Username,
                coin = userinfo.Coin,
                email = userinfo.Email,
                role = userinfo.Role,
                ban = userinfo.Ban
            };
            
            return loginData;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userService.Delete(id);
        }

        [HttpPost("banuser/{id}")]
        public bool BanUser(int id)
        {
            return userService.Banuser(id);
        }

        public JwtSecurityToken CreateToken(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("ID_User", user.ID_User.ToString()));
            var secret_key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]);
            var symmetricSecurityKey = new SymmetricSecurityKey(secret_key);
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var access_token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );

            return access_token;
        }

        [HttpPost("decodetoken")]
        public LoginData DecodeToken(Token stream)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(stream.tokenstring) as JwtSecurityToken;
            int ID_User = Int32.Parse(token.Claims.First(claim => claim.Type == "ID_User").Value);
            
            User user = userService.Get(ID_User);

            LoginData loginData = new LoginData
            {
                ID_User = user.ID_User,
                name = user.Name,
                username = user.Username,
                coin = user.Coin,
                email = user.Email,
                role = user.Role,
                ban = user.Ban
            };


            return loginData;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            User userlogin = userService.Login(user);
            var token = tokenHandler.WriteToken(CreateToken(userlogin));
            LoginData loginData = new LoginData
            {
                ID_User = userlogin.ID_User,
                name = userlogin.Name,
                username = userlogin.Username,
                coin = userlogin.Coin,
                email = userlogin.Email,
                role = userlogin.Role,
                ban = userlogin.Ban
            };
            ResponseLogin responseLogin = new ResponseLogin{
                token = token,
                LoginData = loginData
            };
            if (userlogin != null) return Ok(responseLogin);

            return BadRequest("Invalid");
        }

        [HttpPut("changepass")]
        public bool NewPassword(ChangePass changePass) {
            return userService.NewPassChange(changePass);
        }
        
        [HttpPost("passforgot/{username}")]
        public bool PassForgot(string username) {
            return userService.passforgot(username);
        }

    }
}