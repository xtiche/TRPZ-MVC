CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)
CREATE TABLE [dbo].[Specialization]
(
	[IdSpec] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL
)
CREATE TABLE [dbo].[Position]
(
	[IdPosition] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdEmployee] INT NOT NULL, 
    [IdSpec] INT NOT NULL, 
    CONSTRAINT [FK_Position_Employee] FOREIGN KEY ([IdEmployee]) REFERENCES [Employee]([IdEmployee]) ON DELETE CASCADE, 
    CONSTRAINT [FK_Position_Spec] FOREIGN KEY ([IdSpec]) REFERENCES [Specialization]([IdSpec]) ON DELETE CASCADE
)