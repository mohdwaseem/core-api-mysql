using CoreAPIWithMySQL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace CoreAPIWithMySQL.Services
{
    public class DapperEmployeeService : IDapperEmployeeService
    {
        private readonly string _connectionString;

        public DapperEmployeeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using var db = Connection;
            var sql = "SELECT * FROM Employees";
            return await db.QueryAsync<Employee>(sql);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using var db = Connection;
            var sql = "SELECT * FROM Employees WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            using var db = Connection;
            var sql = @"INSERT INTO Employees (Name, Position, Salary) VALUES (@Name, @Position, @Salary); SELECT LAST_INSERT_ID();";
            var id = await db.ExecuteScalarAsync<int>(sql, employee);
            employee.Id = id;
            return employee;
        }

        public async Task<bool> UpdateAsync(int id, Employee employee)
        {
            using var db = Connection;
            var sql = @"UPDATE Employees SET Name = @Name, Position = @Position, Salary = @Salary WHERE Id = @Id";
            var affected = await db.ExecuteAsync(sql, new { employee.Name, employee.Position, employee.Salary, Id = id });
            return affected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var db = Connection;
            var sql = "DELETE FROM Employees WHERE Id = @Id";
            var affected = await db.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }
    }
}