﻿
-- ----------------------------------------------------------------------------------------------------------------
-- Generated by LLBLGen Pro v3.5  Build: December 11th, 2012
-- SQL Server 2000/2005/2008/2008R2/2012/Express DDL Script generated from project: NinjaSoftware.TrzisteNovca
-- Project filename: G:\Documents\Visual Studio 2010\Projects\NinjaSoftware.TrzisteNovca\NinjaSoftware.TrzisteNovca.llblgenproj
-- Script generated on: 24-tra-2013 16:31.33
--
-- This is a Create script for creating a NEW data model. If you want DDL SQL for updating an existing model,
-- please create an Update script instead. 
--
-- This script might create schemas, which requires you to assign a proper user to the schema. Adjust the CREATE SCHEMA
-- statements below, if any, to avoid errors at runtime. Schemas aren't dropped in the DROP section.
--
--      >>>>> WARNING <<<<<
--      This is a CREATE script, with DROP statements for the existing tables, foreign keys and other constraints
--      This means that existing tables, data, constraints and other elements in the catalog/schemas addressed
--      are deleted. Use this Create script only to create new schemas with tables/constraints and other elements.
--
-- ----------------------------------------------------------------------------------------------------------------
-- ###############################################################################################################
-- DROP statements for existing elements. 
-- ###############################################################################################################
-- DROP statements for dropping existing elements with the same names as the ones created are commented out below. 
-- If you want to enable these statements for DROPping the existing elements first (which will remove all the data
-- in these existing elements), uncomment these statements by removing the two comment markers /* and */

-- Remove the comment marker on the NEXT line to enable DROP statements to remove existing elements
/* 

USE [atjanmcs301107hr2706_tn]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- DROP Foreign keys
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[AuditInfo] DROP CONSTRAINT [FK_56ed3d44496bd1deb89aebbd528]
GO

ALTER TABLE [dbo].[AuditInfo] DROP CONSTRAINT [FK_cde33334db28c14fa63323491b8]
GO

ALTER TABLE [dbo].[AuditInfo] DROP CONSTRAINT [FK_d1b51b94d6894675b65b18ccd0f]
GO

ALTER TABLE [dbo].[Error] DROP CONSTRAINT [FK_ab4fe0247e582ce86e6abe92334]
GO

ALTER TABLE [dbo].[HtmlPage] DROP CONSTRAINT [FK_e6dee4747d780888910abb6d8fd]
GO

ALTER TABLE [dbo].[Sudionik] DROP CONSTRAINT [FK_ec0250d4490984d91316ea62eab]
GO

ALTER TABLE [dbo].[TrgovanjeStavka] DROP CONSTRAINT [FK_19da4ca4001a005135d8dfe21a6]
GO

ALTER TABLE [dbo].[TrgovanjeStavka] DROP CONSTRAINT [FK_5baa8394c8c809c80f23bdb291e]
GO

ALTER TABLE [dbo].[TrgovanjeStavka] DROP CONSTRAINT [FK_7b4eb684576806c575613e1514c]
GO

ALTER TABLE [dbo].[TrgovanjeStavkaHnb] DROP CONSTRAINT [FK_31f714f4d9b981f0935f11920c9]
GO

ALTER TABLE [dbo].[TrgovanjeStavkaHnb] DROP CONSTRAINT [FK_fc65ac84afc842c617e89b47646]
GO

ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_a36527a479ea6a74d40fc5b5244]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- DROP tables for schema 'dbo' 
-- ----------------------------------------------------------------------------------------------------------------

DROP TABLE [dbo].[AuditInfo]
GO

DROP TABLE [dbo].[AuditInfoActionTypeRo]
GO

DROP TABLE [dbo].[EntityRo]
GO

DROP TABLE [dbo].[Error]
GO

DROP TABLE [dbo].[HtmlPage]
GO

DROP TABLE [dbo].[KamatnaStopaHnb]
GO

DROP TABLE [dbo].[RepoAukcija]
GO

DROP TABLE [dbo].[RoleRo]
GO

DROP TABLE [dbo].[SistemskaInstancaPodatakaRo]
GO

DROP TABLE [dbo].[Sudionik]
GO

DROP TABLE [dbo].[SudionikGrupaRo]
GO

DROP TABLE [dbo].[TrgovanjeGlava]
GO

DROP TABLE [dbo].[TrgovanjeGlavaHnb]
GO

DROP TABLE [dbo].[TrgovanjeStavka]
GO

DROP TABLE [dbo].[TrgovanjeStavkaHnb]
GO

DROP TABLE [dbo].[TrgovanjeVrstaRo]
GO

DROP TABLE [dbo].[User]
GO

DROP TABLE [dbo].[ValutaRo]
GO

DROP TABLE [dbo].[ZakljuceniMjesec]
GO
*/
-- Remove the comment marker on the PREVIOUS line to enable DROP statements to remove existing elements

