CREATE TABLE [dbo].[todolist] (
    [Id]      [INT]  IDENTITY (1, 1) NOT NULL,
    [Content] [NVARCHAR] (MAX) NOT NULL,
    [Date of Entry] [DATE] NOT NULL DEFAULT 00/00/0000, 
    CONSTRAINT [PK_todolist] PRIMARY KEY CLUSTERED ([Id] ASC)
);

