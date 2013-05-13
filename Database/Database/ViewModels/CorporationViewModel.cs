using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModels
{
    public class CorporationViewModel
    {
        SQLiteAsyncConnection _connection;

        public CorporationViewModel()
        {
            _connection = new SQLiteAsyncConnection("Employee.db");
        }

        public Task<int> CreateEmployer(Employer employer)
        {
            return _connection.InsertAsync(employer);
        }

        public Task<Employer> GetEmployer(Employer value)
        {
            return _connection.GetAsync<Employer>( value );
        }

        public Task<int> CreateEmployee(Employee employee)
        {
            return _connection.InsertAsync(employee);

        }

        public Task<int> CreateClient(Client client)
        {
            return _connection.InsertAsync(client);
        }

        public Task<int> DeleteEmployer(Employer employer)
        {
            return _connection.DeleteAsync(employer);
        }

        public Task<int> DeleteEmployee(Employee employee)
        {
            return _connection.DeleteAsync(employee);
        }
    }
}
