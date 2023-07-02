using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using src.Interfaces;
using src.Models;



namespace src.Repositories;

public class EFRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _dbSet;

    public EFRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Create(T item)
    {
        _dbSet.Add(item);
        _context.SaveChanges();
    }

    public IEnumerable<T> Get(Func<T, bool> predicate = null, Expression<Func<T, object>>[] includeProperties = null)
    {   
        IQueryable<T> query = _dbSet.AsNoTracking();

        if (includeProperties != null && includeProperties.Count() != 0)
        {
            query = includeProperties.Aggregate(query, (current, property) => current.Include(property));
        }

        if (predicate != null)
        {
            query = query.Where(predicate).AsQueryable();
        }

        return query.ToList();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public T GetById(int id)
    {
        T item = _dbSet.Find(id);

        return item;
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        _context.SaveChanges();
    }

    public void Update(T item)
    {
        _dbSet.Update(item);
        _context.SaveChanges();
    }
}
