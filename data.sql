CREATE DATABASE Blog

use Blog

CREATE TABLE BanTin (
    IDBanTin INT PRIMARY KEY IDENTITY(1,1),
    tenBanTin NVARCHAR(100)
);
CREATE TABLE ChiTiet (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TieuDe NVARCHAR(255),
    noiDung NVARCHAR(MAX),
    lanXem INT,
    ngayDang DATETIME,
    IDBanTin INT,
    FOREIGN KEY (IDBanTin) REFERENCES BanTin(IDBanTin)
);
CREATE TABLE DangNhap (
    IDName INT PRIMARY KEY IDENTITY(1,1),
    userName NVARCHAR(50),
    passWord NVARCHAR(50)
);

--lay tat ca Ban tin
CREATE PROC BanTin_SelectAll
AS
BEGIN
	SELECT * FROM BanTin
END
GO
CREATE PROC BanTin_SelectID(
	@IDBanTin INT
)
AS
BEGIN
	SELECT * FROM BanTin WHERE IDBanTin = @IDBanTin
END
GO
--Them ban tin
CREATE PROC BanTin_Insert(
	@tenBanTin nvarchar(50)
)
AS
BEGIN
	INSERT INTO BanTin(tenBanTin) VALUES (@tenBanTin)
END
GO
--cap nhat ban tin
ALTER PROC BanTin_Update(
	@tenBanTin nvarchar(50),
	@IDBanTin int
)
AS
BEGIN
	UPDATE BanTin SET tenBanTin = @tenBanTin WHERE IDBanTin = @IDBanTin
END
GO
--Xoa ban tin
CREATE PROC BanTin_Delete(
	@IDBanTin int
)
AS
BEGIN
	DELETE FROM BanTin WHERE IDBanTin = @IDBanTin
END
GO
-- lay tat ca Noi dung 
CREATE PROC ChiTiet_SelectAll
AS
BEGIN
	SELECT * FROM ChiTiet
END
GO
--noi dung theo id ban tin
CREATE PROC ChiTiet_SelectBanTin(
	@IDBanTin int
)
AS
BEGIN
	SELECT * FROM ChiTiet WHERE IDBanTin = @IDBanTin
END
GO
--Lay 1 ban tin theo id
CREATE PROC ChiTiet_SelectID(
	@ID int
)
AS
BEGIN
	SELECT * FROM ChiTiet WHERE ID = @ID
END
GO
CREATE PROC ChiTiet_SelectHome
AS
BEGIN
	SELECT TOP 30 * FROM ChiTiet ORDER BY ID DESC
END
GO
CREATE PROC ChiTiet_SelectRandom
	@IDBanTin INT
AS
BEGIN
	SELECT TOP 5 * FROM ChiTiet TABLESAMPLE (5 ROWS)
END
GO
--Them noi dung
CREATE PROC ChiTiet_Insert(
	@tieuDe nvarchar(200),
	@noiDung nvarchar(MAX),
	@ngayDang datetime,
	@IDBanTin int
)
AS
BEGIN
	INSERT INTO ChiTiet(TieuDe, noiDung, ngayDang, IDBanTin) VALUES (@tieuDe, @noiDung, @ngayDang, @IDBanTin)
END
GO
--cap nhat noi dung
CREATE PROC ChiTiet_Update(
	@tieuDe nvarchar(200),
	@noiDung nvarchar(MAX),
	@ID int
)
AS
BEGIN
	UPDATE ChiTiet SET TieuDe = @tieuDe, noiDung = @noiDung WHERE ID = @ID
END
GO
--cap nhat so lan xem
CREATE PROCEDURE ChiTiet_SLX(
    @lanXem INT,
    @ID INT
)
AS
BEGIN
    UPDATE ChiTiet
    SET lanXem = @lanXem
    WHERE ID = @ID
END
GO
CREATE PROC ChiTiet_LanXem(
	@ID int,
	@lanXem int output
)
AS
BEGIN

	SELECT @lanXem = lanXem FROM ChiTiet WHERE ID = @ID
END
GO
CREATE PROC ChiTiet_Delete(
	@ID int
)
AS
BEGIN
	DELETE FROM ChiTiet WHERE ID = @ID
END
GO
--dang nhap
CREATE PROC DangNhap_SelectAll
AS
BEGIN
	SELECT * FROM DangNhap
END
GO
--them tai khoan
CREATE PROC DangNhap_Insert
	@userName NVARCHAR(50),
	@passWord NVARCHAR(50)
AS
BEGIN
	INSERT INTO DangNhap(userName, passWord) VALUES (@UserName, @Password)
END
GO
--cap nhat tai khoan
CREATE PROC DangNhap_Update
	@IDName INT,
	@userName NVARCHAR(50),
	@passWord NVARCHAR(50)
AS
BEGIN
	UPDATE DangNhap SET userName = @userName, passWord = @passWord WHERE IDName = @IDName
END
GO
--xoa tai khoan
CREATE PROC DangNhap_Delete
	@IDName INT
AS
BEGIN
	DELETE FROM DangNhap WHERE IDName = @IDName
END
GO
--tim kiem tai khoan
CREATE PROC DangNhap_Search
    @userName nvarchar(50),
	@passWord nvarchar(50)
AS
BEGIN
    SELECT * FROM DangNhap WHERE userName = @userName AND passWord = @passWord
END
GO




