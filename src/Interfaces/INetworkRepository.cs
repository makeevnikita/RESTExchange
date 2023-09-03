using src.Models;



namespace src.Interfaces;

public interface INetworkRepository
{
    void Create(Network network);

    Network GetById(int id);
}