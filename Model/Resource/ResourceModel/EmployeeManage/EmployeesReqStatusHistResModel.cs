using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceModel.EmployeeManage
{
    public class EmployeesReqStatusHistResModel
    {
        private long EmployeesReqStatusHistoryId { get; set; }

        public long? EmployeeId { get; set; }

        public long? EmployeeRequestId { get; set; }

        public short? EmpAppOprStatusId { get; set; }

        public short? EmpAppReqStatusId { get; set; }

        public string Comments { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifidOn { get; set; }

        public long? ModifiedBy { get; set; }
    }
}