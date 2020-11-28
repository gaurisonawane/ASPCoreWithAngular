
CREATE PROCEDURE spInsertItem (
@Name nvarchar(50),
@Description nvarchar(100),
@Price decimal(10,2))
	
AS
BEGIN
	insert into Txn_InventoryItems (Name, Description, Price)
	Values (@Name, @Description, @Price)

END
GO
