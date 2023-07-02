namespace src.DataTransferObjects;

public class PaymentMethodDto
{
    public int Id { get; }
    public string Name { get; }

    public PaymentMethodDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}