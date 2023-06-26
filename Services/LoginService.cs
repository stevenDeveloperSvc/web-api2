using claimbased.Data.Models;
using claimbased.Data.DTOs;
using claimbased.Data;
using Microsoft.EntityFrameworkCore;

namespace claimbased.Services;



public class LoginService
{


    private readonly BankContext _bankContext;

    public LoginService(BankContext bankContext)
    {
        _bankContext = bankContext;

    }

    public async Task<User?> GetUser(UserDto userDto) =>  await _bankContext.Users.SingleOrDefaultAsync( x => x.Username == userDto.username && x.Password  == userDto.Password );


}