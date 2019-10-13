using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceModel.ClaimsA.Create
{
    public class CreateClaimsADTOResModel
    {
        public CreateClaimsAResModel CreateClaims { get; set; } = new CreateClaimsAResModel();

        public Int64 ClaimId { get; set; }
    }
}