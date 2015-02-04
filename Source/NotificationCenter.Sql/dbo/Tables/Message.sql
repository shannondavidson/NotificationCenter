CREATE TABLE [dbo].[Message] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [From]        VARCHAR (100) NOT NULL,
    [To]          VARCHAR (100) NOT NULL,
    [Subject]     VARCHAR (100) NULL,
    [Body]        VARCHAR (MAX) NOT NULL,
    [_CreateDate] DATETIME      CONSTRAINT [DF_Message__CreateDate] DEFAULT (getdate()) NOT NULL,
    [_EditDate]   DATETIME      CONSTRAINT [DF_Message__EditDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([Id] ASC)
);

