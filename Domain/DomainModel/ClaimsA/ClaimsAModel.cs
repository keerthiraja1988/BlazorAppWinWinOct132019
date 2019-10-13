using System;

namespace DomainModel.ClaimsA.Create
{
    public class ClaimsAModel
    {
        public long ClaimId { get; set; }

        public long ClaimItemsId { get; set; }

        public int ClaimType { get; set; }

        public int TotalItems { get; set; }

        public decimal TotalCost { get; set; } = 0.00m;

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifidOn { get; set; }

        public long ModifiedBy { get; set; }
    }
}