
-- --------------------------------------------------
-- Date Created: 02/20/2010 10:34:08
-- Generated from EDMX file: F:\Users\Júlio\Documents\Visual Studio 10\Projects\IMJ\Web\IMJWeb.DAO.EF\ModeloMercadorias.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
SET ANSI_NULLS ON;
GO

USE [IMJWeb]
GO
IF SCHEMA_ID(N'IMJWeb') IS NULL EXECUTE(N'CREATE SCHEMA [IMJWeb]')
GO

-- --------------------------------------------------
-- Dropping existing FK constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[IMJWeb].[FK_Fotos_Mercadorias]', 'F') IS NOT NULL
    ALTER TABLE [IMJWeb].[Fotos] DROP CONSTRAINT [FK_Fotos_Mercadorias]
GO
IF OBJECT_ID(N'[IMJWeb].[FK_Indices_Mercadorias]', 'F') IS NOT NULL
    ALTER TABLE [IMJWeb].[Indices] DROP CONSTRAINT [FK_Indices_Mercadorias]
GO
IF OBJECT_ID(N'[IMJWeb].[FK_MercadoriaGrupo_Grupos]', 'F') IS NOT NULL
    ALTER TABLE [IMJWeb].[MercadoriaGrupo] DROP CONSTRAINT [FK_MercadoriaGrupo_Grupos]
GO
IF OBJECT_ID(N'[IMJWeb].[FK_MercadoriaGrupo_Mercadorias]', 'F') IS NOT NULL
    ALTER TABLE [IMJWeb].[MercadoriaGrupo] DROP CONSTRAINT [FK_MercadoriaGrupo_Mercadorias]
