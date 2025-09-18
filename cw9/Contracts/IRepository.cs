using cw9.Dto;
using cw9.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw9.Contracts
{
    public interface IRepository
    {
        int GetId ();
        int Create(ToDoItem item);
        void UpdateStatus(int id , bool st);
        List<ToDoItem> GetAll();
        ToDoItem GetById(int id);
        void Delete(int id);
       
    }
}
