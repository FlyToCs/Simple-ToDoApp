using cw9.Dto;
using cw9.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw9.IService
{
    public interface IToDoService
    {
        int AddItem(ItemDto item);
        ToDoItem TaskDetails(int id);
        void DeleteTask(int id);
        List<ToDoItem> ShowAllTasks();
        void ChangeStatus(int taskId, bool result);
    }
}
