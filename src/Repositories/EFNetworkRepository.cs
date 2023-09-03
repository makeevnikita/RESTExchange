using Microsoft.EntityFrameworkCore;
using src.Interfaces;
using src.Models;



namespace src.Repositories;

public class EFNetworkRepository : INetworkRepository
{   
    private readonly ApplicationContext _context;
    private readonly DbSet<Network> _dbSet;

    public EFNetworkRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<Network>();
    }
    public void Create(Network network)
    {
        _dbSet.Add(network);
        _context.SaveChanges();
    }

    public Network GetById(int id)
    {
        return _dbSet.Find(id);
    }
}