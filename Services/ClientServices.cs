using Microsoft.EntityFrameworkCore;
using claimbased.Data;
using claimbased.Data.Models;

namespace claimbased.Services;


public class ClientServices
{
    private readonly BankContext _bankContext;

    public ClientServices(BankContext bankcontext)
    {
        _bankContext = bankcontext;
    }


    public async Task<IEnumerable<Client>> GetAll() => await _bankContext.Clients.ToListAsync();


    public async Task<Client?> GetById(int id) => await _bankContext.Clients.FindAsync(id);


    public async Task<Client> Create(Client newClient)
    {
        await _bankContext.Clients.AddAsync(newClient);
        await _bankContext.SaveChangesAsync();
        return newClient;

    }

    // public async Task udpate(Client client, int id)
    // {
    //     var existingClient = await GetById(id);

    //     if (existingClient is not null)
    //     {

    //         existingClient.Name = client.Name;
    //         existingClient.PhoneNumber = client.PhoneNumber;
    //         existingClient.Email = client.Email;


    //         await _bankContext.SaveChangesAsync();
    //     }


    // }
    // public async Task Delete(int id)
    // {
    //     var clientToDelete = await GetById(id);

    //     if (clientToDelete is not null)
    //     {
    //         _bankContext.Clients.Remove(clientToDelete);
    //         await _bankContext.SaveChangesAsync();
    //     }


    // }

}