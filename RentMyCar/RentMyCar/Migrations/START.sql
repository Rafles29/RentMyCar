IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Users] (
    [UserId] bigint NOT NULL IDENTITY,
    [Login] nvarchar(max) NULL,
    [Mail] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [Cars] (
    [CarId] bigint NOT NULL IDENTITY,
    [AvatarImage] varbinary(max) NULL,
    [Manufactor] nvarchar(max) NULL,
    [Model] nvarchar(max) NULL,
    [UserId] bigint NOT NULL,
    [Year] int NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([CarId]),
    CONSTRAINT [FK_Cars_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Equipment] (
    [EquipmentId] bigint NOT NULL IDENTITY,
    [AC] int NOT NULL,
    [BodyType] int NOT NULL,
    [CarId] bigint NOT NULL,
    [Colour] int NOT NULL,
    [Gearbox] int NOT NULL,
    [Lift] bit NOT NULL,
    [Seats] int NOT NULL,
    CONSTRAINT [PK_Equipment] PRIMARY KEY ([EquipmentId]),
    CONSTRAINT [FK_Equipment_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [Cars] ([CarId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Performance] (
    [PerformanceId] bigint NOT NULL IDENTITY,
    [CarId] bigint NOT NULL,
    [HorsePower] int NOT NULL,
    [MaxSpeed] float NOT NULL,
    [Millage] int NOT NULL,
    [ZeroTo100] float NOT NULL,
    CONSTRAINT [PK_Performance] PRIMARY KEY ([PerformanceId]),
    CONSTRAINT [FK_Performance_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [Cars] ([CarId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Price] (
    [PriceId] bigint NOT NULL IDENTITY,
    [CarId] bigint NOT NULL,
    [LongTermPrice] decimal(18, 2) NOT NULL,
    [MidTermPrice] decimal(18, 2) NOT NULL,
    [ShortTermPrice] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_Price] PRIMARY KEY ([PriceId]),
    CONSTRAINT [FK_Price_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [Cars] ([CarId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Rents] (
    [RentId] bigint NOT NULL IDENTITY,
    [CarId] bigint NULL,
    [EndDate] datetime2 NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [UserId] bigint NULL,
    CONSTRAINT [PK_Rents] PRIMARY KEY ([RentId]),
    CONSTRAINT [FK_Rents_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [Cars] ([CarId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Rents_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Adress] (
    [AdressId] bigint NOT NULL IDENTITY,
    [City] nvarchar(max) NULL,
    [PostalCode] nvarchar(max) NULL,
    [RentId] bigint NOT NULL,
    [StreetName] nvarchar(max) NULL,
    [StreetNumber] int NOT NULL,
    CONSTRAINT [PK_Adress] PRIMARY KEY ([AdressId]),
    CONSTRAINT [FK_Adress_Rents_RentId] FOREIGN KEY ([RentId]) REFERENCES [Rents] ([RentId]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_Adress_RentId] ON [Adress] ([RentId]);

GO

CREATE INDEX [IX_Cars_UserId] ON [Cars] ([UserId]);

GO

CREATE UNIQUE INDEX [IX_Equipment_CarId] ON [Equipment] ([CarId]);

GO

CREATE UNIQUE INDEX [IX_Performance_CarId] ON [Performance] ([CarId]);

GO

CREATE UNIQUE INDEX [IX_Price_CarId] ON [Price] ([CarId]);

GO

CREATE INDEX [IX_Rents_CarId] ON [Rents] ([CarId]);

GO

CREATE INDEX [IX_Rents_UserId] ON [Rents] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20171127173346_init', N'2.0.0-rtm-26452');

GO