-- ###############################################################################################################
-- Create statements for catalogs, schemas, tables and sequences
-- ###############################################################################################################
-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'atjanmcs301107hr2706_tn'
-- ----------------------------------------------------------------------------------------------------------------

USE master
GO
CREATE DATABASE [atjanmcs301107hr2706_tn] /* ON PRIMARY (NAME=atjanmcs301107hr2706_tn_dat, FILENAME='c:\mycatalogs\atjanmcs301107hr2706_tn.mdf', SIZE=10MB) */
GO


USE [atjanmcs301107hr2706_tn]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- Schema 'dbo'
-- ----------------------------------------------------------------------------------------------------------------

-- -------[ Tables ]-----------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[AuditInfo] 
(
	[ActionDateTime] [datetime] NOT NULL, 
	[AuditInfoActionTypeId] [bigint] NOT NULL, 
	[AuditInfoId] [bigint] IDENTITY (1,1) NOT NULL, 
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[EntityId] [bigint] NOT NULL, 
	[JsonData] [nvarchar] (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[PrimaryKeyValue] [bigint] NOT NULL, 
	[UserId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AuditInfoActionTypeRo] 
(
	[AuditInfoActionTypeId] [bigint] NOT NULL, 
	[Code] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Name] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EntityRo] 
(
	[Code] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[EntityId] [bigint] NOT NULL, 
	[Name] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Error] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[ErrorDateTime] [datetime] NOT NULL, 
	[ErrorId] [bigint] IDENTITY (1,1) NOT NULL, 
	[Message] [nvarchar] (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[ParentErrorId] [bigint] NULL, 
	[StackTrace] [nvarchar] (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[HtmlPage] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Html] [nvarchar] (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[HtmlPageId] [bigint] IDENTITY (1,1) NOT NULL, 
	[SistemskaInstancaPodatakaId] [bigint] NULL, 
	[Name] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[KamatnaStopaHnb] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Depozit] [decimal] (6, 2) NOT NULL, 
	[Eskontna] [decimal] (6, 2) NOT NULL, 
	[KamatnaStopaHnbId] [bigint] NOT NULL, 
	[LombarniKredit] [decimal] (6, 2) NOT NULL, 
	[Pricuva] [decimal] (6, 2) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RepoAukcija] 
(
	[BrojAukcije] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[DatumAukcije] [datetime] NOT NULL, 
	[DatumReotkupa] [datetime] NULL, 
	[FiksnaRepoStopa] [decimal] (5, 2) NULL, 
	[GranicnaRepoStopa] [decimal] (5, 2) NULL, 
	[KoeficijentRaspodjele] [decimal] (5, 2) NULL, 
	[NajnizaRepoStopa] [decimal] (5, 2) NULL, 
	[NajvisaRepoStopa] [decimal] (5, 2) NULL, 
	[OdbijenePonudeUkupno] [decimal] (10, 2) NULL, 
	[PostoPrihvacenihPoGranicnojStopi] [decimal] (5, 2) NULL, 
	[PrihvacenePonudeUkupno] [decimal] (10, 2) NULL, 
	[PristiglePonudeUkupno] [decimal] (10, 2) NULL, 
	[RepoAukcijaId] [bigint] IDENTITY (1,1) NOT NULL, 
	[VaganaRepoStopa] [decimal] (5, 2) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RoleRo] 
(
	[Code] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Name] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[RoleId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SistemskaInstancaPodatakaRo] 
(
	[Code] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[SistemskaInstancaPodatakaId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Sudionik] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Naziv] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[SudionikGrupaId] [bigint] NOT NULL, 
	[SudionikId] [bigint] IDENTITY (1,1) NOT NULL, 
	[WebAdresa] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SudionikGrupaRo] 
