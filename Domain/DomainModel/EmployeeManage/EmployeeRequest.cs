using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.EmployeeManage
{
    public class EmployeeRequest
    {
        public long EmployeeRequestId { get; set; }

        public long? EmployeeId { get; set; }

        public short? EmpAppOprStatusId { get; set; }

        public short? EmpAppReqStatusId { get; set; }

        public short? Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalEmail { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? DOJ { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifidOn { get; set; }

        public long? ModifiedBy { get; set; }
    }
}