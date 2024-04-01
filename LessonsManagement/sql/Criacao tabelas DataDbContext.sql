IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Student] (
    [Id] uniqueidentifier NOT NULL,
    [StudentName] varchar(50) NOT NULL,
    [Notes] varchar(500) NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Lesson] (
    [Id] uniqueidentifier NOT NULL,
    [StudentId] uniqueidentifier NOT NULL,
    [ExecutionDate] datetime NOT NULL,
    [Price] decimal NOT NULL,
    CONSTRAINT [PK_Lesson] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Lesson_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Student] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Lesson_StudentId] ON [Lesson] ([StudentId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206230510_Initial', N'2.2.4-servicing-10062');

GO

