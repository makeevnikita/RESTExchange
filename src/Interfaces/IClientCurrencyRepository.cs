using src.Models;



namespace src.Interfaces;

public interface IClientCurrencyRepository
{
    void Create(ClientCurrency currency);

    IEnumerable<ClientCurrency> GetById(int id);

    IEnumerable<ClientCurrency> GetAll();

    void Update(ClientCurrency currency);

    void Remove(ClientCurrency currency);
}