CREATE PROCEDURE spDeleteItem (
@ItemId int)
AS
BEGIN
DELETE FROM Txn_InventoryItems WHERE ItemId = @ItemId
END