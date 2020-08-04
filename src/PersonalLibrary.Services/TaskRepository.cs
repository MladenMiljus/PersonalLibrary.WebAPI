using Dapper;
using Microsoft.Extensions.Configuration;
using PersonalLibrary.DataModels;
using PersonalLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalLibrary.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configiration;
        private readonly SqlConnection _connection;

        public TaskRepository(IConfiguration configiration)
        {
            _configiration = configiration;
            _connection = new SqlConnection(_configiration.GetConnectionString("PersonalLibraryConnection"));
        }

        public async Task<int> Add(Locations entity)
        {
            var sql = "INSERT INTO dbo.Locations (UserID, GroupID, LocationName, LocationDescription, LocationAddress, LocationCity, LocationCountryID, Active) " +
                "VALUES (@UserID, @GroupID, @LocationName, @LocationDescription, @LocationAddress, @LocationCity, @LocationCountryID, @Active)";
            using (_connection)
            {
                _connection.Open();
                var affectedRows = await _connection.ExecuteAsync(sql, entity);
                _connection.Close();
                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM dbo.Locations WHERE Id = @Id;";
            using (_connection)
            {
                _connection.Open();
                var affectedRows = await _connection.ExecuteAsync(sql, new { Id = id });
                _connection.Close();
                return affectedRows;
            }
        }

        public async Task<Locations> Get(int id)
        {
            var sql = "SELECT * FROM Locations l WHERE Id = @Id;";
            using (_connection)
            {
                _connection.Open();
                var result = await _connection.QueryAsync<Locations>(sql, new { Id = id });
                _connection.Close();
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Locations>> GetAll()
        {
            var sql = "SELECT * FROM Locations l;";
            using (_connection)
            {
                _connection.Open();
                var result = await _connection.QueryAsync<Locations>(sql);
                _connection.Close();
                return result;
            }
        }

        public async Task<int> Update(Locations entity)
        {
            var sql = "UPDATE Locations SET UserID = @UserID, GroupID = @GroupID, LocationName = @LocationName, " +
                "LocationDescription = @LocationDescription, LocationAddress = @LocationAddress, " +
                "LocationCity = @LocationCity, LocationCountryID = @LocationCountryID, Active = @Active WHERE Id = @Id;";
            using (_connection)
            {
                _connection.Open();
                var affectedRows = await _connection.ExecuteAsync(sql, entity);
                _connection.Close();
                return affectedRows;
            }
        }
    }
}
