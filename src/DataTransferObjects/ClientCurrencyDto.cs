using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace src.DataTransferObjects;

public class ClientCurrencyDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string ShortName { get; set; }

    public string ImagePath { get; set; }

    public PaymentMethodDto PaymentMethod { get; set; }
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
}
