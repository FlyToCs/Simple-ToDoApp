using System.Security.Cryptography.X509Certificates;
using cw9.Contracts;
using cw9.Data_Access;
using cw9.Entites;
using Microsoft.EntityFrameworkCore;

namespace cw9.Repositorise;

public class EfRepository : IRepository
{
    private readonly AppDbContext _dbContext = new AppDbContext();
    public int GetId()
    {
        throw new NotImplementedException();
    }

    public int Create(ToDoItem item)
    {
        _dbContext.Add(item);
        _dbContext.SaveChanges();
        return item.Id;
    }

    public void UpdateStatus(int id, bool st)
    {
        var item = _dbContext.ToDoItems.Find(id);
        if (item != null)
        {
            item.IsDone = st;
            _dbContext.SaveChanges();
        }
    }

    public List<ToDoItem> GetAll()
    {
        return _dbContext.ToDoItems.ToList();
    }

    public ToDoItem GetById(int id)
    {
        return _dbContext.ToDoItems.Find(id);
    }

    public void Delete(int id)
    {
        var entity = _dbContext.ToDoItems.Find(id);
        if (entity != null)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}