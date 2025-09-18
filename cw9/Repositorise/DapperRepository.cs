using cw9.Contracts;
using cw9.Entites;
using Dapper;

using Microsoft.Data.SqlClient;





namespace cw9.Repositorise
{
    public class DapperRepository : IRepository
    {
        private readonly string _connectionString =
            "Data Source=localhost; database=ToDoApp; User ID=sa;Password=123456;TrustServerCertificate=True;Encrypt=True";


        public int GetId() 
        {
            throw new NotImplementedException();
        }

        public int Create(ToDoItem item)
        {
            var connection = new SqlConnection(_connectionString);
            var query =
                "INSERT INTO ToDoItems (Title, Description, IsDone) VALUES (@Title, @Description, @IsDone); SELECT CAST (SCOPE_IDENTITY() AS INT);";
            //connection.Execute(query, item);
            int id = connection.QuerySingle<int>(query, item);
            item.Id = id;
            return id;
        }

        public void UpdateStatus(int id, bool st)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public ToDoItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}


