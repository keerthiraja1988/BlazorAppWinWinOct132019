
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
