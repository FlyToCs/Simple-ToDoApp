using cw9.Contracts;
using cw9.Dto;
using cw9.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cw9.Repositorise
{
    public class FileRepository : IRepository
    {
        public FileRepository(string filePath)
        {

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            Filepath = filePath;
        }
        private readonly string Filepath;
        private List<ToDoItem> LoadFile()
        {
            string json = File.ReadAllText(Filepath);
            return JsonConvert.DeserializeObject<List<ToDoItem>>(json) ?? new List<ToDoItem>();
        }
        public int GetId()
        {
            var list = LoadFile();
            if (list.Count == 0)
                return 1;
            else
                return list.MaxBy(x => x.Id).Id + 1;
        }
        public void SaveFile(List<ToDoItem> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(Filepath, json);
        }
        public int Create(ToDoItem item)
        {
          
            var list = LoadFile();
            list.Add(item);
            SaveFile(list);
            return item.Id;

        }

        public void UpdateStatus(int id , bool status)//must be Dto
        {
            var list = LoadFile();
            
            foreach (var item in list)
            {
                if (item.Id == id)
                {
                   item.IsDone=status;
                    break;
                }
            }
            SaveFile(list);

        }

      


        public List<ToDoItem> GetAll()
        {
           return LoadFile();
        }

        
        public ToDoItem GetById(int id)
        {
            var list =LoadFile();
            foreach (var item in list)
            {
                if(item.Id == id)
                    return item;
            }
            return new ToDoItem();
        }

        public void Delete(int id)
        {
            var list = LoadFile();
            foreach ( var item in list )
            {
                if (item.Id==id)
                {
                    list.Remove(item);
                    break;
                }
            }
            SaveFile(list);
        }
    }
}
