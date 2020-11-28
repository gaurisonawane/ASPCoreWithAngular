CREATE PROCEDURE spGetItemDetails (
@ItemId int)
AS
BEGIN
SELECT * FROM Txn_InventoryItems
WHERE ItemId = @ItemId
END