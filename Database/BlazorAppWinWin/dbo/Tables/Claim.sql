CREATE TABLE [dbo].[Claim] (
    [ClaimId]    BIGINT          IDENTITY (400000, 1) NOT NULL,
    [ClaimType]  INT             NULL,
    [TotalItems] INT             NULL,
    [TotalCost]  DECIMAL (19, 2) NULL,
    [Status]     INT             NULL,
    [CreatedOn]  DATETIME        NULL,
    [CreatedBy]  BIGINT          NULL,
    [ModifidOn]  DATETIME        NULL,
    [ModifiedBy] BIGINT          NULL,
    PRIMARY KEY CLUSTERED ([ClaimId] ASC)
);

