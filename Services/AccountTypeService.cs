// using Microsoft.EntityFrameworkCore;
// using claimbased.Data;
// using claimbased.Data.Models;

// namespace claimbased.Services;


// public class AccountTypeServices
// {
//     private readonly BankContext _bankContext;

//     public AccountTypeServices(BankContext bankcontext)
//     {
//         _bankContext = bankcontext;
//     }


//     // public async Task<IEnumerable<Account>> GetAll() => await _bankContext.Accounts.ToListAsync();


//     public async Task<AccountType?> GetById(int id) => await _bankContext.AccountTypes.FindAsync(id);


//     // public async Task<Account> Create(Account newAccount)
//     // {
//     //     await _bankContext.Accounts.AddAsync(newAccount);
//     //     await _bankContext.SaveChangesAsync();
//     //     return newAccount;

//     // }

//     // public async Task udpate(Account client, int id)
//     // {
//     //     var existingClient = await GetById(id);

//     //     if (existingClient is not null)
//     //     {

//     //         existingClient.AccountType = client.AccountType;
//     //         existingClient.Balance = client.Balance;
//     //         existingClient.ClientId = client.ClientId;


//     //         await _bankContext.SaveChangesAsync();
//     //     }


//     // }
//     // public async Task Delete(int id)
//     // {
//     //     var accountToDelete = await GetById(id);

//     //     if (accountToDelete is not null)
//     //     {
//     //         _bankContext.Accounts.Remove(accountToDelete);
//     //         await _bankContext.SaveChangesAsync();
//     //     }
//     // }

// }