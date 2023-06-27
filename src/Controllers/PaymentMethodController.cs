using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using src.Models;
using src.Interfaces;
using src.Exceptions;



namespace src.Controllers;

[ApiController]
[Route("paymentmethod")]
public class PaymentMethodController : ControllerBase
{
    private readonly JsonSerializerOptions serializerOptions;
    private readonly IRepository<PaymentMethod> _repository;

    public PaymentMethodController(IRepository<PaymentMethod> repository)
    {
        _repository = repository;
        serializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    [HttpPost("create")]
    public IActionResult CreatePaymentMethod([FromBody] PaymentMethod method)
    {   
        if (method == null)
        {
            throw new BadRequestException("Неверные данные");
        }
        else
        {
            _repository.Create(method);
            return new JsonResult(new { message = "Объект успешно создан" });
        }
    }

    [HttpGet("get")]
    public IActionResult Get()
    {   
        IEnumerable<PaymentMethodDto> networks = _repository.GetAll()
                                                      .Select(
                                                        w => 
                                                        new PaymentMethodDto(id: w.Id, name: w.Name))
                                                      .ToList();

        return new JsonResult(networks, serializerOptions);
    }

    [HttpGet("get/{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        PaymentMethod method = _repository.GetById(id);

        if (method == null)
        {
            throw new ObjectNotFoundException("Объект PaymentMethod не найден");
        }
        else
        {
            return new JsonResult(
            new PaymentMethodDto(id: method.Id, name: method.Name),
            serializerOptions
        );
        }
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] PaymentMethod method)
    {   
        if (method == null || method.Id == 0)
        {
            throw new BadRequestException("Неверные данные");
        }
        else if (_repository.GetById(method.Id) == null)
        {
            throw new ObjectNotFoundException("Объект PaymentMethod не найден");
        }
        else
        {
            _repository.Update(method);
            
            return new JsonResult(new { message = "Объект успешно обновлён" });
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
            throw new ObjectNotFoundException("Объект PaymentMethod не найден");
        }
        else
        {
            _repository.Remove(_repository.GetById(id));
            
            return new JsonResult(new { message = "Объект успешно удалён" });
        }
    }
}

public class PaymentMethodDto
{
    public int Id { get; }
    public string Name { get; }

    public PaymentMethodDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
