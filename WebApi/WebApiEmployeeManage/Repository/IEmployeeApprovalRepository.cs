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

        [Sql(@"SELECT  * FROM EmpAppReqStatus")]
        Task<List<EmpAppReqStatus>> GetAllEmpAppReqStatusAsync();

        [Sql("[dbo].[P_GetCreateEmployeeReq]")]
        Task<EmployeePendingApproval> GetCreateEmployeeReqAsync(long employeeRequestId);

        [Sql("P_ProcessCreateEmployee")]
        Task<bool> ProcessCreateEmployeeAsync(EmployeePendingApproval processCreateEmployee);

        [Sql("P_GetEmployeeReqStatusHistory")]
        Task<List<EmployeesReqStatusHistory>> GetEmployeeReqStatusHistory(long employeeId, long employeeRequestId);
    }
}