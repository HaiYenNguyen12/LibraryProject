// using DatingApp.API.Database;
// using DatingApp.API.Database.entities;
// using DatingApp.API.DTOs;
// using DatingApp.API.Services;
// using Microsoft.AspNetCore.Mvc;
// using System.Security.Cryptography;
// using System.Text;

// namespace DatingApp.API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class AccountController : BaseApiController

//     {
//         private readonly DataContext _context;
//         private readonly ITokenService _tokenservice;
//         public AccountController(DataContext context, ITokenService tokenService)
//         {
//             _context = context;
//             _tokenservice = tokenService;
//         }

//         [HttpPost("register")]
//         public ActionResult<string> Register(RegisterDto registerDto)
//         {
//             registerDto.Username.ToLower();
//             if(_context.Users.Any(i => i.Username == registerDto.Username)){
//                 return BadRequest("Username is existed!");
//             }
//             using var hmac = new HMACSHA512();
//             var user = new User
//             {
//                 Username = registerDto.Username,
//                 Email = registerDto.Email,
//                 passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerDto.Password)),
//                 passwordSalt = hmac.Key,
//                 Role = registerDto.Role
//             };
//             _context.Users.Add(user);
//             _context.SaveChanges();
//             return Ok(_tokenservice.CreateToken(user));
//         }


//         [HttpPost("login")]
//         public ActionResult<string> Login(LoginDto loginDto)
//         {
//             var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username.ToLower());
//             if (user == null) {
//                 return Unauthorized("Invalid username!!");
//             }
//             using var hmac = new HMACSHA512(user.passwordSalt);
//             var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
//              for(int i = 0; i < computedHash.Length; i++){
//                      if (computedHash[i] != user.passwordHash[i]) return Unauthorized("Invalid password");
//              }
//             return Ok(_tokenservice.CreateToken(user));
//         }

//     }
// }