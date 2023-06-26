using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using src.Models;
using src.Interfaces;



namespace src.Controllers;

[ApiController]
[Route("network")]
public class NetworkController : ControllerBase
{
    private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };
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

        return new StatusCodeResult(StatusCodes.Status201Created);
    }
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {   
        IEnumerable<NetworkDto> networks = _repository.GetAll()
                                                      .Select(
                                                        w => 
                                                        new NetworkDto(id: w.Id, name: w.Name))
                                                      .ToList();

        return new JsonResult(networks, serializerOptions);
    }

    [HttpGet("getById")]
    public IActionResult GetById(int id)
    {
        Network network = _repository.GetById(id);

        return new JsonResult(
            new NetworkDto(id: network.Id, name: network.Name),
            serializerOptions
        );

    }

    [HttpPut("update")]
    public IActionResult Update(Network network)
    {   
        if (network == null || network.Id == 0)
        {
            return BadRequest("Неверный запрос");
        }
        else if (_repository.GetById(network.Id) == null)
        {
            return NotFound("Такого объекта не существует");
        }
        else
        {
            _repository.Update(network);
            return StatusCode(StatusCodes.Status204NoContent);
        }   
    }

    [HttpDelete]
    public IActionResult Remove(int id)
    {
        if (id == 0)
        {
            return BadRequest("Нужен id объекта");
        }
        else if (_repository.GetById(id) == null)
        {
            return NotFound("Такого объекта не существует");
        }
        else
        {
            _repository.Remove(_repository.GetById(id));
            return StatusCode(StatusCodes.Status204NoContent);
        }
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

