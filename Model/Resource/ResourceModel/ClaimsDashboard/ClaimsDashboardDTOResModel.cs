using FluentValidation;
using ResourceModel.ClaimsA.Create;
using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceModel.ClaimsDashboard
{
    public class ClaimsDashboardDTOResModel
    {
        public Int64 ClaimsACount { get; set; }
    }
}