IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813115443_CreateIdentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200813115443_CreateIdentity', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813121454_AddNamesToUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813121454_AddNamesToUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LastName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200813121454_AddNamesToUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200813121454_AddNamesToUser', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [ClassroomClassID] nvarchar(10) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE TABLE [Classroom] (
        [ClassID] nvarchar(10) NOT NULL,
        [TeacherID] nvarchar(450) NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Classroom] PRIMARY KEY ([ClassID]),
        CONSTRAINT [FK_Classroom_AspNetUsers_TeacherID] FOREIGN KEY ([TeacherID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE TABLE [Simulation] (
        [SimulationID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Simulation] PRIMARY KEY ([SimulationID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE TABLE [Enrollment] (
        [StudentID] nvarchar(450) NOT NULL,
        [ClassID] nvarchar(450) NOT NULL,
        [ClassroomClassID] nvarchar(10) NULL,
        CONSTRAINT [PK_Enrollment] PRIMARY KEY ([StudentID], [ClassID]),
        CONSTRAINT [FK_Enrollment_Classroom_ClassroomClassID] FOREIGN KEY ([ClassroomClassID]) REFERENCES [Classroom] ([ClassID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Enrollment_AspNetUsers_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE TABLE [ClassAssignment] (
        [ClassID] nvarchar(450) NOT NULL,
        [SimulationID] int NOT NULL,
        [DateSet] datetime2 NOT NULL,
        [DateDue] datetime2 NOT NULL,
        [ClassroomClassID] nvarchar(10) NULL,
        CONSTRAINT [PK_ClassAssignment] PRIMARY KEY ([ClassID], [SimulationID]),
        CONSTRAINT [FK_ClassAssignment_Classroom_ClassroomClassID] FOREIGN KEY ([ClassroomClassID]) REFERENCES [Classroom] ([ClassID]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ClassAssignment_Simulation_SimulationID] FOREIGN KEY ([SimulationID]) REFERENCES [Simulation] ([SimulationID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE TABLE [StudentAssignment] (
        [StudentID] nvarchar(450) NOT NULL,
        [SimulationID] int NOT NULL,
        [Percentage] int NULL,
        [DateCompleted] datetime2 NOT NULL,
        CONSTRAINT [PK_StudentAssignment] PRIMARY KEY ([StudentID], [SimulationID]),
        CONSTRAINT [FK_StudentAssignment_Simulation_SimulationID] FOREIGN KEY ([SimulationID]) REFERENCES [Simulation] ([SimulationID]) ON DELETE CASCADE,
        CONSTRAINT [FK_StudentAssignment_AspNetUsers_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE INDEX [IX_AspNetUsers_ClassroomClassID] ON [AspNetUsers] ([ClassroomClassID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE INDEX [IX_ClassAssignment_ClassroomClassID] ON [ClassAssignment] ([ClassroomClassID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE INDEX [IX_ClassAssignment_SimulationID] ON [ClassAssignment] ([SimulationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE INDEX [IX_Classroom_TeacherID] ON [Classroom] ([TeacherID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE INDEX [IX_Enrollment_ClassroomClassID] ON [Enrollment] ([ClassroomClassID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    CREATE INDEX [IX_StudentAssignment_SimulationID] ON [StudentAssignment] ([SimulationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Classroom_ClassroomClassID] FOREIGN KEY ([ClassroomClassID]) REFERENCES [Classroom] ([ClassID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814125506_InitialModels')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200814125506_InitialModels', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Classroom_ClassroomClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [ClassAssignment] DROP CONSTRAINT [FK_ClassAssignment_Classroom_ClassroomClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Classroom] DROP CONSTRAINT [FK_Classroom_AspNetUsers_TeacherID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] DROP CONSTRAINT [FK_Enrollment_Classroom_ClassroomClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] DROP CONSTRAINT [FK_Enrollment_AspNetUsers_StudentID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [StudentAssignment] DROP CONSTRAINT [FK_StudentAssignment_AspNetUsers_StudentID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [StudentAssignment] DROP CONSTRAINT [PK_StudentAssignment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] DROP CONSTRAINT [PK_Enrollment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DROP INDEX [IX_Enrollment_ClassroomClassID] ON [Enrollment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Classroom] DROP CONSTRAINT [PK_Classroom];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DROP INDEX [IX_Classroom_TeacherID] ON [Classroom];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [ClassAssignment] DROP CONSTRAINT [PK_ClassAssignment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DROP INDEX [IX_ClassAssignment_ClassroomClassID] ON [ClassAssignment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DROP INDEX [IX_AspNetUsers_ClassroomClassID] ON [AspNetUsers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StudentAssignment]') AND [c].[name] = N'StudentID');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [StudentAssignment] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [StudentAssignment] DROP COLUMN [StudentID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'StudentID');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Enrollment] DROP COLUMN [StudentID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'ClassroomClassID');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Enrollment] DROP COLUMN [ClassroomClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Classroom]') AND [c].[name] = N'ClassID');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Classroom] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Classroom] DROP COLUMN [ClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Classroom]') AND [c].[name] = N'TeacherID');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Classroom] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Classroom] DROP COLUMN [TeacherID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClassAssignment]') AND [c].[name] = N'ClassID');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ClassAssignment] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [ClassAssignment] DROP COLUMN [ClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClassAssignment]') AND [c].[name] = N'ClassroomClassID');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ClassAssignment] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ClassAssignment] DROP COLUMN [ClassroomClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'ClassroomClassID');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [ClassroomClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [StudentAssignment] ADD [UserID] nvarchar(450) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'ClassID');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Enrollment] ALTER COLUMN [ClassID] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD [UserID] nvarchar(450) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD [ClassroomID] nvarchar(450) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD [Grade] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD [NEAUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Classroom] ADD [ClassroomID] nvarchar(450) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Classroom] ADD [UserID] nvarchar(450) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [ClassAssignment] ADD [ClassroomID] nvarchar(450) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [StudentAssignment] ADD CONSTRAINT [PK_StudentAssignment] PRIMARY KEY ([UserID], [SimulationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [PK_Enrollment] PRIMARY KEY ([UserID], [ClassroomID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Classroom] ADD CONSTRAINT [PK_Classroom] PRIMARY KEY ([ClassroomID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [ClassAssignment] ADD CONSTRAINT [PK_ClassAssignment] PRIMARY KEY ([ClassroomID], [SimulationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    CREATE INDEX [IX_Enrollment_ClassroomID] ON [Enrollment] ([ClassroomID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    CREATE INDEX [IX_Enrollment_NEAUserId] ON [Enrollment] ([NEAUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    CREATE INDEX [IX_Classroom_UserID] ON [Classroom] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [ClassAssignment] ADD CONSTRAINT [FK_ClassAssignment_Classroom_ClassroomID] FOREIGN KEY ([ClassroomID]) REFERENCES [Classroom] ([ClassroomID]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Classroom] ADD CONSTRAINT [FK_Classroom_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [FK_Enrollment_Classroom_ClassroomID] FOREIGN KEY ([ClassroomID]) REFERENCES [Classroom] ([ClassroomID]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [FK_Enrollment_AspNetUsers_NEAUserId] FOREIGN KEY ([NEAUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [FK_Enrollment_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    ALTER TABLE [StudentAssignment] ADD CONSTRAINT [FK_StudentAssignment_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143711_FixingConstraints')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200814143711_FixingConstraints', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143758_RemoveUnnecessaryProperties')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'ClassID');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Enrollment] DROP COLUMN [ClassID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143758_RemoveUnnecessaryProperties')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'Grade');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Enrollment] DROP COLUMN [Grade];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814143758_RemoveUnnecessaryProperties')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200814143758_RemoveUnnecessaryProperties', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814144247_uidEnrollment')
BEGIN
    ALTER TABLE [Enrollment] DROP CONSTRAINT [FK_Enrollment_AspNetUsers_UserID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814144247_uidEnrollment')
BEGIN
    EXEC sp_rename N'[Enrollment].[UserID]', N'UserId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814144247_uidEnrollment')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [FK_Enrollment_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200814144247_uidEnrollment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200814144247_uidEnrollment', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    ALTER TABLE [Enrollment] DROP CONSTRAINT [FK_Enrollment_AspNetUsers_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    ALTER TABLE [Enrollment] DROP CONSTRAINT [PK_Enrollment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    DROP INDEX [IX_Enrollment_NEAUserId] ON [Enrollment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'UserId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Enrollment] DROP COLUMN [UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'NEAUserId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Enrollment] ALTER COLUMN [NEAUserId] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    ALTER TABLE [Enrollment] ADD [NEAUserId1] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'Name');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [Name] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserTokens]') AND [c].[name] = N'LoginProvider');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserTokens] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [AspNetUserTokens] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'ProviderKey');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [ProviderKey] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUserLogins]') AND [c].[name] = N'LoginProvider');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUserLogins] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [AspNetUserLogins] ALTER COLUMN [LoginProvider] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [PK_Enrollment] PRIMARY KEY ([NEAUserId], [ClassroomID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    CREATE INDEX [IX_Enrollment_NEAUserId1] ON [Enrollment] ([NEAUserId1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [FK_Enrollment_AspNetUsers_NEAUserId1] FOREIGN KEY ([NEAUserId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815110745_EnrollmentNEAUserId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200815110745_EnrollmentNEAUserId', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815111219_RemoveEnrollmentCollectionUser')
BEGIN
    ALTER TABLE [Enrollment] DROP CONSTRAINT [FK_Enrollment_AspNetUsers_NEAUserId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815111219_RemoveEnrollmentCollectionUser')
BEGIN
    DROP INDEX [IX_Enrollment_NEAUserId1] ON [Enrollment];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815111219_RemoveEnrollmentCollectionUser')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Enrollment]') AND [c].[name] = N'NEAUserId1');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Enrollment] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Enrollment] DROP COLUMN [NEAUserId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200815111219_RemoveEnrollmentCollectionUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200815111219_RemoveEnrollmentCollectionUser', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200816110256_FinishIndexClassPage')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200816110256_FinishIndexClassPage', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200824101955_SimulationModel')
BEGIN
    ALTER TABLE [Simulation] ADD [Description] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200824101955_SimulationModel')
BEGIN
    ALTER TABLE [Simulation] ADD [PreviewImgSrc] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200824101955_SimulationModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200824101955_SimulationModel', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926110358_QuestionEntities')
BEGIN
    CREATE TABLE [QuestionType] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [AnswerFormat] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_QuestionType] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926110358_QuestionEntities')
BEGIN
    CREATE TABLE [Question] (
        [SimulationID] int NOT NULL,
        [QIndex] int NOT NULL,
        [QuestionTypeID] int NOT NULL,
        [QuestionString] nvarchar(max) NOT NULL,
        [AnswerString] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Question] PRIMARY KEY ([SimulationID], [QIndex]),
        CONSTRAINT [FK_Question_QuestionType_QuestionTypeID] FOREIGN KEY ([QuestionTypeID]) REFERENCES [QuestionType] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_Question_Simulation_SimulationID] FOREIGN KEY ([SimulationID]) REFERENCES [Simulation] ([SimulationID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926110358_QuestionEntities')
BEGIN
    CREATE INDEX [IX_Question_QuestionTypeID] ON [Question] ([QuestionTypeID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926110358_QuestionEntities')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200926110358_QuestionEntities', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926120207_StudentQModel')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionType]') AND [c].[name] = N'AnswerFormat');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [QuestionType] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [QuestionType] ALTER COLUMN [AnswerFormat] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926120207_StudentQModel')
BEGIN
    CREATE TABLE [StudentQuestion] (
        [SimulationID] int NOT NULL,
        [QIndex] int NOT NULL,
        [UserID] nvarchar(450) NOT NULL,
        [Answer] nvarchar(max) NULL,
        [Correct] bit NOT NULL,
        [QuestionQIndex] int NULL,
        [QuestionSimulationID] int NULL,
        CONSTRAINT [PK_StudentQuestion] PRIMARY KEY ([SimulationID], [QIndex], [UserID]),
        CONSTRAINT [FK_StudentQuestion_Simulation_SimulationID] FOREIGN KEY ([SimulationID]) REFERENCES [Simulation] ([SimulationID]) ON DELETE CASCADE,
        CONSTRAINT [FK_StudentQuestion_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_StudentQuestion_Question_QuestionSimulationID_QuestionQIndex] FOREIGN KEY ([QuestionSimulationID], [QuestionQIndex]) REFERENCES [Question] ([SimulationID], [QIndex]) ON DELETE NO ACTION,
        CONSTRAINT [FK_StudentQuestion_Question_SimulationID_QIndex] FOREIGN KEY ([SimulationID], [QIndex]) REFERENCES [Question] ([SimulationID], [QIndex]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926120207_StudentQModel')
BEGIN
    CREATE INDEX [IX_StudentQuestion_UserID] ON [StudentQuestion] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926120207_StudentQModel')
BEGIN
    CREATE INDEX [IX_StudentQuestion_QuestionSimulationID_QuestionQIndex] ON [StudentQuestion] ([QuestionSimulationID], [QuestionQIndex]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200926120207_StudentQModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200926120207_StudentQModel', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927094638_RemovedXSForiegnKeys')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200927094638_RemovedXSForiegnKeys', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927095220_StudentQModelFix')
BEGIN
    ALTER TABLE [StudentQuestion] DROP CONSTRAINT [FK_StudentQuestion_AspNetUsers_UserID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927095220_StudentQModelFix')
BEGIN
    DROP INDEX [IX_StudentQuestion_UserID] ON [StudentQuestion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927095220_StudentQModelFix')
BEGIN
    ALTER TABLE [StudentQuestion] ADD [NEAUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927095220_StudentQModelFix')
BEGIN
    CREATE INDEX [IX_StudentQuestion_NEAUserId] ON [StudentQuestion] ([NEAUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927095220_StudentQModelFix')
BEGIN
    ALTER TABLE [StudentQuestion] ADD CONSTRAINT [FK_StudentQuestion_AspNetUsers_NEAUserId] FOREIGN KEY ([NEAUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927095220_StudentQModelFix')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200927095220_StudentQModelFix', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927102249_StuQuestAssignFK')
BEGIN
    ALTER TABLE [StudentQuestion] ADD [StudentAssignmentSimulationID] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927102249_StuQuestAssignFK')
BEGIN
    ALTER TABLE [StudentQuestion] ADD [StudentAssignmentUserID] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927102249_StuQuestAssignFK')
BEGIN
    CREATE INDEX [IX_StudentQuestion_StudentAssignmentUserID_StudentAssignmentSimulationID] ON [StudentQuestion] ([StudentAssignmentUserID], [StudentAssignmentSimulationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927102249_StuQuestAssignFK')
BEGIN
    CREATE INDEX [IX_StudentQuestion_UserID_SimulationID] ON [StudentQuestion] ([UserID], [SimulationID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927102249_StuQuestAssignFK')
BEGIN
    ALTER TABLE [StudentQuestion] ADD CONSTRAINT [FK_StudentQuestion_StudentAssignment_StudentAssignmentUserID_StudentAssignmentSimulationID] FOREIGN KEY ([StudentAssignmentUserID], [StudentAssignmentSimulationID]) REFERENCES [StudentAssignment] ([UserID], [SimulationID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927102249_StuQuestAssignFK')
BEGIN
    ALTER TABLE [StudentQuestion] ADD CONSTRAINT [FK_StudentQuestion_StudentAssignment_UserID_SimulationID] FOREIGN KEY ([UserID], [SimulationID]) REFERENCES [StudentAssignment] ([UserID], [SimulationID]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927102249_StuQuestAssignFK')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200927102249_StuQuestAssignFK', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927110145_SQCRUD')
BEGIN
    ALTER TABLE [StudentQuestion] DROP CONSTRAINT [FK_StudentQuestion_StudentAssignment_StudentAssignmentUserID_StudentAssignmentSimulationID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927110145_SQCRUD')
BEGIN
    ALTER TABLE [StudentQuestion] DROP CONSTRAINT [FK_StudentQuestion_StudentAssignment_UserID_SimulationID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927110145_SQCRUD')
BEGIN
    DROP INDEX [IX_StudentQuestion_StudentAssignmentUserID_StudentAssignmentSimulationID] ON [StudentQuestion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927110145_SQCRUD')
BEGIN
    DROP INDEX [IX_StudentQuestion_UserID_SimulationID] ON [StudentQuestion];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927110145_SQCRUD')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StudentQuestion]') AND [c].[name] = N'StudentAssignmentSimulationID');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [StudentQuestion] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [StudentQuestion] DROP COLUMN [StudentAssignmentSimulationID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927110145_SQCRUD')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StudentQuestion]') AND [c].[name] = N'StudentAssignmentUserID');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [StudentQuestion] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [StudentQuestion] DROP COLUMN [StudentAssignmentUserID];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200927110145_SQCRUD')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200927110145_SQCRUD', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201003123534_isCorrectEnum')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StudentQuestion]') AND [c].[name] = N'Correct');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [StudentQuestion] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [StudentQuestion] DROP COLUMN [Correct];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201003123534_isCorrectEnum')
BEGIN
    ALTER TABLE [StudentQuestion] ADD [isCorrect] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201003123534_isCorrectEnum')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201003123534_isCorrectEnum', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201003140444_EnrollmentNavProperty')
BEGIN
    ALTER TABLE [Enrollment] ADD [NEAUserId1] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201003140444_EnrollmentNavProperty')
BEGIN
    CREATE INDEX [IX_Enrollment_NEAUserId1] ON [Enrollment] ([NEAUserId1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201003140444_EnrollmentNavProperty')
BEGIN
    ALTER TABLE [Enrollment] ADD CONSTRAINT [FK_Enrollment_AspNetUsers_NEAUserId1] FOREIGN KEY ([NEAUserId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201003140444_EnrollmentNavProperty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201003140444_EnrollmentNavProperty', N'3.1.6');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201017134140_AddOverriddenToEnum')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201017134140_AddOverriddenToEnum', N'3.1.6');
END;

GO