(
	[Code] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[SudionikGrupaId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TrgovanjeGlava] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Datum] [datetime] NOT NULL, 
	[Komentar] [nvarchar] (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[TrgovanjeGlavaId] [bigint] IDENTITY (1,1) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TrgovanjeGlavaHnb] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Datum] [datetime] NOT NULL, 
	[TrgovanjeGlavaHnbId] [bigint] IDENTITY (1,1) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TrgovanjeStavka] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Ponuda] [decimal] (18, 2) NOT NULL, 
	[PonudaDodatak] [decimal] (10, 4) NOT NULL, 
	[Potraznja] [decimal] (18, 2) NOT NULL, 
	[PotraznjaDodatak] [decimal] (10, 4) NOT NULL, 
	[Promet] [decimal] (18, 2) NOT NULL, 
	[PrometDodatak] [decimal] (10, 4) NOT NULL, 
	[TrgovanjeGlavaId] [bigint] NOT NULL, 
	[TrgovanjeStavkaId] [bigint] IDENTITY (1,1) NOT NULL, 
	[TrgovanjeVrstaId] [bigint] NOT NULL, 
	[ValutaId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TrgovanjeStavkaHnb] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[IznosMilijuniKn] [decimal] (10, 2) NOT NULL, 
	[KamatnaStopa] [decimal] (6, 2) NOT NULL, 
	[TrgovanjeGlavaHnbId] [bigint] NOT NULL, 
	[TrgovanjeStavkaHnbId] [bigint] IDENTITY (1,1) NOT NULL, 
	[TrgovanjeVrstaId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TrgovanjeVrstaRo] 
(
	[Code] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[SifraSlog] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[TrgovanjeVrstaId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[User] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Password] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[RoleId] [bigint] NOT NULL, 
	[UserId] [bigint] IDENTITY (1,1) NOT NULL, 
	[Username] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ValutaRo] 
(
	[Code] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[SifraSlog] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[ValutaId] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ZakljuceniMjesec] 
(
	[ConcurrencyGuid] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Godina] [int] NOT NULL, 
	[Mjesec] [int] NOT NULL, 
	[ZakljuceniMjesecId] [bigint] IDENTITY (1,1) NOT NULL 
) ON [PRIMARY]
GO

-- ###############################################################################################################
-- Create statements for Primary key constraints, Foreign key constraints and Unique constraints
-- ###############################################################################################################
-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'atjanmcs301107hr2706_tn'
-- ----------------------------------------------------------------------------------------------------------------

