CREATE TABLE [dbo].[Lecture]
(
	[Id] INT NOT NULL,
    [startTime] TIME NOT NULL,
    [endTime] TIME NULL,
    [location] VARCHAR(50) NULL,
    [course] VARCHAR(50) NOT NULL,
    [date] DATE NOT NULL,
    [buildingId] INT NOT NULL,
	PRIMARY KEY Clustered ([Id] ASC),
	CONSTRAINT [FK_Lecture_Building] FOREIGN KEY ([buildingId]) REFERENCES [Building]([Id])
)

﻿INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (1, '08:30:00', '10:00:00', 'B202', 'Wiskunde', '20200418', 1)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (2, '08:30:00', '10:00:00', 'F202', 'Wiskunde', '20200518', 4)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (3, '08:30:00', '12:00:00', 'B202', 'Wiskunde', '20200325', 1)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (4, '10:30:00', '14:00:00', 'G202', 'Wiskunde', '20200330', 2)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (5, '08:30:00', '10:00:00', 'B202', 'Wiskunde', '20200403', 1)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (6, '11:30:00', '16:00:00', 'P202', 'Wiskunde', '20200409', 3)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (7, '15:30:00', '20:00:00', 'B202', 'Wiskunde', '20200418', 1)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (8, '08:30:00', '10:00:00', 'P202', 'Wiskunde', '20200518', 3)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (9, '13:30:00', '17:00:00', 'B202', 'Wiskunde', '20200618', 1)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (10, '08:30:00', '10:00:00', 'G202', 'Wiskunde', '20201018', 2)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (11, '14:30:00', '16:00:00', 'B202', 'Wiskunde', '20200325', 1)
INSERT INTO [dbo].[Lecture] ([Id], [startTime], [endTime], [location], [course], [date], [buildingId]) VALUES (12, '08:30:00', '10:00:00', 'B202', 'Wiskunde', '20200327', 1)
