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