using CoreAPIWithMySQL.Models;

namespace CoreAPIWithMySQL.Services
{
    public interface IDapperEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<bool> UpdateAsync(int id, Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}