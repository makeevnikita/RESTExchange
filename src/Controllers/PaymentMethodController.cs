using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Encodings.Web;
using src.Models;
using src.Interfaces;
using src.Exceptions;
using src.DataTransferObjects;



namespace src.Controllers;

[ApiController]
[Route("paymentmethod")]
public class PaymentMethodController : ControllerBase
{
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly IPaymentMethodRepository _repository;

    public PaymentMethodController(IPaymentMethodRepository repository)
    {
        _repository = repository;
        _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }

    [HttpPost("create")]
    public IActionResult CreatePaymentMethod([FromQuery] string name)
    {   
        if (string.IsNullOrEmpty(name))
        {
            throw new BadRequestException("Invalid data");
        }
        else
        {
            _repository.Create(new PaymentMethod { Name = name });
            return new JsonResult(new { message = "Object was created successfully" });
        }
    }

    [HttpGet("get_all")]
    public IActionResult Get()
    {   
        IEnumerable<PaymentMethodDto> networks = _repository.GetAll()
            .Select(method => new PaymentMethodDto
                {
                    Id = method.Id,
                    Name = method.Name
                }).ToList();

        return new JsonResult(networks, _serializerOptions);
    }

    [HttpGet("get")]
    public IActionResult GetById([FromQuery] int id)
    {
        PaymentMethod method = _repository.GetById(id);

        if (method == null)
        {
            throw new ObjectNotFoundException("Object not found");
        }

        return new JsonResult
            (
                new PaymentMethodDto
                    {
                        Id = method.Id,
                        Name = method.Name
                    },
                _serializerOptions
            );
    }

    [HttpPut("update")]
    public IActionResult Update([FromQuery] int id, [FromQuery] string newName)
    {   
        if (id == 0 || string.IsNullOrEmpty(newName))
        {
            throw new BadRequestException("Invalid data");
        }

        PaymentMethod method = _repository.GetById(id); 

        if (method == null)
        {
            throw new ObjectNotFoundException("Object not found");
        }
        else
        {
            method.Name = newName;
            _repository.Update(method);
            return new JsonResult(new { message = "Object was updated successfully" });
        }   
    }

    [HttpDelete("remove")]
    public IActionResult Remove([FromQuery] int id)
    {
        if (id <= 0)
        {
            throw new BadRequestException("Invalid data");
        }

        PaymentMethod method = _repository.GetById(id);

        if (method == null)
        {
            throw new ObjectNotFoundException("Object not found");
        }
        else
        {
            _repository.Remove(method);
            return new JsonResult(new { message = "Object was successfully deleted" });
        }
    }
}
