IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employees] (
    [EmployeeID] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Salary] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeID])
);
GO

CREATE TABLE [Projects] (
    [ProjectId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [DateOfCompletion] datetime2 NOT NULL,
    [DateOfEnd] datetime2 NOT NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([ProjectId])
);
GO

CREATE TABLE [Assignments] (
    [AssigmentId] int NOT NULL IDENTITY,
    [Role] nvarchar(max) NOT NULL,
    [ProjectId] int NOT NULL,
    [EmployeeID] int NOT NULL,
    CONSTRAINT [PK_Assignments] PRIMARY KEY ([AssigmentId]),
    CONSTRAINT [FK_Assignments_Employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees] ([EmployeeID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Assignments_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Assignments_EmployeeID] ON [Assignments] ([EmployeeID]);
GO

CREATE INDEX [IX_Assignments_ProjectId] ON [Assignments] ([ProjectId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220217192015_first', N'6.0.2');
GO

COMMIT;
GO

