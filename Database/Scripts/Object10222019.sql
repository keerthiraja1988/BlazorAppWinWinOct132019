USE [BlazorAppWinWin]
GO
/****** Object:  StoredProcedure [dbo].[P_RegisterUser]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_RegisterUser]
GO
/****** Object:  StoredProcedure [dbo].[P_ProcessCreateEmployee]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_ProcessCreateEmployee]
GO
/****** Object:  StoredProcedure [dbo].[P_GetEmployeeReqStatusHistory]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_GetEmployeeReqStatusHistory]
GO
/****** Object:  StoredProcedure [dbo].[P_GetCreateEmployeeReq]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_GetCreateEmployeeReq]
GO
/****** Object:  StoredProcedure [dbo].[P_GetAllEmployeesPendingApprovals]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_GetAllEmployeesPendingApprovals]
GO
/****** Object:  StoredProcedure [dbo].[P_CreateEmployee]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_CreateEmployee]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[ELMAH_LogError]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[ELMAH_GetErrorXml]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[ELMAH_GetErrorsXml]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELMAH_Error]') AND type in (N'U'))
ALTER TABLE [dbo].[ELMAH_Error] DROP CONSTRAINT IF EXISTS [DF_ELMAH_Error_ErrorId]
GO
/****** Object:  Index [IX_ELMAH_Error_App_Time_Seq]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP INDEX IF EXISTS [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[UserDetail]
GO
/****** Object:  Table [dbo].[EmployeeTitle]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[EmployeeTitle]
GO
/****** Object:  Table [dbo].[EmployeesReqStatusHistory]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[EmployeesReqStatusHistory]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[Employees]
GO
/****** Object:  Table [dbo].[EmployeeRequests]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[EmployeeRequests]
GO
/****** Object:  Table [dbo].[EmpAppReqStatus]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[EmpAppReqStatus]
GO
/****** Object:  Table [dbo].[EmpAppOprStatus]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[EmpAppOprStatus]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 10/22/2019 12:06:41 AM ******/
DROP TABLE IF EXISTS [dbo].[ELMAH_Error]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELMAH_Error](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[Application] [nvarchar](60) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL,
 CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpAppOprStatus]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpAppOprStatus](
	[EmpAppOprStatusId] [smallint] IDENTITY(10,1) NOT NULL,
	[EmpAppOprStatusDesc] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpAppReqStatus]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpAppReqStatus](
	[EmpAppReqStatusId] [smallint] IDENTITY(100,1) NOT NULL,
	[EmpAppReqStatusDesc] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRequests]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRequests](
	[EmployeeRequestId] [bigint] IDENTITY(80000,1) NOT NULL,
	[EmployeeId] [bigint] NULL,
	[EmpAppOprStatusId] [smallint] NULL,
	[EmpAppReqStatusId] [smallint] NULL,
	[Title] [smallint] NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[PersonalEmail] [varchar](500) NULL,
	[DOB] [datetime] NULL,
	[DOJ] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedByUserId] [bigint] NULL,
 CONSTRAINT [PK_dbo.EmployeeRequestId] PRIMARY KEY CLUSTERED 
(
	[EmployeeRequestId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [bigint] IDENTITY(300000,1) NOT NULL,
	[Title] [smallint] NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[PersonalEmail] [varchar](500) NULL,
	[DOB] [datetime] NULL,
	[DOJ] [datetime] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedByUserId] [bigint] NULL,
 CONSTRAINT [PK_dbo.EmployeeId] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesReqStatusHistory]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesReqStatusHistory](
	[EmployeesReqStatusHistoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NULL,
	[EmployeeRequestId] [bigint] NULL,
	[EmpAppOprStatusId] [smallint] NULL,
	[EmpAppReqStatusId] [smallint] NULL,
	[Comments] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedByUserId] [bigint] NULL,
 CONSTRAINT [PK_dbo.EmployeesReqStatusHistoryId] PRIMARY KEY CLUSTERED 
(
	[EmployeesReqStatusHistoryId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTitle]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTitle](
	[EmployeeTitleId] [smallint] IDENTITY(50,1) NOT NULL,
	[EmployeeTitleDesc] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetail](
	[UserId] [bigint] IDENTITY(10000,1) NOT NULL,
	[UserName] [varchar](255) NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[Email] [varchar](500) NULL,
	[Password] [varchar](255) NULL,
	[IsActive] [bit] NULL,
	[UserType] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedByUserId] [bigint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ELMAH_Error_App_Time_Seq]    Script Date: 10/22/2019 12:06:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error]
