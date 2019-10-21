
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
