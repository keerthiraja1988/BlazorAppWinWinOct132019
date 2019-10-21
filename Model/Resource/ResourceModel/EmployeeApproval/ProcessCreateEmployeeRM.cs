namespace ResourceModel.EmployeeApproval
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ProcessCreateEmployeeRM
    {
        [Required]
        public string EmpAppReqStatusId { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(500)]
        public string Comments { get; set; }
    }
}