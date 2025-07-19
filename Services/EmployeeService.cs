using CoreAPIWithMySQL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAPIWithMySQL.Data;

namespace CoreAPIWithMySQL.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task<bool> UpdateAsync(int id, Employee employee);
        Task<bool> DeleteAsync(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            return await _repository.AddAsync(employee);
        }

        public async Task<bool> UpdateAsync(int id, Employee employee)
        {
            if (!await _repository.ExistsAsync(id))
                return false;

            employee.Id = id;
            await _repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _repository.ExistsAsync(id))
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}