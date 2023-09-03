using Microsoft.EntityFrameworkCore;
using src.Interfaces;
using src.Models;



namespace src.Repositories;

public class EFPaymentMethodRepository : IPaymentMethodRepository
{
    private readonly ApplicationContext _context;
    private readonly DbSet<PaymentMethod> _dbSet;

    public EFPaymentMethodRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<PaymentMethod>();
    }

    public void Create(PaymentMethod method)
    {
        _dbSet.Add(method);
        _context.SaveChanges();
    }

    public IEnumerable<PaymentMethod> GetAll()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public PaymentMethod GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Remove(PaymentMethod method)
    {
        _dbSet.Remove(method);
        _context.SaveChanges();
    }

    public void Update(PaymentMethod method)
    {
        _context.SaveChanges();
    }
}