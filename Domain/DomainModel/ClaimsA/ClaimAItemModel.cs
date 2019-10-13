using System;

namespace DomainModel.ClaimsA.Create
{
    public class ClaimAItemModel
    {
        public long ClaimId { get; set; }

        public long ClaimItemsId { get; set; }

        public int ClaimType { get; set; }

        public string InvoiceNumber { get; set; }

        public int ProductId { get; set; }

        public int ReasonId { get; set; }

        public decimal ProductTotalCost { get; set; }

        public decimal ProductCost { get; set; }

        public int Quantity { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifidOn { get; set; }

        public long ModifiedBy { get; set; }
    }
}