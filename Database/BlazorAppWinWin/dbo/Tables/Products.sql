CREATE TABLE [dbo].[Products] (
    [ProductId]        BIGINT          IDENTITY (30000, 1) NOT NULL,
    [ProductName]      VARCHAR (MAX)   NULL,
    [ManufacturerName] VARCHAR (MAX)   NULL,
    [Cost]             DECIMAL (19, 2) NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