(
	[Application] ASC,
	[TimeUtc] DESC,
	[Sequence] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT 
        @TotalCount = COUNT(1) 
    FROM 
        [ELMAH_Error]
    WHERE 
        [Application] = @Application

    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM 
            [ELMAH_Error]
        WHERE   
            [Application] = @Application
        ORDER BY 
            [TimeUtc] DESC, 
            [Sequence] DESC

    END
    ELSE
    BEGIN

        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT 
        errorId     = [ErrorId], 
        application = [Application],
        host        = [Host], 
        type        = [Type],
        source      = [Source],
        message     = [Message],
        [user]      = [User],
        statusCode  = [StatusCode], 
        time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM 
        [ELMAH_Error] error
    WHERE
    --    [Application] = @Application
    --AND
        [TimeUtc] <= @FirstTimeUTC
    AND 
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC, 
        [Sequence] DESC
    FOR
        XML AUTO

GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT 
        [AllXml]
    FROM 
        [ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId
    --AND
    --    [Application] = @Application

GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NTEXT,
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )

GO
/****** Object:  StoredProcedure [dbo].[P_CreateEmployee]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[P_CreateEmployee]
								 @Title			[smallint], 								 
								 @FirstName		[varchar](255) ,
								 @LastName		[varchar](255) ,
								 @PersonalEmail	[varchar](500) ,
								 @DOB			[datetime] ,
								 @DOJ			[datetime] ,
								 @IsActive		[bit] , 
								 @Comments		[varchar](MAX) ,
                                 @CreatedByUserId    [BIGINT]
AS
    BEGIN
        DECLARE @TodaysDate DATETIME= GETDATE();
		DECLARE @EmployeeId [bigint] 
		DECLARE @EmployeeRequestId [bigint] 
        IF @CreatedByUserId = 0 OR @CreatedByUserId = NULL
            BEGIN
                SELECT @CreatedByUserId = 1;
        END;	

        BEGIN TRANSACTION;

       INSERT INTO [dbo].[Employees]
           ([Title]
           ,[FirstName]
           ,[LastName]
           ,[PersonalEmail]
           ,[DOB]
           ,[DOJ]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedByUserId]
           ,[ModifidOn]
           ,[ModifiedByUserId])
     VALUES
          (
				 @Title			
				,@FirstName		
				,@LastName		
				,@PersonalEmail
				,@DOB			
				,@DOJ			
				,0	
				,@TodaysDate	
				,@CreatedByUserId    
				,@TodaysDate	
				,@CreatedByUserId
				)  

      SELECT @EmployeeId = CAST( SCOPE_IDENTITY() AS BIGINT)

	  INSERT INTO [dbo].[EmployeeRequests]
           ([EmployeeId]
           ,[EmpAppOprStatusId]
           ,[EmpAppReqStatusId]
           ,[Title]
           ,[FirstName]
           ,[LastName]
           ,[PersonalEmail]
           ,[DOB]
           ,[DOJ]
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedByUserId]
           ,[ModifidOn]
           ,[ModifiedByUserId])

	  VALUES
          (
				@EmployeeId
				,10  -- CreateEmployee
				,100 -- Submitted
				,@Title			
				,@FirstName		
				,@LastName		
				,@PersonalEmail
				,@DOB			
				,@DOJ			
				,0	
				,@TodaysDate	
				,@CreatedByUserId    
				,@TodaysDate	
				,@CreatedByUserId
				) 

		 SELECT @EmployeeRequestId = CAST( SCOPE_IDENTITY() AS BIGINT)

	INSERT INTO [dbo].[EmployeesReqStatusHistory]
			([EmployeeId]
			,[EmployeeRequestId]
			,[EmpAppOprStatusId]
			,[EmpAppReqStatusId]
			,[Comments]
			,[CreatedOn]
			,[CreatedByUserId]
			,[ModifidOn]
			,[ModifiedByUserId])
	VALUES
          (
				@EmployeeId
				,@EmployeeRequestId
				,10  -- CreateEmployee
				,100 -- Submitted
				,@Comments					
				,@TodaysDate	
				,@CreatedByUserId    
				,@TodaysDate	
				,@CreatedByUserId
			) 
	  COMMIT TRANSACTION;
	  	
		
      SELECT  * FROM  [dbo].[Employees]  WHERE [EmployeeId] = @EmployeeId
    END;
GO
/****** Object:  StoredProcedure [dbo].[P_GetAllEmployeesPendingApprovals]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- EXEC [dbo].[P_GetAllEmployeesPendingApprovals]
CREATE PROC [dbo].[P_GetAllEmployeesPendingApprovals]
								
AS
    BEGIN
        SELECT   EmpReqs.[EmployeeRequestId]
			  ,EmpReqs.[EmployeeId]
			  ,EmpReqs.[EmpAppOprStatusId]
			    ,EmpOprStatus.EmpAppOprStatusDesc
			  ,EmpReqs.[EmpAppReqStatusId]
			    ,EmpReqStatus.EmpAppReqStatusDesc
			  ,EmpReqs.[Title]
			  ,EmpTitle.EmployeeTitleDesc
			  ,EmpReqs.[FirstName]
			  ,EmpReqs.[LastName]
			  ,EmpReqs.[PersonalEmail]
			  ,EmpReqs.[DOB]
			  ,EmpReqs.[DOJ]
			  ,EmpReqs.[IsActive]
			    ,EmpReqs.[CreatedOn]
			  ,EmpReqs.[CreatedByUserId]
			  ,USDCreatedBy.FirstName + ' ' + USDCreatedBy.LastName AS CreatedByFullName
			  ,EmpReqs.[ModifidOn]
			  ,EmpReqs.[ModifiedByUserId]		
			  ,USDModifiedBy.FirstName + ' ' + USDModifiedBy.LastName AS ModifiedByFullName
			  ,(SELECT TOP 1 EmpReqStatusHistory.Comments FROM 
				 EmployeesReqStatusHistory EmpReqStatusHistory
				  WHERE EmpReqStatusHistory.EmployeeRequestId = EmpReqs.EmployeeRequestId
				 	ORDER BY EmpReqStatusHistory.EmployeesReqStatusHistoryId ASC ) AS Comments
	   FROM [dbo].[EmployeeRequests] EmpReqs
	   INNER JOIN EmployeeTitle EmpTitle
	  ON EmpTitle.EmployeeTitleId = EmpReqs.Title
	    INNER JOIN EmpAppOprStatus EmpOprStatus
	   ON EmpOprStatus.EmpAppOprStatusId = EmpReqs.[EmpAppOprStatusId]
	   INNER JOIN EmpAppReqStatus EmpReqStatus
	   ON EmpReqStatus.EmpAppReqStatusId = EmpReqs.EmpAppReqStatusId
	   LEFT JOIN [dbo].[UserDetail] USDCreatedBy
	   ON USDCreatedBy.UserId = EmpReqs.CreatedByUserId
	   LEFT JOIN [dbo].[UserDetail] USDModifiedBy
	   ON USDModifiedBy.UserId = EmpReqs.[ModifiedByUserId]
	   WHERE EmpReqs.EmpAppReqStatusId = 100 --Submitted
	ORDER BY EmpReqs.[EmployeeId]
      
    END;

GO
/****** Object:  StoredProcedure [dbo].[P_GetCreateEmployeeReq]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- exec [dbo].[P_GetCreateEmployeeReq] 80006

CREATE PROC [dbo].[P_GetCreateEmployeeReq]
					@EmployeeRequestId [bigint] 	
								
AS
    BEGIN
			    SELECT   EmpReqs.[EmployeeRequestId]
			  ,EmpReqs.[EmployeeId]
			  ,EmpReqs.[EmpAppOprStatusId]
			    ,EmpOprStatus.EmpAppOprStatusDesc
			  ,EmpReqs.[EmpAppReqStatusId]
			    ,EmpReqStatus.EmpAppReqStatusDesc
			  ,EmpReqs.[Title]
			  ,EmpTitle.EmployeeTitleDesc
			  ,EmpReqs.[FirstName]
			  ,EmpReqs.[LastName]
			  ,EmpReqs.[PersonalEmail]
			  ,EmpReqs.[DOB]
			  ,EmpReqs.[DOJ]
			  ,EmpReqs.[IsActive]
			  ,EmpReqs.[CreatedOn]
			  ,EmpReqs.[CreatedByUserId]
			  ,USDCreatedBy.FirstName + ' ' + USDCreatedBy.LastName AS CreatedByFullName
			  ,EmpReqs.[ModifidOn]
			  ,EmpReqs.[ModifiedByUserId]		
			  ,USDModifiedBy.FirstName + ' ' + USDModifiedBy.LastName AS ModifiedByFullName
			  ,(SELECT TOP 1 EmpReqStatusHistory.Comments FROM 
				 EmployeesReqStatusHistory EmpReqStatusHistory
				  WHERE EmpReqStatusHistory.EmployeeRequestId = EmpReqs.EmployeeRequestId
				 	ORDER BY EmpReqStatusHistory.EmployeesReqStatusHistoryId ASC ) AS Comments
	   FROM [dbo].[EmployeeRequests] EmpReqs
	   INNER JOIN EmployeeTitle EmpTitle
	  ON EmpTitle.EmployeeTitleId = EmpReqs.Title
	    INNER JOIN EmpAppOprStatus EmpOprStatus
	   ON EmpOprStatus.EmpAppOprStatusId = EmpReqs.[EmpAppOprStatusId]
	   INNER JOIN EmpAppReqStatus EmpReqStatus
	   ON EmpReqStatus.EmpAppReqStatusId = EmpReqs.EmpAppReqStatusId
	   LEFT JOIN [dbo].[UserDetail] USDCreatedBy
	   ON USDCreatedBy.UserId = EmpReqs.CreatedByUserId
	   LEFT JOIN [dbo].[UserDetail] USDModifiedBy
	   ON USDModifiedBy.UserId = EmpReqs.[ModifiedByUserId]
	   WHERE EmpReqs.EmpAppReqStatusId = 100 --Submitted
	    AND EmpReqs.[EmployeeRequestId] = @EmployeeRequestId
	ORDER BY EmpReqs.[EmployeeId]
		 
      
    END;

GO
/****** Object:  StoredProcedure [dbo].[P_GetEmployeeReqStatusHistory]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--EXEC [dbo].[P_GetEmployeeReqStatusHistory] 0, 80005
CREATE PROC [dbo].[P_GetEmployeeReqStatusHistory]
					 @EmployeeId [bigint] 
					,@EmployeeRequestId [bigint] 						
AS
    BEGIN
     SELECT
		
		RANK () OVER ( 
		 ORDER BY EmpReqStatusHist.[EmployeesReqStatusHistoryId] DESC
		 ) Id 

		,EmpReqStatusHist.[EmployeesReqStatusHistoryId]
		,EmpReqStatusHist.[EmployeeId]
		,EmpReqStatusHist.[EmployeeRequestId]
		,EmpReqStatusHist.[EmpAppOprStatusId]
		,EmpOprStatus.EmpAppOprStatusDesc
		,EmpReqStatusHist.[EmpAppReqStatusId]
		,EmpReqStatus.EmpAppReqStatusDesc
		,EmpReqStatusHist.[Comments]
		,EmpReqStatusHist.[CreatedOn]
		,EmpReqStatusHist.[CreatedByUserId]
		 ,USDCreatedBy.FirstName + ' ' + USDCreatedBy.LastName AS CreatedByFullName
		,EmpReqStatusHist.[ModifidOn]
		,EmpReqStatusHist.[ModifiedByUserId]
		,USDModifiedBy.FirstName + ' ' + USDModifiedBy.LastName AS ModifiedByFullName
	FROM [dbo].[EmployeesReqStatusHistory] EmpReqStatusHist
	INNER JOIN EmpAppOprStatus EmpOprStatus
	ON EmpOprStatus.EmpAppOprStatusId = EmpReqStatusHist.[EmpAppOprStatusId]
	INNER JOIN EmpAppReqStatus EmpReqStatus
	ON EmpReqStatus.EmpAppReqStatusId = EmpReqStatusHist.EmpAppReqStatusId
	LEFT JOIN [dbo].[UserDetail] USDCreatedBy
	ON USDCreatedBy.UserId = EmpReqStatusHist.CreatedByUserId
	LEFT JOIN [dbo].[UserDetail] USDModifiedBy
	ON USDModifiedBy.UserId = EmpReqStatusHist.[ModifiedByUserId]
		WHERE EmpReqStatusHist.[EmployeeRequestId] = @EmployeeRequestId
    END;
GO
/****** Object:  StoredProcedure [dbo].[P_ProcessCreateEmployee]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[P_ProcessCreateEmployee]
CREATE PROC [dbo].[P_ProcessCreateEmployee]
					 @EmployeeId [bigint] 
					,@EmployeeRequestId [bigint] 	
					,@EmpAppReqStatusId SMALLINT
					 ,@Comments		[varchar](MAX) 
					 ,@CreatedByUserId    [BIGINT]	
AS
    BEGIN
        DECLARE @TodaysDate DATETIME= GETDATE();
	 
	  IF @EmpAppReqStatusId = 101  --Approved
	  BEGIN 
		
		BEGIN TRANSACTION;
	  
		INSERT INTO [dbo].[EmployeesReqStatusHistory]
				([EmployeeId]
				,[EmployeeRequestId]
				,[EmpAppOprStatusId]
				,[EmpAppReqStatusId]
				,[Comments]
				,[CreatedOn]
				,[CreatedByUserId]
				,[ModifidOn]
				,[ModifiedByUserId])
		VALUES
			  (
					@EmployeeId
					,@EmployeeRequestId
					,10  -- CreateEmployee
					, 101  --Approved
					,@Comments					
					,@TodaysDate	
					,@CreatedByUserId    
					,@TodaysDate	
					,@CreatedByUserId
				) 

		UPDATE [dbo].[EmployeeRequests]
			   SET [EmpAppReqStatusId] =  101  --Approved			  
				  ,[IsActive] = 1			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedByUserId] = @CreatedByUserId
			 WHERE [EmployeeRequestId] = @EmployeeRequestId

		UPDATE [dbo].Employees
			   SET [IsActive] = 1			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedByUserId] = @CreatedByUserId
			 WHERE EmployeeId = @EmployeeId

		  COMMIT TRANSACTION;
		END
		
	  IF @EmpAppReqStatusId = 102  --Rejected
			OR @EmpAppReqStatusId =  103	--OnHold
			OR @EmpAppReqStatusId =	 104		--RevertBacked
	  BEGIN 
		
		BEGIN TRANSACTION;
	  
		INSERT INTO [dbo].[EmployeesReqStatusHistory]
				([EmployeeId]
				,[EmployeeRequestId]
				,[EmpAppOprStatusId]
				,[EmpAppReqStatusId]
				,[Comments]
				,[CreatedOn]
				,[CreatedByUserId]
				,[ModifidOn]
				,[ModifiedByUserId])
		VALUES
			  (
					@EmployeeId
					,@EmployeeRequestId
					,10  -- CreateEmployee
					, @EmpAppReqStatusId
					,@Comments					
					,@TodaysDate	
					,@CreatedByUserId    
					,@TodaysDate	
					,@CreatedByUserId
				) 

		UPDATE [dbo].[EmployeeRequests]
			   SET [EmpAppReqStatusId] =  @EmpAppReqStatusId
				  ,[IsActive] = 0			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedByUserId] = @CreatedByUserId
			 WHERE [EmployeeRequestId] = @EmployeeRequestId

		UPDATE [dbo].Employees
			   SET [IsActive] = 0			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedByUserId] = @CreatedByUserId
			 WHERE EmployeeId = @EmployeeId

		  COMMIT TRANSACTION;
		END     
      SELECT CAST (1 AS BIT)
    END;
GO
/****** Object:  StoredProcedure [dbo].[P_RegisterUser]    Script Date: 10/22/2019 12:06:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[P_RegisterUser]
								  @UserName     [NVARCHAR](MAX), 
								  @FirstName     [NVARCHAR](MAX), 
								  @LastName     [NVARCHAR](MAX),                                 
								  @Password     [NVARCHAR](MAX),
                                  @Email        [NVARCHAR](MAX),   
								  @UserType     [INT],                             
                                  @CreatedByUserId    [BIGINT]
AS
    BEGIN
        DECLARE @TodaysDate DATETIME= GETDATE();

        IF @CreatedByUserId = 0 OR @CreatedByUserId = NULL
            BEGIN
                SELECT @CreatedByUserId = 1;
        END;

        BEGIN TRANSACTION;

        INSERT INTO [dbo].[UserDetail]
           ([UserName]
		   ,[FirstName]
		   ,[LastName]
           ,[Email]
           ,[Password]
           ,[IsActive]
           ,[UserType]
           ,[CreatedOn]
           ,[CreatedByUserId]
           ,[ModifidOn]
           ,[ModifiedByUserId])
     VALUES
			(			     
				 @UserName  
				 , @FirstName
				  ,@LastName 
				 ,@Email     
				 ,@Password 
				 ,1 
				, @UserType  
				 ,@TodaysDate
				, @CreatedByUserId 
				 ,@TodaysDate
				, @CreatedByUserId 
			)

        DECLARE @UserIdCreated BIGINT= SCOPE_IDENTITY()

	  COMMIT TRANSACTION;
	  	
		  BEGIN TRANSACTION;
		UPDATE [dbo].[UserDetail]
	 SET 
			  [CreatedByUserId] = @UserIdCreated
			  
			  ,[ModifiedByUserId] = @UserIdCreated
		 WHERE UserId = @UserIdCreated

		  COMMIT TRANSACTION;
      SELECT  * FROM  [dbo].[UserDetail]  WHERE UserId = @UserIdCreated
    END;
GO
