using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using src.Models;
using src.Interfaces;
using src.Exceptions;



namespace src.Controllers;

[ApiController]
[Route("network")]
public class NetworkController : ControllerBase
{
    private readonly JsonSerializerOptions serializerOptions;
    private readonly IRepository<Network> _repository;
    
    public NetworkController(IRepository<Network> repository)
    {
        _repository = repository;
        serializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] Network network)
    {   
        if (network == null)
        {
            throw new BadRequestException("Неверные данные");
        }

        _repository.Create(network);
        return new StatusCodeResult(StatusCodes.Status201Created);
    }
    
    [HttpGet("get")]
    public IActionResult Get()
    {   
        IEnumerable<NetworkDto> networks = _repository.GetAll()
                                                      .Select(
                                                        w => 
                                                        new NetworkDto(id: w.Id, name: w.Name))
                                                      .ToList();

        return new JsonResult(networks, serializerOptions);
    }

    [HttpGet("get/{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        Network network = _repository.GetById(id);

        if (network == null)
        {
            throw new ObjectNotFoundException("Объект Network не найден");
        }

        return new JsonResult(
            new NetworkDto(id: network.Id, name: network.Name),
            serializerOptions
        );

    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] Network network)
    {   
        if (network == null || network.Id == 0)
        {
            throw new BadRequestException("Неверные данные");
        }
        else if (_repository.GetById(network.Id) == null)
        {
            throw new ObjectNotFoundException("Объект Network не найден");
        }
        else
        {
            _repository.Update(network);
            return StatusCode(StatusCodes.Status204NoContent);
        }   
    }

    [HttpDelete("remove/{id}")]
    public IActionResult Remove([FromRoute] int id)
    {
        if (id == 0)
        {
            throw new BadRequestException("id объекта не может быть равен нулю");
        }
        else if (_repository.GetById(id) == null)
        {
            throw new ObjectNotFoundException("Объект Network не найден");
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

