USE [Blog];
GO

CREATE OR ALTER PROCEDURE [dbo].[BanTin_Insert]
    @tenBanTin NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[BanTin] ([tenBanTin])
    VALUES (@tenBanTin);
END
GO

CREATE OR ALTER PROCEDURE [dbo].[BanTin_Update]
    @tenBanTin NVARCHAR(50),
    @IDBanTin INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[BanTin]
    SET [tenBanTin] = @tenBanTin
    WHERE [IDBanTin] = @IDBanTin;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[BanTin_Delete]
    @IDBanTin INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[BanTin]
    WHERE [IDBanTin] = @IDBanTin;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ChiTiet_Insert]
    @tieuDe NVARCHAR(200),
    @noiDung NVARCHAR(MAX),
    @ngayDang DATETIME,
    @IDBanTin INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[ChiTiet] ([TieuDe], [noiDung], [ngayDang], [IDBanTin], [lanXem])
    VALUES (@tieuDe, @noiDung, @ngayDang, @IDBanTin, 0);
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ChiTiet_Update]
    @tieuDe NVARCHAR(200),
    @noiDung NVARCHAR(MAX),
    @ID INT,
    @IDBanTin INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[ChiTiet]
    SET [TieuDe] = @tieuDe,
        [noiDung] = @noiDung,
        [IDBanTin] = @IDBanTin
    WHERE [ID] = @ID;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ChiTiet_Delete]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[ChiTiet]
    WHERE [ID] = @ID;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[DangNhap_Insert]
    @userName NVARCHAR(50),
    @passWord NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[DangNhap] ([userName], [passWord])
    VALUES (@userName, @passWord);
END
GO

CREATE OR ALTER PROCEDURE [dbo].[DangNhap_Update]
    @IDName INT,
    @userName NVARCHAR(50),
    @passWord NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[DangNhap]
    SET [userName] = @userName,
        [passWord] = @passWord
    WHERE [IDName] = @IDName;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[DangNhap_Delete]
    @IDName INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[DangNhap]
    WHERE [IDName] = @IDName;
END
GO
