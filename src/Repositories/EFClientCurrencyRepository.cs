using Microsoft.EntityFrameworkCore;
using src.Interfaces;



namespace src.Models;

public class EFClientCurrencyRepository : IClientCurrencyRepository
{
    private readonly ApplicationContext _context;
    private readonly DbSet<ClientCurrency> _dbSet;

    public EFClientCurrencyRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<ClientCurrency>();
    }

    public void Create(ClientCurrency currency)
    {
        _dbSet.Add(currency);
        _context.SaveChanges();
    }

    public IEnumerable<ClientCurrency> GetById(int id)
    {
        var result = _dbSet.Where(w => w.Id == id)
                            .Include(w => w.Networks)
                            .Include(w => w.PaymentMethod).ToList();
        return result;
    }

    public IEnumerable<ClientCurrency> GetAll()
    {
        var result = _dbSet.Include(w => w.Networks).Include(w => w.PaymentMethod).ToList();
        return result;
    }

    public void Update(ClientCurrency currency)
    {
        _context.SaveChanges();
    }

    public void Remove(ClientCurrency currency)
    {
        _dbSet.Remove(currency);
        _context.SaveChanges();
    }
}