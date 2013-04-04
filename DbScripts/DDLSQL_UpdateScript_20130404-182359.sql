﻿
-- ----------------------------------------------------------------------------------------------------------------
-- Generated by LLBLGen Pro v3.5  Build: December 11th, 2012
-- SQL Server 2000/2005/2008/2008R2/2012/Express DDL Script generated from project: NinjaSoftware.TrzisteNovca
-- Project filename: G:\Documents\Visual Studio 2010\Projects\NinjaSoftware.TrzisteNovca\NinjaSoftware.TrzisteNovca.llblgenproj
-- Script generated on: 04-tra-2013 18:23.59
--
-- This is an Update script for updating an existing data model to a newer version. If you want DDL SQL for a new model,
-- please create a Create script instead. 
--
-- This script might create schemas, which requires you to assign a proper user to the schema. Adjust the CREATE SCHEMA
-- statements below, if any, to avoid errors at runtime.
--
-- Please run the scripts in the right order, use the timestamp in the filename and inside this script for that.
-- This script might need adjustment in some statements. You should consider this script as a starting point for
-- upgrading the existing data model.
-- ----------------------------------------------------------------------------------------------------------------
-- ###############################################################################################################
-- Drop constraints referring to elements which are changed in this script (constraints are recreated later on)
-- ###############################################################################################################

USE [atjanmcs301107hr2706_tn]
GO

-- ###############################################################################################################
-- Rename statements
-- ###############################################################################################################

USE [atjanmcs301107hr2706_tn]
GO

-- ###############################################################################################################
-- DROP statements for elements no longer needed or replaced elements.
-- ###############################################################################################################

USE [atjanmcs301107hr2706_tn]
GO

-- ###############################################################################################################
-- ADD statements for new elements (except FK/UC)
-- ###############################################################################################################

USE [atjanmcs301107hr2706_tn]
GO

-- ###############################################################################################################
-- ALTER statements for table fields and ADD statements for new primary key constraints
-- ###############################################################################################################

USE [atjanmcs301107hr2706_tn]
GO

ALTER TABLE [dbo].[HtmlPage] 
	ALTER COLUMN [Name] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
GO

-- ###############################################################################################################
-- ADD statements for new foreign key constraints and unique constraints
-- ###############################################################################################################

USE [atjanmcs301107hr2706_tn]
GO
