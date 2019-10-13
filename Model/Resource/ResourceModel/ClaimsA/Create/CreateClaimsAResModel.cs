using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceModel.ClaimsA.Create
{
    public class CreateClaimsAResModel
    {
        public long ClaimItemsId { get; set; }

        public long ClaimId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Invoice Number must be 10 Characters")]
        public string InvoiceNumber { get; set; }

        [Required]
        [Range(30000, 99999)]
        public int ProductId { get; set; }

        [Required]
        public string ReasonId { get; set; }

        public decimal ProductCost { get; set; } = 0.00m;

        [Required]
        [Range(1, 99999)]
        public int? Quantity { get; set; }

        public decimal ProductTotalCost { get; set; }

        public string Comments { get; set; }
    }
}