using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq.Expressions;
using src.Models;
using src.Interfaces;
using src.Exceptions;
using src.DataTransferObjects;



namespace src.Controllers;

[ApiController]
[Route("clientcurrency")]
public class ClientCurrencyController : ControllerBase
{
    private readonly JsonSerializerOptions serializerOptions;

    private readonly IRepository<ClientCurrency> _clientCurrencyRepository;

    private readonly IRepository<PaymentMethod> _paymentMethod;
    
    public ClientCurrencyController(
        IRepository<ClientCurrency> clientCurrencyRepository,
        IRepository<PaymentMethod> paymentMethod
        )
    {
        _clientCurrencyRepository = clientCurrencyRepository;
        _paymentMethod = paymentMethod;

        serializerOptions = new JsonSerializerOptions
        { 
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            IncludeFields = true
        };
    }
    
    private IEnumerable<ClientCurrency> GetWithInclude(Func<ClientCurrency, bool> predicate = null)
    {
        var expressions = new Expression<Func<ClientCurrency, object>>[2]
        {
            w => w.Networks,
            w => w.PaymentMethod
        };

        var result = _clientCurrencyRepository.Get(predicate: predicate, includeProperties: expressions);

        return result;
    }

    [HttpPost("create")]
    public IActionResult Create(
        [FromBody]ClientCurrencyDtoRequest currencyDto
    )
    {   
        if (!ModelState.IsValid)
        {
            throw new BadRequestException("Неверные данные");
        }

        if (_paymentMethod.GetById(currencyDto.PaymentMethodId) == null)
        {
            throw new ObjectNotFoundException($"PaymentMethod с id = {currencyDto.PaymentMethodId} не найден");
        }
        
        ClientCurrency newCurrency = new ClientCurrency()
        {
            Name = currencyDto.Name,
            ShortName = currencyDto.ShortName,
            ImagePath = currencyDto.ImagePath,
            PaymentMethodId = currencyDto.PaymentMethodId
        };

        _clientCurrencyRepository.Create(newCurrency);

        return new JsonResult(new { message = "Объект успешно создан" });
    }

    [HttpGet("get/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = GetWithInclude(w => w.Id == id)
            .Select(currency => new ClientCurrencyDto
                {
                    Id = currency.Id,
                    Name = currency.Name,
                    ShortName = currency.ShortName,
                    ImagePath = currency.ImagePath,
                    PaymentMethod = new PaymentMethodDto
                                        {
                                            Id = currency.PaymentMethod.Id,
                                            Name = currency.PaymentMethod.Name
                                        }
                }).SingleOrDefault();

        return new JsonResult(result, serializerOptions);
    }

    [HttpGet("get")]
    public IActionResult GetAll()
    {   
        var expressions = new Expression<Func<ClientCurrency, object>>[2]
        {
            w => w.Networks,
            w => w.PaymentMethod
        };

        var result = _clientCurrencyRepository.Get(includeProperties: expressions)
            .Select(currency => new ClientCurrencyDto
                {
                    Id = currency.Id,
                    Name = currency.Name,
                    ShortName = currency.ShortName,
                    ImagePath = currency.ImagePath,
                    PaymentMethod = new PaymentMethodDto
                                        {
                                            Id = currency.PaymentMethod.Id,
                                            Name = currency.PaymentMethod.Name
                                        }
                });

        return new JsonResult(result, serializerOptions);
    } 

    [HttpPut("update")]
    public IActionResult Update([FromBody]ClientCurrencyDtoRequest currencyDto)
    {
        if (!ModelState.IsValid || currencyDto.Id == 0)
        {
            throw new BadRequestException("Неверные данные");
        }

        var expressions = new Expression<Func<ClientCurrency, object>>[1]
        {
            w => w.Networks
        };

        var currency = GetWithInclude(w => w.Id == currencyDto.Id).SingleOrDefault();

        if (currency == null)
        {
            throw new ObjectNotFoundException($"Network с id = {currencyDto.Id} не найден");
        }

        var paymentMethod = _paymentMethod.Get(predicate: w => w.Id == currencyDto.PaymentMethodId);

        if (paymentMethod == null)
        {
            throw new ObjectNotFoundException($"Network с id = {currencyDto.PaymentMethodId} не найден");
        }
        

        currency.Name = currencyDto.Name;
        currency.ShortName = currencyDto.ShortName;
        currency.ImagePath = currencyDto.ImagePath;
        currency.PaymentMethodId = currencyDto.PaymentMethodId;

        _clientCurrencyRepository.Update(currency);

        return new JsonResult(new { message = "Объект успешно обновлён" });
    }
}
