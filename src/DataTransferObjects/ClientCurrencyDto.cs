using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;



namespace src.DataTransferObjects;

public class ClientCurrencyDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string ShortName { get; set; }

    public string ImagePath { get; set; }

    public PaymentMethodDto PaymentMethod { get; set; }

    public IEnumerable<NetworkDto> Networks { get; set; }

    public ClientCurrencyDto(
        int id, string name, string shortName, string imagePath,
        PaymentMethodDto paymentMethod, IEnumerable<NetworkDto> networks
        )
    {
        Id = id;
        Name = name;
        ShortName = shortName;
        ImagePath = imagePath;
        PaymentMethod = paymentMethod;
        Networks = networks;
    }
}

public class ClientCurrencyDtoRequest
{
    public int? Id { get; set; }

    [BindRequired]
    public string Name { get; set; }

    [BindRequired]
    public string ShortName { get; set; }

    [BindRequired]
    public string ImagePath { get; set; }

    [BindRequired]
    public int PaymentMethodId { get; set; }

    [ValidateNever]  
    public int[] Networks { get; set; }

    public ClientCurrencyDtoRequest(
        int? id, string name, string shortName, string imagePath,
        int paymentMethodId, int[] networks
        )
    {
        Id = id;
        Name = name;
        ShortName = shortName;
        ImagePath = imagePath;
        PaymentMethodId = paymentMethodId;
        Networks = networks;
    }
}
