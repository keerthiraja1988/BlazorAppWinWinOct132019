namespace ResourceModel.EmployeeApproval
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ProcessCreateEmployeeRM
    {
        public string EmployeeId { get; set; }

        public string EmployeeRequestId { get; set; }

        [Required]
        public string EmpAppReqStatusId { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Comments { get; set; }

        public long? CreatedBy { get; set; }
    }
}