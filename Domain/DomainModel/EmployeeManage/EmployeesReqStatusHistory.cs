namespace DomainModel.EmployeeManage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeesReqStatusHistory
    {
        public long? Id { get; set; }

        public long EmployeesReqStatusHistoryId { get; set; }

        public long? EmployeeId { get; set; }

        public long? EmployeeRequestId { get; set; }

        public short? EmpAppOprStatusId { get; set; }

        public string EmpAppOprStatusDesc { get; set; }

        public short? EmpAppReqStatusId { get; set; }

        public string EmpAppReqStatusDesc { get; set; }

        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public string CreatedByUserName { get; set; }

        public string CreatedByFullName { get; set; }

        public DateTime? ModifidOn { get; set; }

        public long? ModifiedBy { get; set; }

        public string ModifiedByUserName { get; set; }

        public string ModifiedByFullName { get; set; }
    }
}