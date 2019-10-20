using ResourceModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ResourceModel.EmployeeManage
{
    public class EmployeeResModel
    {
        public long EmployeeRequestId { get; set; }

        public long EmployeeId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string PersonalEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOB { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DOJ { get; set; }

        public string Comments { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifidOn { get; set; }

        public long? ModifiedBy { get; set; }
    }
}