// using Microsoft.AspNetCore.Mvc;
// using claimbased.Data.Models;
// using claimbased.Services;
// using claimbased.Data.DTOs;
// using Microsoft.AspNetCore.Authorization;
// //using Microsoft.Extensions.DependencyInjection.ObjectFactory;


// namespace claimbased.Controllers;





// [Authorize]
// [ApiController]
// [Route("[controller]")]
// public class AccountController : ControllerBase
// {
//     private readonly AccountServices _service;
//     private AccountTypeServices accountTypeServices;
//     private ClientServices clientServices;
//     public AccountController(AccountServices service)
//     {
//         _service = service;
//     }

//     [HttpGet]
//     public async Task<IEnumerable<AccountDToOut>> Get() => await _service.GetAll();

    
//     [HttpGet("{id}")]
//     public async Task<ActionResult<AccountDToOut>> GetById(int id)
//     {
//         var account = await  _service.GetDtoById(id);

//         if (account is null)
//             return notFoundMessage(id);

//         return account;

//     }

//     [HttpPost]
//     public async Task<IActionResult> Create(AccountDToIn accountDTO)
//     {

// //        string validationResult = await ValidateAccount((Account)accountDTO);

//         // if(!validationResult.Equals("Valid"))
//         //         return BadRequest(new  { message = validationResult });

//         var newAccount = await _service.Create(accountDTO);

//         return CreatedAtAction(nameof(GetById), new { id = newAccount.Id }, accountDTO);
//     }


//     [HttpPut("{id}")]
//     public async Task<IActionResult> Update(int id, AccountDToIn accountDTO)
//     {
//         if (id != accountDTO.id)
//             return BadRequest();

//         var accountToUpdate = await _service.GetById(id);

//         if (accountToUpdate is not null)
//         {
//             await _service.udpate(accountDTO, id);
//             return NoContent();
//         }
//         else
//         {
//             return NotFound();
//         }

//     }


//     [HttpDelete("{id}")]
//     public async Task<IActionResult> Delete(int id)
//     {


//         var accountToDelete = await _service.GetById(id);

//         if (accountToDelete is not null)
//         {
//              await _service.Delete(id);
//             return Ok();
//         }
//         else
//         {
//            return notFoundMessage(id);

//         }
//     }


//     public NotFoundObjectResult notFoundMessage (int id)
//     {
//         return NotFound(new  { message = $"la cuenta con ID = {id} no existe."} );
//     }

//     public async Task<string> ValidateAccount (Account account)
//     {
//         string result = "Valid";

//         var accountType = await accountTypeServices.GetById(account.AccountType);

//         if (accountType is null)
//                 result = $"El tipo de cuenta {account.AccountType} no existe";

//         var clientID = account.ClientId.GetValueOrDefault();

//         var client = await clientServices.GetById(clientID);

//         if(client is null)
//                 result = $"El cliente {clientID} no existe";
        
//         return result;

//     }

// }
