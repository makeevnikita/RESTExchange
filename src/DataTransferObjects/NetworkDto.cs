namespace src.DataTransferObjects;



public class NetworkDto
{   
    public int Id { get; set; }
    
    public string Name { get; set; }

    public IEnumerable<ClientCurrencyDto> ClientCurrencies { get; set; }

}

public class NetworkDtoRequest
{   
    public int Id { get; }

    public string Name { get; }

    public int[] Currencies { get; set; }

    public NetworkDtoRequest(int id, string name, int[] currencies)
    {
        Id = id;
        Name = name;
        Currencies = currencies;
    }
}