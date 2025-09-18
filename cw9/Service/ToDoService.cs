using cw9.Dto;
using cw9.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cw9.IService;
using cw9.Contracts;
using cw9.Repositorise;
using Microsoft.VisualBasic.FileIO;
namespace cw9.Service
{
    public class ToDoService : IToDoService
    {
        //IRepository _repo = new FileRepository(@"C:\maktab2\file2.txt");
        private IRepository _repo = new DapperRepository();

        public int AddItem(ItemDto item)
        {

            ToDoItem newitem = new ToDoItem()
            {
                //Id = _repo.GetId(),
                Title = item.Title,
                Description = item.Description,
                IsDone = false
            };

            return _repo.Create(newitem);

        }

        public List<ToDoItem> ShowAllTasks()
        {
            return _repo.GetAll();
        }

        public void Changestatus(int id, bool st)
        {
            if (_repo.GetById(id).Id == 0)
                throw new Exception("Not Found!");
            else
            { _repo.UpdateStatus(id, st); }


        }
        public ToDoItem TaskDetails(int id)
        {
            ToDoItem toDoItem = _repo.GetById(id);
            if (toDoItem.Id == 0)
                throw new Exception("Not Found!");
            return toDoItem;

        }

        public void DeleteTask(int id)
        {
            if (_repo.GetById(id).Id == 0)
                throw new Exception("Not Found!");

            _repo.Delete(id);

        }
    }
}
