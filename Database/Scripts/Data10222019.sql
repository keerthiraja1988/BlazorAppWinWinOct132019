USE [BlazorAppWinWin]
GO
SET IDENTITY_INSERT [dbo].[EmpAppOprStatus] ON 
GO
INSERT [dbo].[EmpAppOprStatus] ([EmpAppOprStatusId], [EmpAppOprStatusDesc]) VALUES (10, N'CreateEmployee')
GO
INSERT [dbo].[EmpAppOprStatus] ([EmpAppOprStatusId], [EmpAppOprStatusDesc]) VALUES (11, N'UpdateEmployee')
GO
INSERT [dbo].[EmpAppOprStatus] ([EmpAppOprStatusId], [EmpAppOprStatusDesc]) VALUES (12, N'DeleteEmployee')
GO
SET IDENTITY_INSERT [dbo].[EmpAppOprStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[EmpAppReqStatus] ON 
GO
INSERT [dbo].[EmpAppReqStatus] ([EmpAppReqStatusId], [EmpAppReqStatusDesc]) VALUES (100, N'Submitted')
GO
INSERT [dbo].[EmpAppReqStatus] ([EmpAppReqStatusId], [EmpAppReqStatusDesc]) VALUES (101, N'Approved')
GO
INSERT [dbo].[EmpAppReqStatus] ([EmpAppReqStatusId], [EmpAppReqStatusDesc]) VALUES (102, N'Rejected')
GO
INSERT [dbo].[EmpAppReqStatus] ([EmpAppReqStatusId], [EmpAppReqStatusDesc]) VALUES (103, N'OnHold')
GO
INSERT [dbo].[EmpAppReqStatus] ([EmpAppReqStatusId], [EmpAppReqStatusDesc]) VALUES (104, N'RevertBacked')
GO
SET IDENTITY_INSERT [dbo].[EmpAppReqStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeRequests] ON 
GO
INSERT [dbo].[EmployeeRequests] ([EmployeeRequestId], [EmployeeId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedByUserId], [ModifidOn], [ModifiedByUserId]) VALUES (80000, 300000, 10, 103, 51, N'66666', N'5555', N'6666@1231.20', CAST(N'2019-10-01T00:00:00.000' AS DateTime), CAST(N'2019-10-08T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-22T00:01:13.697' AS DateTime), 10000, CAST(N'2019-10-22T00:05:29.627' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[EmployeeRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([EmployeeId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedByUserId], [ModifidOn], [ModifiedByUserId]) VALUES (300000, 51, N'66666', N'5555', N'6666@1231.20', CAST(N'2019-10-01T00:00:00.000' AS DateTime), CAST(N'2019-10-08T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-22T00:01:13.697' AS DateTime), 10000, CAST(N'2019-10-22T00:05:29.627' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeesReqStatusHistory] ON 
GO
INSERT [dbo].[EmployeesReqStatusHistory] ([EmployeesReqStatusHistoryId], [EmployeeId], [EmployeeRequestId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Comments], [CreatedOn], [CreatedByUserId], [ModifidOn], [ModifiedByUserId]) VALUES (2, 300000, 80000, 10, 103, N'oN hOLD', CAST(N'2019-10-22T00:05:29.627' AS DateTime), NULL, CAST(N'2019-10-22T00:05:29.627' AS DateTime), NULL)
GO
INSERT [dbo].[EmployeesReqStatusHistory] ([EmployeesReqStatusHistoryId], [EmployeeId], [EmployeeRequestId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Comments], [CreatedOn], [CreatedByUserId], [ModifidOn], [ModifiedByUserId]) VALUES (1, 300000, 80000, 10, 100, N'sadgsdgsd', CAST(N'2019-10-22T00:01:13.697' AS DateTime), 10000, CAST(N'2019-10-22T00:01:13.697' AS DateTime), 10000)
GO
SET IDENTITY_INSERT [dbo].[EmployeesReqStatusHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeTitle] ON 
GO
INSERT [dbo].[EmployeeTitle] ([EmployeeTitleId], [EmployeeTitleDesc]) VALUES (50, N'Mr.')
GO
INSERT [dbo].[EmployeeTitle] ([EmployeeTitleId], [EmployeeTitleDesc]) VALUES (51, N'Mrs.')
GO
INSERT [dbo].[EmployeeTitle] ([EmployeeTitleId], [EmployeeTitleDesc]) VALUES (52, N'Miss')
GO
INSERT [dbo].[EmployeeTitle] ([EmployeeTitleId], [EmployeeTitleDesc]) VALUES (53, N'Ms.')
GO
SET IDENTITY_INSERT [dbo].[EmployeeTitle] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetail] ON 
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedByUserId], [ModifidOn], [ModifiedByUserId]) VALUES (10000, N'KEERTHIRAJA1988', N'KEERTHI', N'RAJA', N'keerthi@gmail.com', N'123', 1, 0, CAST(N'2019-10-22T00:00:46.070' AS DateTime), 10000, CAST(N'2019-10-22T00:00:46.070' AS DateTime), 10000)
GO
SET IDENTITY_INSERT [dbo].[UserDetail] OFF
GO
