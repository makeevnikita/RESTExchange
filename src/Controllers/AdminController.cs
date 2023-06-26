using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using src.Models;
using src.Interfaces;
using src.Repositories;



namespace src.Controllers;

[ApiController]
[Route("network")]
public class NetworkController : ControllerBase
{
    private readonly IRepository<Network> _repository;
    
    public NetworkController(IRepository<Network> repository)
    {
        _repository = repository;
    }

    [HttpPost("create")]
    public IActionResult CreateNetwork(Network network)
    {   
        if (network == null)
        {
            return BadRequest();
        }

        _repository.Create(network);

        return new OkResult();
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {   
        IEnumerable<NetworkDto> networks = _repository.GetAll()
                                                      .Select(
                                                        w => 
                                                        new NetworkDto(id: w.Id, name: w.Name))
                                                      .ToList();

        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        return new JsonResult(networks, options);
    }
}
public class NetworkDto
{   
    public int Id { get; }
    public string Name { get; }

    public NetworkDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

