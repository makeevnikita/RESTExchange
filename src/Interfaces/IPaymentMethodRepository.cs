using src.Models;



namespace src.Interfaces;

public interface IPaymentMethodRepository
{
    PaymentMethod GetById(int id);
    
    IEnumerable<PaymentMethod> GetAll();
    
    void Create(PaymentMethod method);
    
    void Remove(PaymentMethod method);

    void Update(PaymentMethod method);
}