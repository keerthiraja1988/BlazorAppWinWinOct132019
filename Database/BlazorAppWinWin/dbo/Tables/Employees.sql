CREATE TABLE [dbo].[Employees] (
    [EmployeeId]    BIGINT        IDENTITY (300000, 1) NOT NULL,
    [Title]         SMALLINT      NULL,
    [FirstName]     VARCHAR (255) NULL,
    [LastName]      VARCHAR (255) NULL,
    [PersonalEmail] VARCHAR (500) NULL,
    [DOB]           DATETIME      NULL,
    [DOJ]           DATETIME      NULL,
    [IsActive]      BIT           NULL,
    [CreatedOn]     DATETIME      NULL,
    [CreatedBy]     BIGINT        NULL,
    [ModifidOn]     DATETIME      NULL,
    [ModifiedBy]    BIGINT        NULL,
    CONSTRAINT [PK_dbo.EmployeeId] PRIMARY KEY CLUSTERED ([EmployeeId] DESC)
);