USE [atjanmcs301107hr2706_tn]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- Primary Key constraints for schema 'dbo'
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[AuditInfo] WITH NOCHECK 
	ADD CONSTRAINT [PK_5fbe1ce4206a3bfa45845343663] PRIMARY KEY CLUSTERED 
	( 
		[AuditInfoId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AuditInfoActionTypeRo] WITH NOCHECK 
	ADD CONSTRAINT [PK_057e91646e3a0b69e685e56664f] PRIMARY KEY CLUSTERED 
	( 
		[AuditInfoActionTypeId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EntityRo] WITH NOCHECK 
	ADD CONSTRAINT [PK_6a8c30d43cbb48a28f4d88e9ae8] PRIMARY KEY CLUSTERED 
	( 
		[EntityId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Error] WITH NOCHECK 
	ADD CONSTRAINT [PK_345c01a4dadaa2743b182e09867] PRIMARY KEY CLUSTERED 
	( 
		[ErrorId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HtmlPage] WITH NOCHECK 
	ADD CONSTRAINT [PK_ee3a00f4ebbbf79025b4a9e0f54] PRIMARY KEY CLUSTERED 
	( 
		[HtmlPageId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[KamatnaStopaHnb] WITH NOCHECK 
	ADD CONSTRAINT [PK_4a82eb34eec9863e0682ad3b5d8] PRIMARY KEY CLUSTERED 
	( 
		[KamatnaStopaHnbId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RepoAukcija] WITH NOCHECK 
	ADD CONSTRAINT [PK_98fd1e245f4ac2cb3381fe9ef20] PRIMARY KEY CLUSTERED 
	( 
		[RepoAukcijaId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RoleRo] WITH NOCHECK 
	ADD CONSTRAINT [PK_170de0f44939388fcb1bce06ff0] PRIMARY KEY CLUSTERED 
	( 
		[RoleId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SistemskaInstancaPodatakaRo] WITH NOCHECK 
	ADD CONSTRAINT [PK_49d125f47db8c80a1205304e1eb] PRIMARY KEY CLUSTERED 
	( 
		[SistemskaInstancaPodatakaId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sudionik] WITH NOCHECK 
	ADD CONSTRAINT [PK_d38dda5463dbb7a94aa2fa30373] PRIMARY KEY CLUSTERED 
	( 
		[SudionikId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SudionikGrupaRo] WITH NOCHECK 
	ADD CONSTRAINT [PK_e0c1c9e4416b472cfecd34697b8] PRIMARY KEY CLUSTERED 
	( 
		[SudionikGrupaId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrgovanjeGlava] WITH NOCHECK 
	ADD CONSTRAINT [PK_e70c3a9430685d1ef18a66c72b7] PRIMARY KEY CLUSTERED 
	( 
		[TrgovanjeGlavaId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrgovanjeGlavaHnb] WITH NOCHECK 
	ADD CONSTRAINT [PK_b7551c04a4bb25446764e1fd434] PRIMARY KEY CLUSTERED 
	( 
		[TrgovanjeGlavaHnbId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrgovanjeStavka] WITH NOCHECK 
	ADD CONSTRAINT [PK_b48c25d42bbbd667ce3f02e792c] PRIMARY KEY CLUSTERED 
	( 
		[TrgovanjeStavkaId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrgovanjeStavkaHnb] WITH NOCHECK 
	ADD CONSTRAINT [PK_964d2cd4de99af6cd17e1c40f50] PRIMARY KEY CLUSTERED 
	( 
		[TrgovanjeStavkaHnbId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrgovanjeVrstaRo] WITH NOCHECK 
	ADD CONSTRAINT [PK_3cca2ad49d385ff03e172ae6088] PRIMARY KEY CLUSTERED 
	( 
		[TrgovanjeVrstaId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[User] WITH NOCHECK 
	ADD CONSTRAINT [PK_24218b24e158ab08eb275b53ab2] PRIMARY KEY CLUSTERED 
	( 
		[UserId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ValutaRo] WITH NOCHECK 
	ADD CONSTRAINT [PK_11cce9f433e95c5a2f16f294f4f] PRIMARY KEY CLUSTERED 
	( 
		[ValutaId] 
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ZakljuceniMjesec] WITH NOCHECK 
	ADD CONSTRAINT [PK_1cec7544bc0b39099411671f82a] PRIMARY KEY CLUSTERED 
	( 
		[ZakljuceniMjesecId] 
	) ON [PRIMARY]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- Unique constraints for schema 'dbo'
-- ----------------------------------------------------------------------------------------------------------------
-- ----------------------------------------------------------------------------------------------------------------
-- All foreign Key constraints
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[AuditInfo] 
	ADD CONSTRAINT [FK_56ed3d44496bd1deb89aebbd528] FOREIGN KEY
	(
		[EntityId] 
	)
	REFERENCES [dbo].[EntityRo]
	(
		[EntityId] 
	)
GO

ALTER TABLE [dbo].[AuditInfo] 
	ADD CONSTRAINT [FK_cde33334db28c14fa63323491b8] FOREIGN KEY
	(
		[AuditInfoActionTypeId] 
	)
	REFERENCES [dbo].[AuditInfoActionTypeRo]
	(
		[AuditInfoActionTypeId] 
	)
GO

ALTER TABLE [dbo].[AuditInfo] 
	ADD CONSTRAINT [FK_d1b51b94d6894675b65b18ccd0f] FOREIGN KEY
	(
		[UserId] 
	)
	REFERENCES [dbo].[User]
	(
		[UserId] 
	)
GO

ALTER TABLE [dbo].[Error] 
	ADD CONSTRAINT [FK_ab4fe0247e582ce86e6abe92334] FOREIGN KEY
	(
		[ParentErrorId] 
	)
	REFERENCES [dbo].[Error]
	(
		[ErrorId] 
	)
GO

ALTER TABLE [dbo].[HtmlPage] 
	ADD CONSTRAINT [FK_e6dee4747d780888910abb6d8fd] FOREIGN KEY
	(
		[SistemskaInstancaPodatakaId] 
	)
	REFERENCES [dbo].[SistemskaInstancaPodatakaRo]
	(
		[SistemskaInstancaPodatakaId] 
	)
GO

ALTER TABLE [dbo].[Sudionik] 
	ADD CONSTRAINT [FK_ec0250d4490984d91316ea62eab] FOREIGN KEY
	(
		[SudionikGrupaId] 
	)
	REFERENCES [dbo].[SudionikGrupaRo]
	(
		[SudionikGrupaId] 
	)
GO

ALTER TABLE [dbo].[TrgovanjeStavka] 
	ADD CONSTRAINT [FK_19da4ca4001a005135d8dfe21a6] FOREIGN KEY
	(
		[ValutaId] 
	)
	REFERENCES [dbo].[ValutaRo]
	(
		[ValutaId] 
	)
GO

ALTER TABLE [dbo].[TrgovanjeStavka] 
	ADD CONSTRAINT [FK_5baa8394c8c809c80f23bdb291e] FOREIGN KEY
	(
		[TrgovanjeGlavaId] 
	)
	REFERENCES [dbo].[TrgovanjeGlava]
	(
		[TrgovanjeGlavaId] 
	)
GO

ALTER TABLE [dbo].[TrgovanjeStavka] 
	ADD CONSTRAINT [FK_7b4eb684576806c575613e1514c] FOREIGN KEY
	(
		[TrgovanjeVrstaId] 
	)
	REFERENCES [dbo].[TrgovanjeVrstaRo]
	(
		[TrgovanjeVrstaId] 
	)
GO

ALTER TABLE [dbo].[TrgovanjeStavkaHnb] 
	ADD CONSTRAINT [FK_31f714f4d9b981f0935f11920c9] FOREIGN KEY
	(
		[TrgovanjeGlavaHnbId] 
	)
	REFERENCES [dbo].[TrgovanjeGlavaHnb]
	(
		[TrgovanjeGlavaHnbId] 
	)
GO

ALTER TABLE [dbo].[TrgovanjeStavkaHnb] 
	ADD CONSTRAINT [FK_fc65ac84afc842c617e89b47646] FOREIGN KEY
	(
		[TrgovanjeVrstaId] 
	)
	REFERENCES [dbo].[TrgovanjeVrstaRo]
	(
		[TrgovanjeVrstaId] 
	)
GO

ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [FK_a36527a479ea6a74d40fc5b5244] FOREIGN KEY
	(
		[RoleId] 
	)
	REFERENCES [dbo].[RoleRo]
	(
		[RoleId] 
	)
GO
