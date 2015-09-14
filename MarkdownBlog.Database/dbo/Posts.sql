CREATE TABLE [dbo].[Posts]
(
	[Id]			INT				NOT NULL PRIMARY KEY,
	[Title]			NVARCHAR(100)	NOT NULL,
	[Content]		VARCHAR(MAX)	NULL,
	[CreatedDate]	DATE			NOT NULL
)