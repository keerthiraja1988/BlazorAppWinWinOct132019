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
INSERT [dbo].[EmployeeRequests] ([EmployeeRequestId], [EmployeeId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (80003, 300011, 10, 100, 50, N'66666', N'5555', N'6666@1231.20', CAST(N'2019-10-09T00:00:00.000' AS DateTime), CAST(N'2019-10-17T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-20T22:39:41.687' AS DateTime), 10004, CAST(N'2019-10-20T22:39:41.687' AS DateTime), 10004)
GO
INSERT [dbo].[EmployeeRequests] ([EmployeeRequestId], [EmployeeId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (80004, 300012, 10, 100, 52, N'8888', N'5555', N'6666@1231.20', CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-10T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-20T22:41:20.470' AS DateTime), 10004, CAST(N'2019-10-20T22:41:20.470' AS DateTime), 10004)
GO
INSERT [dbo].[EmployeeRequests] ([EmployeeRequestId], [EmployeeId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (80005, 300013, 10, 100, 50, N'66666', N'5555', N'6666@1231.20', CAST(N'2019-10-03T00:00:00.000' AS DateTime), CAST(N'2019-10-08T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-20T23:12:50.130' AS DateTime), 10004, CAST(N'2019-10-20T23:12:50.130' AS DateTime), 10004)
GO
INSERT [dbo].[EmployeeRequests] ([EmployeeRequestId], [EmployeeId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (80006, 300014, 10, 100, 52, N'1234', N'4561', N'456@gg.com', CAST(N'2019-10-09T00:00:00.000' AS DateTime), CAST(N'2019-10-07T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-21T10:40:10.460' AS DateTime), 10004, CAST(N'2019-10-21T10:40:10.460' AS DateTime), 10004)
GO
SET IDENTITY_INSERT [dbo].[EmployeeRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([EmployeeId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (300011, 50, N'66666', N'5555', N'6666@1231.20', CAST(N'2019-10-09T00:00:00.000' AS DateTime), CAST(N'2019-10-17T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-20T22:39:41.687' AS DateTime), 10004, CAST(N'2019-10-20T22:39:41.687' AS DateTime), 10004)
GO
INSERT [dbo].[Employees] ([EmployeeId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (300012, 52, N'8888', N'5555', N'6666@1231.20', CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-10T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-20T22:41:20.470' AS DateTime), 10004, CAST(N'2019-10-20T22:41:20.470' AS DateTime), 10004)
GO
INSERT [dbo].[Employees] ([EmployeeId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (300013, 50, N'66666', N'5555', N'6666@1231.20', CAST(N'2019-10-03T00:00:00.000' AS DateTime), CAST(N'2019-10-08T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-20T23:12:50.130' AS DateTime), 10004, CAST(N'2019-10-20T23:12:50.130' AS DateTime), 10004)
GO
INSERT [dbo].[Employees] ([EmployeeId], [Title], [FirstName], [LastName], [PersonalEmail], [DOB], [DOJ], [IsActive], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (300014, 52, N'1234', N'4561', N'456@gg.com', CAST(N'2019-10-09T00:00:00.000' AS DateTime), CAST(N'2019-10-07T00:00:00.000' AS DateTime), 0, CAST(N'2019-10-21T10:40:10.460' AS DateTime), 10004, CAST(N'2019-10-21T10:40:10.460' AS DateTime), 10004)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeesReqStatusHistory] ON 
GO
INSERT [dbo].[EmployeesReqStatusHistory] ([EmployeesReqStatusHistoryId], [EmployeeId], [EmployeeRequestId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Comments], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10, 300011, 80003, 10, 100, N'WEWEF
FWEFEWF', CAST(N'2019-10-20T22:39:41.687' AS DateTime), 10004, CAST(N'2019-10-20T22:39:41.687' AS DateTime), 10004)
GO
INSERT [dbo].[EmployeesReqStatusHistory] ([EmployeesReqStatusHistoryId], [EmployeeId], [EmployeeRequestId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Comments], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (11, 300012, 80004, 10, 100, N'RTH', CAST(N'2019-10-20T22:41:20.470' AS DateTime), 10004, CAST(N'2019-10-20T22:41:20.470' AS DateTime), 10004)
GO
INSERT [dbo].[EmployeesReqStatusHistory] ([EmployeesReqStatusHistoryId], [EmployeeId], [EmployeeRequestId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Comments], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (12, 300013, 80005, 10, 100, N'wdswd', CAST(N'2019-10-20T23:12:50.130' AS DateTime), 10004, CAST(N'2019-10-20T23:12:50.130' AS DateTime), 10004)
GO
INSERT [dbo].[EmployeesReqStatusHistory] ([EmployeesReqStatusHistoryId], [EmployeeId], [EmployeeRequestId], [EmpAppOprStatusId], [EmpAppReqStatusId], [Comments], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (13, 300014, 80006, 10, 100, N'123', CAST(N'2019-10-21T10:40:10.460' AS DateTime), 10004, CAST(N'2019-10-21T10:40:10.460' AS DateTime), 10004)
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
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ManufacturerName], [Cost]) VALUES (30000, N'Amazon Brand - Solimo Smart LED Light, 9W, B22 Holder, Alexa Enabled', N'Amazon', CAST(50.00 AS Decimal(19, 2)))
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ManufacturerName], [Cost]) VALUES (30001, N'Crompton Lyor Round Base B22 10-Watt LED Bulb (Cool Day Light)', N'Crompton ', CAST(46.00 AS Decimal(19, 2)))
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ManufacturerName], [Cost]) VALUES (30002, N'Crompton LDRR24-CDL Radiance Ray Plus LED Batten for Home 2400 Lumens (Cool Day Light, 24 W)', N'Crompton ', CAST(89.00 AS Decimal(19, 2)))
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDetail] ON 
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10000, N'johnwill', N'john', N'will', N'john@123.com', N'123', 1, 0, CAST(N'2019-10-19T23:33:09.383' AS DateTime), 10000, CAST(N'2019-10-19T23:33:09.383' AS DateTime), 10000)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10001, N'johnwill1', N'johnwill1', N'johnwill1', N'johnwill1!@123.com', N'johnwill1', 1, 0, CAST(N'2019-10-19T23:38:26.507' AS DateTime), 10001, CAST(N'2019-10-19T23:38:26.507' AS DateTime), 10001)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10002, N'johnwill2', N'johnwill2', N'johnwill2', N'johnwill2@dfdf.vm', N'johnwill2', 1, 0, CAST(N'2019-10-19T23:39:00.513' AS DateTime), 10002, CAST(N'2019-10-19T23:39:00.513' AS DateTime), 10002)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10003, N'johnwill3', N'johnwill3', N'johnwill3', N'johnwill3@123.com', N'johnwill3', 1, 0, CAST(N'2019-10-19T23:42:21.447' AS DateTime), 10003, CAST(N'2019-10-19T23:42:21.447' AS DateTime), 10003)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10004, N'KEERTHIRAJA1988', N'KEERTHI', N'RAJA', N'KEE@GMAIL.COM', N'123', 1, 0, CAST(N'2019-10-20T00:27:12.523' AS DateTime), 10004, CAST(N'2019-10-20T00:27:12.523' AS DateTime), 10004)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10005, N'KEERTHIRAJA1987', N'KEERTHIRAJA1987', N'KEERTHIRAJA1987', N'KEERTHIRAJA1987@ggg.ccc', N'123', 1, 0, CAST(N'2019-10-20T00:42:56.207' AS DateTime), 10005, CAST(N'2019-10-20T00:42:56.207' AS DateTime), 10005)
GO
INSERT [dbo].[UserDetail] ([UserId], [UserName], [FirstName], [LastName], [Email], [Password], [IsActive], [UserType], [CreatedOn], [CreatedBy], [ModifidOn], [ModifiedBy]) VALUES (10006, N'KEERTHIRAJA123', N'raja', N'keerthi', N'kkk@gmail.com', N'123', 1, 0, CAST(N'2019-10-21T10:39:38.810' AS DateTime), 10006, CAST(N'2019-10-21T10:39:38.810' AS DateTime), 10006)
GO
SET IDENTITY_INSERT [dbo].[UserDetail] OFF
GO
