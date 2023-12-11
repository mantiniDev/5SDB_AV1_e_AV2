/*
Script de implantação para Alunos

Este código foi gerado por uma ferramenta.
As alterações feitas nesse arquivo poderão causar comportamento incorreto e serão perdidas se
o código for gerado novamente.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Alunos"
:setvar DefaultFilePrefix "Alunos"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detecta o modo SQLCMD e desabilita a execução do script se o modo SQLCMD não tiver suporte.
Para reabilitar o script após habilitar o modo SQLCMD, execute o comando a seguir:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'O modo SQLCMD deve ser habilitado para executar esse script com êxito.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
O tipo da coluna daNasc na tabela [dbo].[escola] é  NVARCHAR (50) NULL no momento, mas está sendo alterado para  VARCHAR (50) NULL. Pode ocorrer perda de dados e a implantação poderá falhar se a coluna contiver dados incompatíveis com o tipo  VARCHAR (50) NULL.

O tipo da coluna email na tabela [dbo].[escola] é  NVARCHAR (50) NULL no momento, mas está sendo alterado para  VARCHAR (50) NULL. Pode ocorrer perda de dados e a implantação poderá falhar se a coluna contiver dados incompatíveis com o tipo  VARCHAR (50) NULL.

O tipo da coluna endereço na tabela [dbo].[escola] é  NVARCHAR (50) NULL no momento, mas está sendo alterado para  VARCHAR (50) NULL. Pode ocorrer perda de dados e a implantação poderá falhar se a coluna contiver dados incompatíveis com o tipo  VARCHAR (50) NULL.

O tipo da coluna Id na tabela [dbo].[escola] é  NVARCHAR (50) NOT NULL no momento, mas está sendo alterado para  VARCHAR (50) NOT NULL. Pode ocorrer perda de dados e a implantação poderá falhar se a coluna contiver dados incompatíveis com o tipo  VARCHAR (50) NOT NULL.

O tipo da coluna matricula na tabela [dbo].[escola] é  NVARCHAR (50) NULL no momento, mas está sendo alterado para  VARCHAR (50) NULL. Pode ocorrer perda de dados e a implantação poderá falhar se a coluna contiver dados incompatíveis com o tipo  VARCHAR (50) NULL.

O tipo da coluna nome na tabela [dbo].[escola] é  NVARCHAR (50) NULL no momento, mas está sendo alterado para  VARCHAR (50) NULL. Pode ocorrer perda de dados e a implantação poderá falhar se a coluna contiver dados incompatíveis com o tipo  VARCHAR (50) NULL.

O tipo da coluna sexo na tabela [dbo].[escola] é  NVARCHAR (50) NULL no momento, mas está sendo alterado para  VARCHAR (50) NULL. Pode ocorrer perda de dados e a implantação poderá falhar se a coluna contiver dados incompatíveis com o tipo  VARCHAR (50) NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[escola])
    RAISERROR (N'Linhas foram detectadas. A atualização de esquema está sendo encerrada porque pode ocorrer perda de dados.', 16, 127) WITH NOWAIT

GO
PRINT N'Iniciando a recompilação da tabela [dbo].[escola]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_escola] (
    [Id]        VARCHAR (50) NOT NULL,
    [matricula] VARCHAR (50) NULL,
    [nome]      VARCHAR (50) NULL,
    [daNasc]    VARCHAR (50) NULL,
    [sexo]      VARCHAR (50) NULL,
    [email]     VARCHAR (50) NULL,
    [endereço]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[escola])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_escola] ([Id], [matricula], [nome], [daNasc], [sexo], [email], [endereço])
        SELECT   [Id],
                 [matricula],
                 [nome],
                 [daNasc],
                 [sexo],
                 [email],
                 [endereço]
        FROM     [dbo].[escola]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[escola];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_escola]', N'escola';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Atualização concluída.';


GO
