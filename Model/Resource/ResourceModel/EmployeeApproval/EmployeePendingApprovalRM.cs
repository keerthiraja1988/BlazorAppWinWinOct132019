namespace ResourceModel.EmployeeApproval
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeePendingApprovalRM
    {
        public long EmployeeId { get; set; }

        public long EmployeeRequestId { get; set; }

        public short? EmpAppOprStatusId { get; set; }

        public string EmpAppOprStatusDesc { get; set; }

        public short? EmpAppReqStatusId { get; set; }

        public string EmpAppReqStatusDesc { get; set; }

        public short? Title { get; set; }

        public string EmployeeTitleDesc { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalEmail { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? DOJ { get; set; }

        public bool? IsActive { get; set; }

        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedByUserId { get; set; }

        public string CreatedByUserName { get; set; }

        public string CreatedByFullName { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedByUserId { get; set; }

        public string ModifiedByUserName { get; set; }

        public string ModifiedByFullName { get; set; }
    }
}