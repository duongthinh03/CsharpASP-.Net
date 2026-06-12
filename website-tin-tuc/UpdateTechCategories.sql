USE [Blog];
GO

BEGIN TRANSACTION;

UPDATE dbo.BanTin SET tenBanTin = N'Lập trình Web' WHERE IDBanTin = 1;
UPDATE dbo.BanTin SET tenBanTin = N'Backend' WHERE IDBanTin = 2;
UPDATE dbo.BanTin SET tenBanTin = N'Database' WHERE IDBanTin = 3;
UPDATE dbo.BanTin SET tenBanTin = N'Kiến trúc phần mềm' WHERE IDBanTin = 4;
UPDATE dbo.BanTin SET tenBanTin = N'Design Patterns' WHERE IDBanTin = 5;

SET IDENTITY_INSERT dbo.BanTin ON;

IF NOT EXISTS (SELECT 1 FROM dbo.BanTin WHERE IDBanTin = 6)
    INSERT INTO dbo.BanTin (IDBanTin, tenBanTin) VALUES (6, N'DevOps');
ELSE
    UPDATE dbo.BanTin SET tenBanTin = N'DevOps' WHERE IDBanTin = 6;

IF NOT EXISTS (SELECT 1 FROM dbo.BanTin WHERE IDBanTin = 7)
    INSERT INTO dbo.BanTin (IDBanTin, tenBanTin) VALUES (7, N'Bảo mật');
ELSE
    UPDATE dbo.BanTin SET tenBanTin = N'Bảo mật' WHERE IDBanTin = 7;

IF NOT EXISTS (SELECT 1 FROM dbo.BanTin WHERE IDBanTin = 8)
    INSERT INTO dbo.BanTin (IDBanTin, tenBanTin) VALUES (8, N'Công cụ lập trình');
ELSE
    UPDATE dbo.BanTin SET tenBanTin = N'Công cụ lập trình' WHERE IDBanTin = 8;

IF NOT EXISTS (SELECT 1 FROM dbo.BanTin WHERE IDBanTin = 9)
    INSERT INTO dbo.BanTin (IDBanTin, tenBanTin) VALUES (9, N'Tài liệu tham khảo');
ELSE
    UPDATE dbo.BanTin SET tenBanTin = N'Tài liệu tham khảo' WHERE IDBanTin = 9;

SET IDENTITY_INSERT dbo.BanTin OFF;

UPDATE dbo.ChiTiet
SET IDBanTin = 1
WHERE TieuDe LIKE N'%ASP.NET%'
   OR TieuDe LIKE N'%VueJS%'
   OR TieuDe LIKE N'%RESTful API%';

UPDATE dbo.ChiTiet
SET IDBanTin = 2
WHERE TieuDe LIKE N'%API Gateway%'
   OR TieuDe LIKE N'%Entity%'
   OR TieuDe LIKE N'%Value Object%'
   OR TieuDe LIKE N'%Rate Limiting%'
   OR TieuDe LIKE N'%Timeout%'
   OR TieuDe LIKE N'%Caching%'
   OR TieuDe LIKE N'%Dependency Injection%';

UPDATE dbo.ChiTiet
SET IDBanTin = 3
WHERE TieuDe LIKE N'%SQL Server%'
   OR TieuDe LIKE N'%Migration%';

UPDATE dbo.ChiTiet
SET IDBanTin = 4
WHERE TieuDe LIKE N'%Microservices%'
   OR TieuDe LIKE N'%Monolith%'
   OR TieuDe LIKE N'%Clean Architecture%'
   OR TieuDe LIKE N'%Domain-Driven Design%'
   OR TieuDe LIKE N'%DDD%';

UPDATE dbo.ChiTiet
SET IDBanTin = 5
WHERE TieuDe LIKE N'%Repository Pattern%';

UPDATE dbo.ChiTiet
SET IDBanTin = 6
WHERE TieuDe LIKE N'%Docker%'
   OR TieuDe LIKE N'%Hangfire%'
   OR TieuDe LIKE N'%Kafka%';

UPDATE dbo.ChiTiet
SET IDBanTin = 7
WHERE TieuDe LIKE N'%JWT%'
   OR TieuDe LIKE N'%Authentication%'
   OR TieuDe LIKE N'%Security%'
   OR TieuDe LIKE N'%Bảo mật%';

UPDATE dbo.ChiTiet
SET IDBanTin = 8
WHERE TieuDe LIKE N'%Git%'
   OR TieuDe LIKE N'%Visual Studio%'
   OR TieuDe LIKE N'%VS Code%'
   OR TieuDe LIKE N'%Công cụ%';

UPDATE dbo.ChiTiet
SET IDBanTin = 9
WHERE TieuDe LIKE N'%Tài liệu%'
   OR TieuDe LIKE N'%tham khảo%';

COMMIT TRANSACTION;
GO

SELECT IDBanTin, tenBanTin
FROM dbo.BanTin
ORDER BY IDBanTin;

SELECT ct.ID, ct.TieuDe, ct.IDBanTin, bt.tenBanTin
FROM dbo.ChiTiet ct
LEFT JOIN dbo.BanTin bt ON bt.IDBanTin = ct.IDBanTin
ORDER BY ct.ID;
GO
