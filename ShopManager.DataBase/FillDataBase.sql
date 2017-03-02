use ShopManagerDB
go

EXEC [dbo].[spInsertEmployee] 'Sviatoslav','Kindrat','Vasiliovich','Administrator',4000,'(093)709-91-29','Makoveia 45/1','sviatoslav931@gmail.com','QB6UWVvunAT6IkBP/gdfrw==','c/sqqDQV2+7k55SNqqtpjQ==',1,1
EXEC [dbo].[spInsertEmployee]  'Volodumer','Volodumerov','Ivanovitch','Seller',3000,'(093)705-93-49','Makoveia 45/3','testmail2293@gmail.com','vbRvQ1rvMEUlWwkWQInLHw==','r4ulPRdsLM5q9bS3+IKMIA==',1,2
GO
--->ProductCategory
EXEC  [dbo].[spInserCategory] 'Buttons'
EXEC [dbo].[spInserCategory] 'Cloths'
EXEC [dbo].[spInserCategory] 'Beads'
EXEC [dbo].[spInserCategory] 'Threads'
EXEC [dbo].[spInserCategory] 'Needle'
EXEC [dbo].[spInserCategory] 'Immitation jewelry'
EXEC [dbo].[spInserCategory] 'Straps'
GO
--->ProductSubCategory
EXEC [dbo].[spInserSubCategory] 'Buttons','Small'
EXEC [dbo].[spInserSubCategory] 'Buttons','Middle'
EXEC [dbo].[spInserSubCategory] 'Buttons','Big'
EXEC [dbo].[spInserSubCategory] 'Cloths','Summer'
EXEC [dbo].[spInserSubCategory] 'Cloths','Winter'
EXEC [dbo].[spInserSubCategory] 'Cloths','Spring'
EXEC [dbo].[spInserSubCategory] 'Cloths','Autumn'
EXEC [dbo].[spInserSubCategory] 'Cloths','Embroidered'
EXEC [dbo].[spInserSubCategory] 'Cloths','Linen'
EXEC [dbo].[spInserSubCategory] 'Immitation jewelry','Necklaces'
EXEC [dbo].[spInserSubCategory] 'Beads','Green Bead'
EXEC [dbo].[spInserSubCategory] 'Beads','Red Bead'
EXEC [dbo].[spInserSubCategory] 'Beads','Yellow Bead'
GO

--->Product
EXEC [dbo].[spInserProduct] 'Zaniker','1A/00001',45,'Buttons','Small'
EXEC [dbo].[spInserProduct] 'Modern','1A/00002',37,'Buttons','Small'
EXEC [dbo].[spInserProduct] 'Sereni','1B/00001',50,'Cloths','Summer'
EXEC [dbo].[spInserProduct] 'Biza','1B/00002',145,'Cloths','Summer'
EXEC [dbo].[spInserProduct] 'Weider','1B/00003',10,'Cloths','Winter'
EXEC [dbo].[spInserProduct] 'Retro Style','1B/00004',120,'Cloths','Winter'
GO
-->Supplier
EXEC [dbo].[sqInserSupplier] 'MSGoodCloths','(096)784-53-21','qwerty@mail.com','Shevchenka 45'
EXEC [dbo].[sqInserSupplier] 'K2Company','(093)453-21-23','qwerty11@gmail.com','Banderu 123'
EXEC [dbo].[sqInserSupplier] 'Kindrat And Family','(096)456-31-23','kindrat@mail.com','Zelena 34/1'
EXEC [dbo].[sqInserSupplier] 'Merelin','(093)798-81-28','merelin@mail.com','Makovieia 45/1'
EXEC [dbo].[sqInserSupplier] 'Ashot','(097)564-53-22','ashot@mail.com','Generala Shuprunku 45/2'
EXEC [dbo].[sqInserSupplier] 'Haizenberg','(096)342-31-23','qweyer@mail.com','Lesia Ukrainka 65'
GO

--->Supply
EXEC [dbo].[spInserSupply] '1A/00002',200,10,'K2Company'
EXEC [dbo].[spInserSupply] '1A/00001',30,20,'Haizenberg'
EXEC [dbo].[spInserSupply] '1A/00002',105,25,'Ashot'
EXEC [dbo].[spInserSupply] '1B/00001',200,25,'Ashot'
EXEC [dbo].[spInserSupply] '1B/00002',40,25,'Kindrat And Family'
EXEC [dbo].[spInserSupply] '1B/00002',70,25,'Ashot'
EXEC [dbo].[spInserSupply] '1B/00003',30,25,'Merelin'
EXEC [dbo].[spInserSupply] '1B/00004',45,25,'MSGoodCloths'
GO

