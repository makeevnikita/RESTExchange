using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
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
    private readonly IClientCurrencyRepository _clientCurrencyRepository;
    private readonly IPaymentMethodRepository _paymentMethodRepository;
    private readonly INetworkRepository _networkRepository;
    
    public ClientCurrencyController(
        IClientCurrencyRepository clientCurrencyRepository,
        IPaymentMethodRepository paymentMethodRepository,
        INetworkRepository networkRepository
    )
    {
        _clientCurrencyRepository = clientCurrencyRepository;
        _paymentMethodRepository = paymentMethodRepository;
        _networkRepository = networkRepository;
        serializerOptions = new JsonSerializerOptions
        { 
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            IncludeFields = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }

    [HttpPost("create")]
    public IActionResult Create(
        [FromQuery] string name, [FromQuery] string shortName,
        [FromQuery] string imagePath, [FromQuery] int paymentMethodId,
        [FromQuery] int[] network
    )
    {
        ClientCurrency currency = new ClientCurrency()
        {
            Name = name,
            ShortName = shortName,
            ImagePath = imagePath,
        };

        PaymentMethod method = _paymentMethodRepository.GetById(paymentMethodId);

        if (method == null)
        {
            throw new ObjectNotFoundException("Object not found");
        }
        else
        {
            currency.PaymentMethod = method;
        }

        foreach (int i in network)
        {
            Network net = _networkRepository.GetById(i);

            if (net == null)
            {
                throw new ObjectNotFoundException("Object not found");
            }
            else
            {
                currency.Networks.Add(net);
            }
        }

        _clientCurrencyRepository.Create(currency);

        return new JsonResult(new { message = "Объект успешно создан" });
    }

    [HttpGet("get")]
    public IActionResult GetById([FromQuery] int id)
    { 
        ClientCurrencyDto currency = _clientCurrencyRepository.GetById(id)
        .Select(currency => new ClientCurrencyDto
                {
                    Id = currency.Id,
                    Name = currency.Name,
                    ShortName = currency.ShortName,
                    ImagePath = currency.ImagePath,
                    Networks = currency.Networks.Select(
                        network => new NetworkDto
                        {
                            Id = network.Id,
                            Name = network.Name
                        }
                    ),
                    PaymentMethod = new PaymentMethodDto
                        {
                            Id = currency.PaymentMethod.Id,
                            Name = currency.PaymentMethod.Name
                        }
                }).SingleOrDefault();

        return new JsonResult(currency, serializerOptions);
    }

    [HttpGet("get_all")]
    public IActionResult GetAll()
    {   
        IEnumerable<ClientCurrencyDto> currencies = _clientCurrencyRepository.GetAll()
        .Select(currency => new ClientCurrencyDto
                {
                    Id = currency.Id,
                    Name = currency.Name,
                    ShortName = currency.ShortName,
                    ImagePath = currency.ImagePath,
                    Networks = currency.Networks.Select(
                        network => new NetworkDto
                        {
                            Id = network.Id,
                            Name = network.Name
                        }
                    ),
                    PaymentMethod = new PaymentMethodDto
                        {
                            Id = currency.PaymentMethod.Id,
                            Name = currency.PaymentMethod.Name
                        }
                });
                
        return new JsonResult(currencies, serializerOptions);
    } 

    [HttpPut("update")]
    public IActionResult Update(
        [FromQuery] int id, [FromQuery] string? name, [FromQuery] string? shortName,
        [FromQuery] string? imagePath, [FromQuery] int? paymentMethodId,
        [FromQuery] int[]? network
        )
    {
        ClientCurrency currency = _clientCurrencyRepository.GetById(id).SingleOrDefault();
        
        if (currency == null)
        {
            throw new ObjectNotFoundException("Object not found");
        }

        if (!string.IsNullOrEmpty(name))
        {
            currency.Name = name;
        }
        if (!string.IsNullOrEmpty(shortName))
        {
            currency.ShortName = shortName;
        }
        if (!string.IsNullOrEmpty(imagePath))
        {
            currency.ImagePath = imagePath;
        }
        if (network.Length > 0)
        {
            currency.Networks.Clear();
            _clientCurrencyRepository.Update(currency);

            foreach (int i in network)
            {
                Network net = _networkRepository.GetById(i);

                if (net == null)
                {
                    throw new ObjectNotFoundException("Object not found");
                }
                else
                {
                    currency.Networks.Add(net);
                }
            }
        }
        if (paymentMethodId.HasValue)
        {
            PaymentMethod method = _paymentMethodRepository.GetById(paymentMethodId.Value);

            if (method == null)
            {
                throw new ObjectNotFoundException("Object not found");
            }
            else
            {
                currency.PaymentMethod = method;
            }
        }

        _clientCurrencyRepository.Update(currency);
        return new JsonResult(new { message = "Object was updated successfully" });
    }

    [HttpDelete("remove")]
    public IActionResult Remove([FromQuery] int id)
    {
        ClientCurrency currency = _clientCurrencyRepository.GetById(id).SingleOrDefault();

        if (currency == null)
        {
            throw new ObjectNotFoundException("Object not found");
        }

        _clientCurrencyRepository.Remove(currency);
        return new JsonResult(new { message = "Object was successfully deleted" });
    }
}
