using DomainModel;
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

    }
}
