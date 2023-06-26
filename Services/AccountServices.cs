// using Microsoft.EntityFrameworkCore;
// using claimbased.Data;
// using claimbased.Data.Models;
// using claimbased.Data.DTOs;

// namespace claimbased.Services;


// public class AccountServices
// {
//     private readonly BankContext _bankContext;

//     public AccountServices(BankContext bankcontext)
//     {
//         _bankContext = bankcontext;
//     }


//     public async Task<IEnumerable<AccountDToOut>> GetAll() => await _bankContext.Accounts.Select(a => new AccountDToOut
//     {
//         id = a.Id,
//         AccountName = a.AccountTypeNavigation.Name,
//         ClientName = a.Client != null ? a.Client.Name : "",
//         Balance = a.Balance,
//         RegDate = a.RegDate
//     }).ToListAsync();


//     public async Task<AccountDToOut?> GetDtoById(int id) => await _bankContext.Accounts.Where(a => a.Id == id).Select(a => new AccountDToOut
//     {
//         id = a.Id,
//         AccountName = a.AccountTypeNavigation.Name,
//         ClientName = a.Client != null ? a.Client.Name : "",
//         Balance = a.Balance,
//         RegDate = a.RegDate
//     }).SingleOrDefaultAsync();


//     public async Task<Account?> GetById(int id) => await _bankContext.Accounts.FindAsync(id);


//     public async Task<Account> Create(AccountDToIn accountDTO)
//     {
//         var newAccount = new Account()
//         {
//             AccountType = accountDTO.AccountType,
//             ClientId = accountDTO.CLientId,
//             Balance = accountDTO.Balance
//         };

//         await _bankContext.Accounts.AddAsync(newAccount);
//         await _bankContext.SaveChangesAsync();
//         return newAccount;

//     }

//     public async Task udpate(AccountDToIn accountDTO, int id)
//     {
//         var existingClient = await GetById(id);

//         if (existingClient is not null)
//         {

//             existingClient.AccountType = accountDTO.AccountType;
//             existingClient.Balance = accountDTO.Balance;
//             existingClient.ClientId = accountDTO.CLientId;


//             await _bankContext.SaveChangesAsync();
//         }


//     }
//     public async Task Delete(int id)
//     {
//         var accountToDelete = await GetById(id);

//         if (accountToDelete is not null)
//         {
//             _bankContext.Accounts.Remove(accountToDelete);
//             await _bankContext.SaveChangesAsync();
//         }
//     }

// }