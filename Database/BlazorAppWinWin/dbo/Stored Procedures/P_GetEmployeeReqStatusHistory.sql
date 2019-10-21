

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