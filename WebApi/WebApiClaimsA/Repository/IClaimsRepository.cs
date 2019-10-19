using DomainModel;
using DomainModel.ClaimsA.Create;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClaimsA.Repository
{
    public interface IClaimsRepository
    {
        [Sql(@"SELECT  COUNT_BIG(ClaimId)  FROM [dbo].[Claim] WHERE CreatedBy = @userId")]
        Task<Int64> GetClaimsCountAsync(Int64 userId);

        [Sql(@"SELECT TOP (1) [ClaimId] FROM [dbo].[Claim] WHERE [CreatedBy] = @userId AND  [Status] = 1")]
        Task<Int64?> GetOpenClaimIdAsync(Int64 userId);

        [Sql(@"[dbo].[P_CreateClaimA]")]
        Task<Int64> CreateClaimAAsync(ClaimAItemModel claimAItem);

        [Sql(@"SELECT *  FROM [dbo].[ClaimItem] WHERE ClaimId = @claimAId")]
        Task<List<ClaimAItemModel>> GetClaimItemsAsync(Int64 claimAId);

        [Sql(@"DELETE FROM [dbo].[ClaimItem] WHERE ClaimItemsId = @claimItemid")]
        Task DeleteClaimItemsAsync(Int64 claimItemid);
    }
}