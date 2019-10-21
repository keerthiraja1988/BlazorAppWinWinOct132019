USE [BlazorAppWinWin]
GO
/****** Object:  StoredProcedure [dbo].[P_RegisterUser]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_RegisterUser]
GO
/****** Object:  StoredProcedure [dbo].[P_GetAllEmployeesPendingApprovals]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_GetAllEmployeesPendingApprovals]
GO
/****** Object:  StoredProcedure [dbo].[P_CreateEmployee]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_CreateEmployee]
GO
/****** Object:  StoredProcedure [dbo].[P_CreateClaimA]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[P_CreateClaimA]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[ELMAH_LogError]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[ELMAH_GetErrorXml]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP PROCEDURE IF EXISTS [dbo].[ELMAH_GetErrorsXml]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELMAH_Error]') AND type in (N'U'))
ALTER TABLE [dbo].[ELMAH_Error] DROP CONSTRAINT IF EXISTS [DF_ELMAH_Error_ErrorId]
GO
/****** Object:  Index [IX_ELMAH_Error_App_Time_Seq]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP INDEX IF EXISTS [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[UserDetail]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[Products]
GO
/****** Object:  Table [dbo].[EmployeeTitle]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[EmployeeTitle]
GO
/****** Object:  Table [dbo].[EmployeesReqStatusHistory]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[EmployeesReqStatusHistory]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[Employees]
GO
/****** Object:  Table [dbo].[EmployeeRequests]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[EmployeeRequests]
GO
/****** Object:  Table [dbo].[EmpAppReqStatus]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[EmpAppReqStatus]
GO
/****** Object:  Table [dbo].[EmpAppOprStatus]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[EmpAppOprStatus]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[ELMAH_Error]
GO
/****** Object:  Table [dbo].[ClaimItem]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[ClaimItem]
GO
/****** Object:  Table [dbo].[Claim]    Script Date: 10/21/2019 10:43:44 AM ******/
DROP TABLE IF EXISTS [dbo].[Claim]
GO
/****** Object:  Table [dbo].[Claim]    Script Date: 10/21/2019 10:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claim](
	[ClaimId] [bigint] IDENTITY(400000,1) NOT NULL,
	[ClaimType] [int] NULL,
	[TotalItems] [int] NULL,
	[TotalCost] [decimal](19, 2) NULL,
	[Status] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimItem]    Script Date: 10/21/2019 10:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaimItem](
	[ClaimItemsId] [bigint] IDENTITY(50000,1) NOT NULL,
	[ClaimId] [bigint] NULL,
	[InvoiceNumber] [varchar](500) NULL,
	[ProductId] [bigint] NULL,
	[ReasonId] [int] NULL,
	[ProductCost] [decimal](19, 2) NULL,
	[Quantity] [int] NULL,
	[ProductTotalCost] [decimal](19, 2) NULL,
	[Comments] [varchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClaimItemsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 10/21/2019 10:43:44 AM ******/
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
/****** Object:  Table [dbo].[EmpAppOprStatus]    Script Date: 10/21/2019 10:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpAppOprStatus](
	[EmpAppOprStatusId] [smallint] IDENTITY(10,1) NOT NULL,
	[EmpAppOprStatusDesc] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpAppReqStatus]    Script Date: 10/21/2019 10:43:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpAppReqStatus](
	[EmpAppReqStatusId] [smallint] IDENTITY(100,1) NOT NULL,
	[EmpAppReqStatusDesc] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRequests]    Script Date: 10/21/2019 10:43:44 AM ******/
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
	[CreatedBy] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/21/2019 10:43:44 AM ******/
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
	[CreatedBy] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesReqStatusHistory]    Script Date: 10/21/2019 10:43:45 AM ******/
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
	[CreatedBy] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeTitle]    Script Date: 10/21/2019 10:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeTitle](
	[EmployeeTitleId] [smallint] IDENTITY(50,1) NOT NULL,
	[EmployeeTitleDesc] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/21/2019 10:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [bigint] IDENTITY(30000,1) NOT NULL,
	[ProductName] [varchar](max) NULL,
	[ManufacturerName] [varchar](max) NULL,
	[Cost] [decimal](19, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 10/21/2019 10:43:45 AM ******/
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
	[CreatedBy] [bigint] NULL,
	[ModifidOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ELMAH_Error_App_Time_Seq]    Script Date: 10/21/2019 10:43:45 AM ******/
CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error]
(
	[Application] ASC,
	[TimeUtc] DESC,
	[Sequence] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 10/21/2019 10:43:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 10/21/2019 10:43:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 10/21/2019 10:43:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_CreateClaimA]    Script Date: 10/21/2019 10:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[P_CreateClaimA]
								  @ClaimId  [BIGINT],	
								  @ClaimType int
								  		
								   ,@InvoiceNumber varchar(500)
								   ,@ProductId bigint
								   ,@ReasonId int 
								   ,@ProductCost decimal(19,2)
								   ,@Quantity int
								   ,@ProductTotalCost decimal(19,2)
								   ,@Comments	varchar(max)			                      
                                   ,@CreatedBy    [BIGINT]
AS
    BEGIN
        DECLARE @TodaysDate DATETIME= GETDATE();

        

     BEGIN TRANSACTION;

	IF @ClaimId = 0
	BEGIN
	INSERT INTO [dbo].[Claim]
           ([ClaimType]
           ,[TotalItems]
           ,[TotalCost]
           ,[Status]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ModifidOn]
           ,[ModifiedBy])
		 SELECT  @ClaimType
			,0
			,0.00
			,1
			,@TodaysDate
			,@CreatedBy
			,@TodaysDate
			,@CreatedBy
	 SET @ClaimId = CAST(SCOPE_IDENTITY()  AS bigint)
	END

	INSERT INTO [dbo].[ClaimItem]
           ([ClaimId]
           ,[InvoiceNumber]
           ,[ProductId]
           ,[ReasonId]
           ,[ProductCost]
           ,[Quantity]
           ,[ProductTotalCost]
           ,[Comments]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ModifidOn]
		   ,[ModifiedBy]
		   )
	 SELECT
			@ClaimId
		 ,@InvoiceNumber 
		,@ProductId 
		,@ReasonId  
		,@ProductCost 
		,@Quantity 
		,@ProductTotalCost 
		,@Comments			                      
       ,@TodaysDate
		,@CreatedBy
		,@TodaysDate
		,@CreatedBy
		

	

	 COMMIT TRANSACTION;
      SELECT  @ClaimId
    END;
