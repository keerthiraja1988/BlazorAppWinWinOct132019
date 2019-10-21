CREATE TABLE [dbo].[UserDetail] (
    [UserId]     BIGINT        IDENTITY (10000, 1) NOT NULL,
    [UserName]   VARCHAR (255) NULL,
    [FirstName]  VARCHAR (255) NULL,
    [LastName]   VARCHAR (255) NULL,
    [Email]      VARCHAR (500) NULL,
    [Password]   VARCHAR (255) NULL,
    [IsActive]   BIT           NULL,
    [UserType]   INT           NULL,
    [CreatedOn]  DATETIME      NULL,
    [CreatedBy]  BIGINT        NULL,
    [ModifidOn]  DATETIME      NULL,
    [ModifiedBy] BIGINT        NULL
);

