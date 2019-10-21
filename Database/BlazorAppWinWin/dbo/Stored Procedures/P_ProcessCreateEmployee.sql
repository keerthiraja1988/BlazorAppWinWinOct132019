
--EXEC [dbo].[P_ProcessCreateEmployee]
CREATE PROC [dbo].[P_ProcessCreateEmployee]
					 @EmployeeId [bigint] 
					,@EmployeeRequestId [bigint] 	
					,@EmpAppReqStatusId SMALLINT
					 ,@Comments		[varchar](MAX) 
					 ,@CreatedBy    [BIGINT]	
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
				,[CreatedBy]
				,[ModifidOn]
				,[ModifiedBy])
		VALUES
			  (
					@EmployeeId
					,@EmployeeRequestId
					,10  -- CreateEmployee
					, 101  --Approved
					,@Comments					
					,@TodaysDate	
					,@CreatedBy    
					,@TodaysDate	
					,@CreatedBy
				) 

		UPDATE [dbo].[EmployeeRequests]
			   SET [EmpAppReqStatusId] =  101  --Approved			  
				  ,[IsActive] = 1			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedBy] = @CreatedBy
			 WHERE [EmployeeRequestId] = @EmployeeRequestId

		UPDATE [dbo].Employees
			   SET [IsActive] = 1			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedBy] = @CreatedBy
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
				,[CreatedBy]
				,[ModifidOn]
				,[ModifiedBy])
		VALUES
			  (
					@EmployeeId
					,@EmployeeRequestId
					,10  -- CreateEmployee
					, @EmpAppReqStatusId
					,@Comments					
					,@TodaysDate	
					,@CreatedBy    
					,@TodaysDate	
					,@CreatedBy
				) 

		UPDATE [dbo].[EmployeeRequests]
			   SET [EmpAppReqStatusId] =  @EmpAppReqStatusId
				  ,[IsActive] = 0			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedBy] = @CreatedBy
			 WHERE [EmployeeRequestId] = @EmployeeRequestId

		UPDATE [dbo].Employees
			   SET [IsActive] = 0			 
				  ,[ModifidOn] = @TodaysDate
				  ,[ModifiedBy] = @CreatedBy
			 WHERE EmployeeId = @EmployeeId

		  COMMIT TRANSACTION;
		END     
      SELECT CAST (1 AS BIT)
    END;