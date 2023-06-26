using Microsoft.AspNetCore.Mvc;
using claimbased.Services;
using claimbased.Data.Models;
using claimbased.Data.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using claimbased.Data;
using System.Text;

namespace claimbased.Controllers;


[ApiController]
[Route("[controller]")]

public class LoginController : ControllerBase
{
    private IConfiguration _config;
    private readonly LoginService _loginService;

    private readonly BankContext _bankcontext;

    public LoginController(LoginService loginService, IConfiguration configuration, BankContext bankContext)
    {
        _loginService = loginService;
        _bankcontext = bankContext;
        _config = configuration;

    }


    [HttpPost("authenticate")]

    public async Task<IActionResult> Login(UserDto userDto)
    {
        var user = await _loginService.GetUser(userDto);

        if (user is null)
            return BadRequest(new { message = "Credenciales Invalidas" });

        string jwtToken = GenerateToken(user);

        return Ok(new { token = jwtToken });
    }



    public string GenerateToken(User account)
    {

        // string role = _bankcontext.UserPermissions.Where(a=> a.Userid  == account.Id).Select(a=> new UserDtoClaim {
        //     Role = a.RoleType != null ? a.RoleType.RoleName : " ",
        // } ).SingleOrDefault().ToString();



        var claims = new[]
        {
                     new Claim (ClaimTypes.Name, account.Username),
                     new Claim (ClaimTypes.Email, account.Email),
                     new Claim ("id", account.Id.ToString())
                    //  new Claim(ClaimTypes.Role, role )
                };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var securityToken = new JwtSecurityToken(
                claims: claims,

                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
        );



        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }

}