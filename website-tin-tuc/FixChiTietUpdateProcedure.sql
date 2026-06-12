USE [Blog];
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