GO
/****** Object:  StoredProcedure [dbo].[P_CreateEmployee]    Script Date: 10/21/2019 10:43:45 AM ******/
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
                                 @CreatedBy    [BIGINT]
AS
    BEGIN
        DECLARE @TodaysDate DATETIME= GETDATE();
		DECLARE @EmployeeId [bigint] 
		DECLARE @EmployeeRequestId [bigint] 
        IF @CreatedBy = 0 OR @CreatedBy = NULL
            BEGIN
                SELECT @CreatedBy = 1;
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
           ,[CreatedBy]
           ,[ModifidOn]
           ,[ModifiedBy])
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
				,@CreatedBy    
				,@TodaysDate	
				,@CreatedBy
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
           ,[CreatedBy]
           ,[ModifidOn]
           ,[ModifiedBy])

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
				,@CreatedBy    
				,@TodaysDate	
				,@CreatedBy
				) 

		 SELECT @EmployeeRequestId = CAST( SCOPE_IDENTITY() AS BIGINT)

	INSERT INTO [dbo].[EmployeesReqStatusHistory]
			([EmployeeId]
			,[EmployeeRequestId]
			,[EmpAppOprStatusId]
			,[EmpAppReqStatusId]
			,[Comments]
			,[CreatedOn]
			,[CreatedBy]
			,[ModifidOn]
			,[ModifiedBy])
	VALUES
          (
				@EmployeeId
				,@EmployeeRequestId
				,10  -- CreateEmployee
				,100 -- Submitted
				,@Comments					
				,@TodaysDate	
				,@CreatedBy    
				,@TodaysDate	
				,@CreatedBy
			) 
	  COMMIT TRANSACTION;
	  	
		
      SELECT  * FROM  [dbo].[Employees]  WHERE [EmployeeId] = @EmployeeId
    END;
GO
/****** Object:  StoredProcedure [dbo].[P_GetAllEmployeesPendingApprovals]    Script Date: 10/21/2019 10:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



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
			  ,EmpReqs.[CreatedBy]
			  ,USDCreatedBy.FirstName + ' ' + USDCreatedBy.LastName AS CreatedByName
			  ,EmpReqs.[ModifidOn]
			  ,EmpReqs.[ModifiedBy]		
			  ,USDModifiedBy.FirstName + ' ' + USDModifiedBy.LastName AS ModifiedByName
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
	   ON USDCreatedBy.UserId = EmpReqs.CreatedBy
	   LEFT JOIN [dbo].[UserDetail] USDModifiedBy
	   ON USDModifiedBy.UserId = EmpReqs.[ModifiedBy]
	   WHERE EmpReqs.EmpAppReqStatusId = 100 --Submitted
	ORDER BY EmpReqs.[EmployeeId]
      
    END;

GO
/****** Object:  StoredProcedure [dbo].[P_RegisterUser]    Script Date: 10/21/2019 10:43:45 AM ******/
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
                                  @CreatedBy    [BIGINT]
AS
    BEGIN
        DECLARE @TodaysDate DATETIME= GETDATE();

        IF @CreatedBy = 0 OR @CreatedBy = NULL
            BEGIN
                SELECT @CreatedBy = 1;
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
           ,[CreatedBy]
           ,[ModifidOn]
           ,[ModifiedBy])
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
				, @CreatedBy 
				 ,@TodaysDate
				, @CreatedBy 
			)

        DECLARE @UserIdCreated BIGINT= SCOPE_IDENTITY()

	  COMMIT TRANSACTION;
	  	
		  BEGIN TRANSACTION;
		UPDATE [dbo].[UserDetail]
	 SET 
			  [CreatedBy] = @UserIdCreated
			  
			  ,[ModifiedBy] = @UserIdCreated
		 WHERE UserId = @UserIdCreated

		  COMMIT TRANSACTION;
      SELECT  * FROM  [dbo].[UserDetail]  WHERE UserId = @UserIdCreated
    END;
GO
