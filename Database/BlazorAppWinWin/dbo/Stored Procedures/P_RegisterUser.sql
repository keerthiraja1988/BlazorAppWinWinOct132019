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