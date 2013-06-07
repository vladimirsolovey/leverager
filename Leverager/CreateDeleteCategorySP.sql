ALTER PROCEDURE leverager.DeleteCategory 
    (
	@categoryID INT
	)
AS
BEGIN
	DELETE CategoryCategories WHERE ParentId=@categoryID
	DELETE CategoryCategories WHERE ChildId=@categoryID
	DELETE Category WHERE ID=@categoryID
END
