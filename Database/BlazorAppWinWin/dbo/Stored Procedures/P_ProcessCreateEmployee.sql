
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