GO
IF OBJECT_ID(N'[IMJWeb].[FK_Mercadorias_Catalogos]', 'F') IS NOT NULL
    ALTER TABLE [IMJWeb].[Mercadorias] DROP CONSTRAINT [FK_Mercadorias_Catalogos]
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Grupos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioGrupo] DROP CONSTRAINT [FK_UsuarioGrupo_Grupos]
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Usuarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioGrupo] DROP CONSTRAINT [FK_UsuarioGrupo_Usuarios]
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Grupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grupos];
GO
IF OBJECT_ID(N'[dbo].[UsuarioGrupo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioGrupo];
GO
IF OBJECT_ID(N'[IMJWeb].[Catalogos]', 'U') IS NOT NULL
    DROP TABLE [IMJWeb].[Catalogos];
GO
IF OBJECT_ID(N'[IMJWeb].[Fotos]', 'U') IS NOT NULL
    DROP TABLE [IMJWeb].[Fotos];
GO
IF OBJECT_ID(N'[IMJWeb].[Indices]', 'U') IS NOT NULL
    DROP TABLE [IMJWeb].[Indices];
GO
IF OBJECT_ID(N'[IMJWeb].[MercadoriaGrupo]', 'U') IS NOT NULL
    DROP TABLE [IMJWeb].[MercadoriaGrupo];
GO
IF OBJECT_ID(N'[IMJWeb].[Mercadorias]', 'U') IS NOT NULL
    DROP TABLE [IMJWeb].[Mercadorias];
GO
IF OBJECT_ID(N'[IMJWeb].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [IMJWeb].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Catalogos'
CREATE TABLE [IMJWeb].[Catalogos] (
    [DataAlteracao] datetime  NOT NULL,
    [DataCriacao] datetime  NOT NULL,
    [IDCatalogo] bigint  NOT NULL,
    [IMJ_IDAlbum] bigint  NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO
-- Creating table 'Fotos'
CREATE TABLE [IMJWeb].[Fotos] (
    [IDFoto] bigint IDENTITY(1,1) NOT NULL,
    [Largura] int  NOT NULL,
    [Altura] int  NOT NULL,
    [Imagem] varbinary(max)  NOT NULL,
    [IMJ_IDFoto] bigint  NULL,
    [Mercadoria_Referencia] char(12)  NOT NULL
);
GO
-- Creating table 'Mercadorias'
CREATE TABLE [IMJWeb].[Mercadorias] (
    [DataCriacao] datetime  NOT NULL,
    [Descricao] nvarchar(max)  NULL,
    [Peso] decimal(18,0)  NULL,
    [Referencia] char(12)  NOT NULL,
    [Serie] bigint IDENTITY(1,1) NOT NULL,
    [Catalogo_IDCatalogo] bigint  NOT NULL
);
GO
-- Creating table 'Usuarios'
CREATE TABLE [IMJWeb].[Usuarios] (
    [DataCriacao] datetime  NOT NULL,
    [IDUsuario] bigint  NOT NULL,
    [IMJ_IDPessoa] bigint  NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Senha] nvarchar(max)  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [IDTabela] int  NULL
);
GO
-- Creating table 'Indices'
CREATE TABLE [IMJWeb].[Indices] (
    [Referencia] char(12)  NOT NULL,
    [Indice] decimal(18,4)  NOT NULL,
    [IDTabela] int  NOT NULL
);
GO
-- Creating table 'Grupos'
CREATE TABLE [IMJWeb].[Grupos] (
    [IDGrupo] bigint IDENTITY(1,1) NOT NULL,
    [Nome] varchar(max)  NOT NULL
);
GO
-- Creating table 'MercadoriaGrupo'
CREATE TABLE [IMJWeb].[MercadoriaGrupo] (
    [Grupos_IDGrupo] bigint  NOT NULL,
    [Mercadorias_Referencia] char(12)  NOT NULL
);
GO
-- Creating table 'UsuarioGrupo'
CREATE TABLE [IMJWeb].[UsuarioGrupo] (
    [Grupos_IDGrupo] bigint  NOT NULL,
    [Usuarios_IDUsuario] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all Primary Key Constraints
-- --------------------------------------------------

-- Creating primary key on [IDCatalogo] in table 'Catalogos'
ALTER TABLE [IMJWeb].[Catalogos] WITH NOCHECK 
ADD CONSTRAINT [PK_Catalogos]
    PRIMARY KEY CLUSTERED ([IDCatalogo] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [IDFoto] in table 'Fotos'
ALTER TABLE [IMJWeb].[Fotos] WITH NOCHECK 
ADD CONSTRAINT [PK_Fotos]
    PRIMARY KEY CLUSTERED ([IDFoto] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Referencia] in table 'Mercadorias'
ALTER TABLE [IMJWeb].[Mercadorias] WITH NOCHECK 
ADD CONSTRAINT [PK_Mercadorias]
    PRIMARY KEY CLUSTERED ([Referencia] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [IDUsuario] in table 'Usuarios'
ALTER TABLE [IMJWeb].[Usuarios] WITH NOCHECK 
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([IDUsuario] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Referencia], [IDTabela] in table 'Indices'
ALTER TABLE [IMJWeb].[Indices] WITH NOCHECK 
ADD CONSTRAINT [PK_Indices]
    PRIMARY KEY CLUSTERED ([Referencia], [IDTabela] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [IDGrupo] in table 'Grupos'
ALTER TABLE [IMJWeb].[Grupos] WITH NOCHECK 
ADD CONSTRAINT [PK_Grupos]
    PRIMARY KEY CLUSTERED ([IDGrupo] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Grupos_IDGrupo], [Mercadorias_Referencia] in table 'MercadoriaGrupo'
ALTER TABLE [IMJWeb].[MercadoriaGrupo] WITH NOCHECK 
ADD CONSTRAINT [PK_MercadoriaGrupo]
    PRIMARY KEY NONCLUSTERED ([Grupos_IDGrupo], [Mercadorias_Referencia] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Grupos_IDGrupo], [Usuarios_IDUsuario] in table 'UsuarioGrupo'
ALTER TABLE [IMJWeb].[UsuarioGrupo] WITH NOCHECK 
ADD CONSTRAINT [PK_UsuarioGrupo]
    PRIMARY KEY NONCLUSTERED ([Grupos_IDGrupo], [Usuarios_IDUsuario] ASC)
    ON [PRIMARY]
GO

-- --------------------------------------------------
-- Creating all Foreign Key Constraints
-- --------------------------------------------------

-- Creating foreign key on [Catalogo_IDCatalogo] in table 'Mercadorias'
ALTER TABLE [IMJWeb].[Mercadorias] WITH NOCHECK 
ADD CONSTRAINT [FK_Mercadorias_Catalogos]
    FOREIGN KEY ([Catalogo_IDCatalogo])
    REFERENCES [IMJWeb].[Catalogos]
        ([IDCatalogo])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Mercadoria_Referencia] in table 'Fotos'
ALTER TABLE [IMJWeb].[Fotos] WITH NOCHECK 
ADD CONSTRAINT [FK_Fotos_Mercadorias]
    FOREIGN KEY ([Mercadoria_Referencia])
    REFERENCES [IMJWeb].[Mercadorias]
        ([Referencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Referencia] in table 'Indices'
ALTER TABLE [IMJWeb].[Indices] WITH NOCHECK 
ADD CONSTRAINT [FK_Indices_Mercadorias]
    FOREIGN KEY ([Referencia])
    REFERENCES [IMJWeb].[Mercadorias]
        ([Referencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Grupos_IDGrupo] in table 'MercadoriaGrupo'
ALTER TABLE [IMJWeb].[MercadoriaGrupo] WITH NOCHECK 
ADD CONSTRAINT [FK_MercadoriaGrupo_Grupos]
    FOREIGN KEY ([Grupos_IDGrupo])
    REFERENCES [IMJWeb].[Grupos]
        ([IDGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Mercadorias_Referencia] in table 'MercadoriaGrupo'
ALTER TABLE [IMJWeb].[MercadoriaGrupo] WITH NOCHECK 
ADD CONSTRAINT [FK_MercadoriaGrupo_Mercadoria]
    FOREIGN KEY ([Mercadorias_Referencia])
    REFERENCES [IMJWeb].[Mercadorias]
        ([Referencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Grupos_IDGrupo] in table 'UsuarioGrupo'
ALTER TABLE [IMJWeb].[UsuarioGrupo] WITH NOCHECK 
ADD CONSTRAINT [FK_UsuarioGrupo_Grupo]
    FOREIGN KEY ([Grupos_IDGrupo])
    REFERENCES [IMJWeb].[Grupos]
        ([IDGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Usuarios_IDUsuario] in table 'UsuarioGrupo'
ALTER TABLE [IMJWeb].[UsuarioGrupo] WITH NOCHECK 
ADD CONSTRAINT [FK_UsuarioGrupo_Usuario]
    FOREIGN KEY ([Usuarios_IDUsuario])
    REFERENCES [IMJWeb].[Usuarios]
        ([IDUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------