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

CREATE TABLE [Class] (
    [classid] int NOT NULL IDENTITY,
    [c_name] nvarchar(50) NULL,
    [c_color] nvarchar(50) NULL,
    [c_icon] nvarchar(50) NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY ([classid])
);
GO

CREATE TABLE [Spec] (
    [specid] int NOT NULL IDENTITY,
    [s_name] nvarchar(50) NULL,
    [s_icon] nvarchar(50) NULL,
    [ClassModelId] int NULL,
    CONSTRAINT [PK_Spec] PRIMARY KEY ([specid]),
    CONSTRAINT [FK_Spec_Class_ClassModelId] FOREIGN KEY ([ClassModelId]) REFERENCES [Class] ([classid]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Spec_ClassModelId] ON [Spec] ([ClassModelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210508130601_Initial', N'6.0.0-preview.1.21102.2');
GO

COMMIT;
GO

