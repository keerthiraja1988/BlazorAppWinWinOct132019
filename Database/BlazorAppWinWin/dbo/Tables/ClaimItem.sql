CREATE TABLE [dbo].[ClaimItem] (
    [ClaimItemsId]     BIGINT          IDENTITY (50000, 1) NOT NULL,
    [ClaimId]          BIGINT          NULL,
    [InvoiceNumber]    VARCHAR (500)   NULL,
    [ProductId]        BIGINT          NULL,
    [ReasonId]         INT             NULL,
    [ProductCost]      DECIMAL (19, 2) NULL,
    [Quantity]         INT             NULL,
    [ProductTotalCost] DECIMAL (19, 2) NULL,
    [Comments]         VARCHAR (MAX)   NULL,
    [CreatedOn]        DATETIME        NULL,
    [CreatedBy]        BIGINT          NULL,
    [ModifidOn]        DATETIME        NULL,
    [ModifiedBy]       BIGINT          NULL,
    PRIMARY KEY CLUSTERED ([ClaimItemsId] ASC)
);

