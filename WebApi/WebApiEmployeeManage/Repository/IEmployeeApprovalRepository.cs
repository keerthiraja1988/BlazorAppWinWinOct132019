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
    public interface IEmployeeApprovalRepository
    {
        [Sql("P_GetAllEmployeesPendingApprovals")]
        Task<List<Employee>> GetAllEmployeesPendingApprovalsAsync();
    }
}