USE [POSTDATA]
GO
/****** Object:  Trigger [dbo].[delete_post]    Script Date: 2023-08-29 11:12:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[delete_post] on [dbo].[Post] after update as
begin
	declare @PostID int
	declare @UserID int
	select @PostID = ID from inserted
	select @UserID = LastUpdateUserID from inserted
	if update(isDeleted)
	begin
	update PostTag set isDeleted = 1, DeletedDate = GETDATE(), LastUpdateUserID = @UserID, LastUpdateDate = GETDATE() where PostID = @PostID
	update Comment set isDeleted = 1, DeletedDate = GETDATE(), LastUpdateUserID = @UserID, LastUpdateDate = GETDATE() where PostID = @PostID
end
end