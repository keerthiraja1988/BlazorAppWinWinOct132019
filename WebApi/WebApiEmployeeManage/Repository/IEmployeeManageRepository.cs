using DomainModel;
using DomainModel.EmployeeManage;
using DomainModel.EmployeeManage.Dimension;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiEmployeeManage.Repository
{
    public interface IEmployeeManageRepository
    {
        [Sql(@"SELECT *  FROM [dbo].[EmployeeTitle]")]
        Task<List<EmployeeTitle>> GetAllEmployeeTitlesAsync();

        [Sql("P_CreateEmployee")]
        Task<Employee> CreateEmployeeAsync(Employee createEmployee, string comments);
    }
}