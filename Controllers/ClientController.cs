using Microsoft.AspNetCore.Mvc;
using claimbased.Data.Models;
using claimbased.Services;
using Microsoft.AspNetCore.Authorization;

namespace claimbased.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientServices _service;

    public ClientController(ClientServices service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Client>> Get() => await _service.GetAll();



    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetById(int id)
    {
        var client = await  _service.GetById(id);

        if (client is null)
            return notFoundMessage(id);

        return client;

    }

      public NotFoundObjectResult notFoundMessage (int id)
    {
        return NotFound(new  { message = $"El cliente con ID = {id} no existe."} );
    }


    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        var newClient = await _service.Create(client);

        return CreatedAtAction(nameof(GetById), new { id = newClient.Id }, client);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Update(int id, Client client)
    // {
    //     if (id != client.Id)
    //         return BadRequest();

    //     var clientToUpdate = await _service.GetById(id);

    //     if (clientToUpdate is not null)
    //     {
    //         await _service.udpate(client, id);
    //         return NoContent();
    //     }
    //     else
    //     {
    //         return NotFound();
    //     }

    // }


    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {


    //     var clientToDelete = await _service.GetById(id);

    //     if (clientToDelete is not null)
    //     {
    //          await _service.Delete(id);
    //         return Ok();
    //     }
    //     else
    //     {
    //        return notFoundMessage(id);

    //     }
    // }


  
}
