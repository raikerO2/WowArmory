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
    [id] int NOT NULL,
    [c_name] nvarchar(500) NULL,
    [c_color] nvarchar(500) NULL,
    [c_icon] nvarchar(500) NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY ([classid])
);
GO

CREATE TABLE [Profession] (
    [professionid] int NOT NULL IDENTITY,
    [id] int NOT NULL,
    [p_name] nvarchar(500) NULL,
    [i_icon] nvarchar(50) NULL,
    CONSTRAINT [PK_Profession] PRIMARY KEY ([professionid])
);
GO

CREATE TABLE [Source] (
    [sourceid] int NOT NULL IDENTITY,
    [s_category] nvarchar(500) NULL,
    [s_name] nvarchar(500) NULL,
    [s_faction] nvarchar(500) NULL,
    [s_cost] int NOT NULL,
    CONSTRAINT [PK_Source] PRIMARY KEY ([sourceid])
);
GO

CREATE TABLE [Talent] (
    [talentid] int NOT NULL IDENTITY,
    [id] int NOT NULL,
    [t_name] nvarchar(500) NULL,
    CONSTRAINT [PK_Talent] PRIMARY KEY ([talentid])
);
GO

CREATE TABLE [Zone] (
    [zoneid] int NOT NULL IDENTITY,
    [id] int NOT NULL,
    [z_name] nvarchar(500) NULL,
    [z_category] nvarchar(500) NULL,
    [z_territory] nvarchar(500) NULL,
    [z_level] varbinary(max) NULL,
    CONSTRAINT [PK_Zone] PRIMARY KEY ([zoneid])
);
GO

CREATE TABLE [Spec] (
    [specid] int NOT NULL IDENTITY,
    [id] int NOT NULL,
    [s_name] nvarchar(500) NULL,
    [s_icon] nvarchar(500) NULL,
    [ClassModelClassId] int NULL,
    CONSTRAINT [PK_Spec] PRIMARY KEY ([specid]),
    CONSTRAINT [FK_Spec_Class_ClassModelClassId] FOREIGN KEY ([ClassModelClassId]) REFERENCES [Class] ([classid]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Data] (
    [dataid] int NOT NULL IDENTITY,
    [itemid] int NOT NULL,
    [d_name] nvarchar(500) NULL,
    [d_icon] nvarchar(500) NULL,
    [d_class] nvarchar(500) NULL,
    [d_subclass] nvarchar(500) NULL,
    [d_sellprice] int NOT NULL,
    [d_quality] nvarchar(500) NULL,
    [d_itemlevel] int NOT NULL,
    [d_requiredlevel] int NOT NULL,
    [d_slot] nvarchar(500) NULL,
    [d_vendorprice] int NOT NULL,
    [SourceId] int NULL,
    [d_uniquename] nvarchar(500) NULL,
    [d_contentphase] int NULL,
    CONSTRAINT [PK_Data] PRIMARY KEY ([dataid]),
    CONSTRAINT [FK_Data_Source_SourceId] FOREIGN KEY ([SourceId]) REFERENCES [Source] ([sourceid]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Quest] (
    [id] int NOT NULL IDENTITY,
    [questid] int NOT NULL,
    [q_name] nvarchar(500) NULL,
    [q_faction] nvarchar(500) NULL,
    [SourceModelSourceId] int NULL,
    CONSTRAINT [PK_Quest] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Quest_Source_SourceModelSourceId] FOREIGN KEY ([SourceModelSourceId]) REFERENCES [Source] ([sourceid]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Tooltip] (
    [tooltipid] int NOT NULL IDENTITY,
    [id] int NOT NULL,
    [t_label] nvarchar(1000) NULL,
    [t_format] nvarchar(500) NULL,
    [DataModelDataId] int NULL,
    [TalentModelTalentId] int NULL,
    CONSTRAINT [PK_Tooltip] PRIMARY KEY ([tooltipid]),
    CONSTRAINT [FK_Tooltip_Data_DataModelDataId] FOREIGN KEY ([DataModelDataId]) REFERENCES [Data] ([dataid]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Tooltip_Talent_TalentModelTalentId] FOREIGN KEY ([TalentModelTalentId]) REFERENCES [Talent] ([talentid]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Data_SourceId] ON [Data] ([SourceId]);
GO

CREATE INDEX [IX_Quest_SourceModelSourceId] ON [Quest] ([SourceModelSourceId]);
GO

CREATE INDEX [IX_Spec_ClassModelClassId] ON [Spec] ([ClassModelClassId]);
GO

CREATE INDEX [IX_Tooltip_DataModelDataId] ON [Tooltip] ([DataModelDataId]);
GO

CREATE INDEX [IX_Tooltip_TalentModelTalentId] ON [Tooltip] ([TalentModelTalentId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210508232615_Initial_Migration', N'6.0.0-preview.1.21102.2');
GO

COMMIT;
GO

