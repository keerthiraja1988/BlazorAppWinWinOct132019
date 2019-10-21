namespace WebApiEmployeeManage.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DomainModel;
    using DomainModel.EmployeeApproval;
    using DomainModel.EmployeeManage;
    using DomainModel.EmployeeManage.Dimension;
    using Insight.Database;

    public interface IEmployeeApprovalRepository
    {
        [Sql("P_GetAllEmployeesPendingApprovals")]
        Task<List<EmployeePendingApproval>> GetAllEmployeesPendingApprovalsAsync();
    }
}