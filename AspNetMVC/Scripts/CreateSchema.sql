IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Hash] nvarchar(max) NOT NULL,
    [DateHired] datetime2 NOT NULL,
    [SupervisorId] int NULL,
    [IsAdmin] bit NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_Employees_SupervisorId] FOREIGN KEY ([SupervisorId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Employees_SupervisorId] ON [Employees] ([SupervisorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200721160809_InitialSchema', N'3.1.5');

GO

