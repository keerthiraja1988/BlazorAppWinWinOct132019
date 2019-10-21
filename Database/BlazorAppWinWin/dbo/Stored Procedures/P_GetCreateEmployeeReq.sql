
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
			  ,EmpReqs.[CreatedBy]
			  ,USDCreatedBy.FirstName + ' ' + USDCreatedBy.LastName AS CreatedByFullName
			  ,EmpReqs.[ModifidOn]
			  ,EmpReqs.[ModifiedBy]		
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
	   ON USDCreatedBy.UserId = EmpReqs.CreatedBy
	   LEFT JOIN [dbo].[UserDetail] USDModifiedBy
	   ON USDModifiedBy.UserId = EmpReqs.[ModifiedBy]
	   WHERE EmpReqs.EmpAppReqStatusId = 100 --Submitted
	    AND EmpReqs.[EmployeeRequestId] = @EmployeeRequestId
	ORDER BY EmpReqs.[EmployeeId]
		 
      
    END;