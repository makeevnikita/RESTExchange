namespace src.DataTransferObjects;



public class NetworkDto
{   
    public int Id { get; set; }
    
    public string Name { get; set; }

    public IEnumerable<ClientCurrencyDto> ClientCurrencies { get; set; }

}

public class NetworkDtoRequest
{   
    public int Id { get; set; }

    public string Name { get; set; }

    public int[] Currencies { get; set; }
}
