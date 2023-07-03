using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using src.Models;
using src.Interfaces;
using src.Exceptions;
using src.DataTransferObjects;
using System.Linq.Expressions;



namespace src.Controllers;

[ApiController]
[Route("network")]
public class NetworkController : ControllerBase
{
    private readonly JsonSerializerOptions serializerOptions;
    private readonly IRepository<Network> _networkRepository;
    private readonly IRepository<ClientCurrency> _clientCurrencyRepository;
    
    public NetworkController(
        IRepository<Network> networkRepository, IRepository<ClientCurrency> clientCurrencyRepository
    )
    {
        _networkRepository = networkRepository;
        _clientCurrencyRepository = clientCurrencyRepository;
        serializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    private IEnumerable<Network> GetWithInclude(Func<Network, bool> predicate = null)
    {
        var expressions = new Expression<Func<Network, object>>[1]
        {
            w => w.ClientCurrencies
        };

        IEnumerable<Network> networks = _networkRepository.Get(predicate: predicate, includeProperties: expressions);
        
        return networks;
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] NetworkDtoRequest networkDto)
    {   
        if (!ModelState.IsValid)
        {
            throw new BadRequestException("Неверные данные");
        }

        Network newNetwork = new Network { Name = networkDto.Name };

        foreach (int id in networkDto.Currencies)
        {
            ClientCurrency currency = _clientCurrencyRepository.GetById(id);
            if (currency == null)
            {
                throw new ObjectNotFoundException($"Объект ClientCurrency id = {currency.Id} не найден");  
            }
            newNetwork.ClientCurrencies.Add(currency);
        }
        
        _networkRepository.Create(newNetwork);

        return new JsonResult(new { message = "Объект успешно создан" });
    }
    
    [HttpGet("get")]
    public IActionResult GetAll()
    {   
        IEnumerable<NetworkDto> networks = GetWithInclude()
            .Select(network => new NetworkDto { Id = network.Id, Name = network.Name,
                                                ClientCurrencies = network.ClientCurrencies.Select(
                                                    currency => new ClientCurrencyDto {   
                                                                Id = currency.Id,
                                                                Name = currency.Name,
                                                                ShortName = currency.ShortName,
                                                                ImagePath = currency.ImagePath,
                                                                PaymentMethodId = currency.PaymentMethodId
                                                            }
                                                        )
                                            });

        return new JsonResult(networks, serializerOptions);
    }

    [HttpGet("get/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {

        NetworkDto? networkDto = GetWithInclude().Select(network => new NetworkDto { Id = network.Id, Name = network.Name,
                                                ClientCurrencies = network.ClientCurrencies.Select(
                                                    currency => new ClientCurrencyDto {   
                                                                Id = currency.Id,
                                                                Name = currency.Name,
                                                                ShortName = currency.ShortName,
                                                                ImagePath = currency.ImagePath,
                                                                PaymentMethodId = currency.PaymentMethodId
                                                            }
                                                        )
                                            }).SingleOrDefault(w => w.Id == id);

        if (networkDto == null)
        {
            throw new ObjectNotFoundException("Объект Network не найден");
        }

        return new JsonResult(networkDto, serializerOptions);

    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] NetworkDtoRequest networkRequest)
    {   
        if (!ModelState.IsValid)
        {
            throw new BadRequestException("Неверные данные");
        }

        Network? updatedNetwork = GetWithInclude().SingleOrDefault(w => w.Id == networkRequest.Id);

        if (updatedNetwork == null)
        {
            throw new ObjectNotFoundException($"Объект Network id = {networkRequest.Id} не найден");    
        }

        updatedNetwork.Name = networkRequest.Name;
        updatedNetwork.ClientCurrencies.Clear();
        
        _networkRepository.Update(updatedNetwork);

        foreach (int id in networkRequest.Currencies)
        {   
            ClientCurrency currency = _clientCurrencyRepository.GetById(id);
            if (currency == null)
            {
                throw new ObjectNotFoundException($"Объект ClientCurrency id = {currency.Id} не найден");  
            }
            updatedNetwork.ClientCurrencies.Add(currency);
        }

        _networkRepository.Update(updatedNetwork);

        return new JsonResult(new { message = "Объект успешно обновлён" });
    }

    [HttpDelete("remove/{id}")]
    public IActionResult Remove([FromRoute] int id)
    {
        if (id <= 0)
        {
            throw new BadRequestException("Id не может быть отрицатлеьным или равным нулю");
        }

        if (_networkRepository.GetById(id) == null)
        {
            throw new ObjectNotFoundException($"Объект Network id = {id} не найден");
        }

        _networkRepository.Remove(_networkRepository.GetById(id));
            
        return new JsonResult(new { message = "Объект успешно удалён" });
    }
}
