namespace src.DataTransferObjects;



public class NetworkDto
{   
    public int Id { get; }
    public string Name { get; }

    public NetworkDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}