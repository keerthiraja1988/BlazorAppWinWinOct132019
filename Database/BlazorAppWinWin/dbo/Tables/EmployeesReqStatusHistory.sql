CREATE TABLE [dbo].[EmployeesReqStatusHistory] (
    [EmployeesReqStatusHistoryId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [EmployeeId]                  BIGINT        NULL,
    [EmployeeRequestId]           BIGINT        NULL,
    [EmpAppOprStatusId]           SMALLINT      NULL,
    [EmpAppReqStatusId]           SMALLINT      NULL,
    [Comments]                    VARCHAR (MAX) NULL,
    [CreatedOn]                   DATETIME      NULL,
    [CreatedByUserId]             BIGINT        NULL,
    [ModifidOn]                   DATETIME      NULL,
    [ModifiedByUserId]            BIGINT        NULL,
    CONSTRAINT [PK_dbo.EmployeesReqStatusHistoryId] PRIMARY KEY CLUSTERED ([EmployeesReqStatusHistoryId] DESC)
);





