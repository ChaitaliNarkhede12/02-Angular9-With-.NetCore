using Application.Interfaces;
using DataaAccess.Interfaces;
using DataaAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeAppService : IEmployeeApp
    {
        public readonly IRepository<Employee> _employeeRepository;
        public EmployeeAppService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            var result = await _employeeRepository.Get();
            if (result == null)
            {
                throw new Exception("error");
            }
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeById(Expression<Func<Employee, bool>> predicate)
        {
            var result = await _employeeRepository.Get(predicate);
            if (result == null)
            {
                throw new Exception("error");
            }
            return result;
        }

        public Employee GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("error");
            }

            var result = _employeeRepository.GetById(id);

            if (result == null)
            {
                throw new Exception("error");
            }
            return result;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new Exception("error");
            }

            await this._employeeRepository.Add(employee);
            var result = await _employeeRepository.SaveChangesAsync();

            if (result <= 0)
            {
                throw new Exception("error");
            }
            return result;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            if (employee.EmpId <= 0)
            {
                throw new Exception("error");
            }

            this._employeeRepository.Update(employee);
            var result = await _employeeRepository.SaveChangesAsync();

            if (result <= 0)
            {
                throw new Exception("error");
            }
            return result;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                throw new Exception("error");
            }

            var employee = _employeeRepository.GetById(id);

            if (employee == null)
            {
                throw new Exception("error");
            }

            _employeeRepository.Delete(employee);
            var result = await _employeeRepository.SaveChangesAsync();

            if (result <= 0)
            {
                throw new Exception("error");
            }

            return result;

        }
    }
}
