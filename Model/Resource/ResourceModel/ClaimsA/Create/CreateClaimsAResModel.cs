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
        public int? ProductId { get; set; } = null;

        [Required]
        [Range(1, 99999)]
        public int? Quantity { get; set; } = 0;

        [Required]
        [Range(0.01, 9999999)]
        public decimal? ProductCost { get; set; } = null;

        private decimal? productTotalCost;

        public decimal? ProductTotalCost
        {
            set
            {
                productTotalCost = ProductCost * Quantity;
            }
            get
            {
                return ProductCost * Quantity;
            }
        }

        [Required]
        public string ReasonId { get; set; }

        public string Comments { get; set; }

        public long CreatedBy { get; set; }
    }
}