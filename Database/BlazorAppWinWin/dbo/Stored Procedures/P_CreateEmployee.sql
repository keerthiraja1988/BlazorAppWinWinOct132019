
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
