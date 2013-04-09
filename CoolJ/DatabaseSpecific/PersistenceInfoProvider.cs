///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.CoolJ.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal static class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass((18 + 0));
			InitAuditInfoEntityMappings();
			InitAuditInfoActionTypeRoEntityMappings();
			InitEntityRoEntityMappings();
			InitErrorEntityMappings();
			InitHtmlPageEntityMappings();
			InitKamatnaStopaHnbEntityMappings();
			InitRepoAukcijaEntityMappings();
			InitRoleRoEntityMappings();
			InitSistemskaInstancaPodatakaRoEntityMappings();
			InitSudionikEntityMappings();
			InitSudionikGrupaRoEntityMappings();
			InitTrgovanjeGlavaEntityMappings();
			InitTrgovanjeGlavaHnbEntityMappings();
			InitTrgovanjeStavkaEntityMappings();
			InitTrgovanjeStavkaHnbEntityMappings();
			InitTrgovanjeVrstaRoEntityMappings();
			InitUserEntityMappings();
			InitValutaRoEntityMappings();

		}


		/// <summary>Inits AuditInfoEntity's mappings</summary>
		private void InitAuditInfoEntityMappings()
		{
			this.AddElementMapping( "AuditInfoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "AuditInfo", 8 );
			this.AddElementFieldMapping( "AuditInfoEntity", "ActionDateTime", "ActionDateTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 0 );
			this.AddElementFieldMapping( "AuditInfoEntity", "AuditInfoActionTypeId", "AuditInfoActionTypeId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "AuditInfoEntity", "AuditInfoId", "AuditInfoId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "AuditInfoEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "AuditInfoEntity", "EntityId", "EntityId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			this.AddElementFieldMapping( "AuditInfoEntity", "JsonData", "JsonData", false, "NVarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "AuditInfoEntity", "PrimaryKeyValue", "PrimaryKeyValue", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 6 );
			this.AddElementFieldMapping( "AuditInfoEntity", "UserId", "UserId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
		}
		/// <summary>Inits AuditInfoActionTypeRoEntity's mappings</summary>
		private void InitAuditInfoActionTypeRoEntityMappings()
		{
			this.AddElementMapping( "AuditInfoActionTypeRoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "AuditInfoActionTypeRo", 3 );
			this.AddElementFieldMapping( "AuditInfoActionTypeRoEntity", "AuditInfoActionTypeId", "AuditInfoActionTypeId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "AuditInfoActionTypeRoEntity", "Code", "Code", false, "NVarChar", 128, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "AuditInfoActionTypeRoEntity", "Name", "Name", false, "NVarChar", 256, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits EntityRoEntity's mappings</summary>
		private void InitEntityRoEntityMappings()
		{
			this.AddElementMapping( "EntityRoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "EntityRo", 3 );
			this.AddElementFieldMapping( "EntityRoEntity", "Code", "Code", false, "NVarChar", 128, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "EntityRoEntity", "EntityId", "EntityId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "EntityRoEntity", "Name", "Name", false, "NVarChar", 256, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits ErrorEntity's mappings</summary>
		private void InitErrorEntityMappings()
		{
			this.AddElementMapping( "ErrorEntity", @"atjanmcs301107hr2706_tn", @"dbo", "Error", 6 );
			this.AddElementFieldMapping( "ErrorEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "ErrorEntity", "ErrorDateTime", "ErrorDateTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			this.AddElementFieldMapping( "ErrorEntity", "ErrorId", "ErrorId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "ErrorEntity", "Message", "Message", false, "NVarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "ErrorEntity", "ParentErrorId", "ParentErrorId", true, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
			this.AddElementFieldMapping( "ErrorEntity", "StackTrace", "StackTrace", true, "NVarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits HtmlPageEntity's mappings</summary>
		private void InitHtmlPageEntityMappings()
		{
			this.AddElementMapping( "HtmlPageEntity", @"atjanmcs301107hr2706_tn", @"dbo", "HtmlPage", 5 );
			this.AddElementFieldMapping( "HtmlPageEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "HtmlPageEntity", "Html", "Html", false, "NVarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "HtmlPageEntity", "HtmlPageId", "HtmlPageId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "HtmlPageEntity", "Name", "Name", false, "NVarChar", 256, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "HtmlPageEntity", "SistemskaInstancaPodatakaId", "SistemskaInstancaPodatakaId", true, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 4 );
		}
		/// <summary>Inits KamatnaStopaHnbEntity's mappings</summary>
		private void InitKamatnaStopaHnbEntityMappings()
		{
			this.AddElementMapping( "KamatnaStopaHnbEntity", @"atjanmcs301107hr2706_tn", @"dbo", "KamatnaStopaHnb", 6 );
			this.AddElementFieldMapping( "KamatnaStopaHnbEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "KamatnaStopaHnbEntity", "Depozit", "Depozit", false, "Decimal", 0, 2, 6, false, "", null, typeof(System.Decimal), 1 );
			this.AddElementFieldMapping( "KamatnaStopaHnbEntity", "Eskontna", "Eskontna", false, "Decimal", 0, 2, 6, false, "", null, typeof(System.Decimal), 2 );
			this.AddElementFieldMapping( "KamatnaStopaHnbEntity", "KamatnaStopaHnbId", "KamatnaStopaHnbId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			this.AddElementFieldMapping( "KamatnaStopaHnbEntity", "LombarniKredit", "LombarniKredit", false, "Decimal", 0, 2, 6, false, "", null, typeof(System.Decimal), 4 );
			this.AddElementFieldMapping( "KamatnaStopaHnbEntity", "Pricuva", "Pricuva", false, "Decimal", 0, 2, 6, false, "", null, typeof(System.Decimal), 5 );
		}
		/// <summary>Inits RepoAukcijaEntity's mappings</summary>
		private void InitRepoAukcijaEntityMappings()
		{
			this.AddElementMapping( "RepoAukcijaEntity", @"atjanmcs301107hr2706_tn", @"dbo", "RepoAukcija", 15 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "BrojAukcije", "BrojAukcije", true, "NVarChar", 20, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "DatumAukcije", "DatumAukcije", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "DatumReotkupa", "DatumReotkupa", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "FiksnaRepoStopa", "FiksnaRepoStopa", true, "Decimal", 0, 2, 5, false, "", null, typeof(System.Decimal), 4 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "GranicnaRepoStopa", "GranicnaRepoStopa", true, "Decimal", 0, 2, 5, false, "", null, typeof(System.Decimal), 5 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "KoeficijentRaspodjele", "KoeficijentRaspodjele", true, "Decimal", 0, 2, 5, false, "", null, typeof(System.Decimal), 6 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "NajnizaRepoStopa", "NajnizaRepoStopa", true, "Decimal", 0, 2, 5, false, "", null, typeof(System.Decimal), 7 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "NajvisaRepoStopa", "NajvisaRepoStopa", true, "Decimal", 0, 2, 5, false, "", null, typeof(System.Decimal), 8 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "OdbijenePonudeUkupno", "OdbijenePonudeUkupno", true, "Decimal", 0, 2, 10, false, "", null, typeof(System.Decimal), 9 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "PostoPrihvacenihPoGranicnojStopi", "PostoPrihvacenihPoGranicnojStopi", true, "Decimal", 0, 2, 5, false, "", null, typeof(System.Decimal), 10 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "PrihvacenePonudeUkupno", "PrihvacenePonudeUkupno", true, "Decimal", 0, 2, 10, false, "", null, typeof(System.Decimal), 11 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "PristiglePonudeUkupno", "PristiglePonudeUkupno", true, "Decimal", 0, 2, 10, false, "", null, typeof(System.Decimal), 12 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "RepoAukcijaId", "RepoAukcijaId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 13 );
			this.AddElementFieldMapping( "RepoAukcijaEntity", "VaganaRepoStopa", "VaganaRepoStopa", true, "Decimal", 0, 2, 5, false, "", null, typeof(System.Decimal), 14 );
		}
		/// <summary>Inits RoleRoEntity's mappings</summary>
		private void InitRoleRoEntityMappings()
		{
			this.AddElementMapping( "RoleRoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "RoleRo", 3 );
			this.AddElementFieldMapping( "RoleRoEntity", "Code", "Code", false, "NVarChar", 128, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "RoleRoEntity", "Name", "Name", false, "NVarChar", 256, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "RoleRoEntity", "RoleId", "RoleId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
		}
		/// <summary>Inits SistemskaInstancaPodatakaRoEntity's mappings</summary>
		private void InitSistemskaInstancaPodatakaRoEntityMappings()
		{
			this.AddElementMapping( "SistemskaInstancaPodatakaRoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "SistemskaInstancaPodatakaRo", 3 );
			this.AddElementFieldMapping( "SistemskaInstancaPodatakaRoEntity", "Code", "Code", false, "NVarChar", 64, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "SistemskaInstancaPodatakaRoEntity", "Name", "Name", false, "NVarChar", 128, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "SistemskaInstancaPodatakaRoEntity", "SistemskaInstancaPodatakaId", "SistemskaInstancaPodatakaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
		}
		/// <summary>Inits SudionikEntity's mappings</summary>
		private void InitSudionikEntityMappings()
		{
			this.AddElementMapping( "SudionikEntity", @"atjanmcs301107hr2706_tn", @"dbo", "Sudionik", 5 );
			this.AddElementFieldMapping( "SudionikEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "SudionikEntity", "Naziv", "Naziv", false, "NVarChar", 256, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "SudionikEntity", "SudionikGrupaId", "SudionikGrupaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "SudionikEntity", "SudionikId", "SudionikId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 3 );
			this.AddElementFieldMapping( "SudionikEntity", "WebAdresa", "WebAdresa", true, "NVarChar", 512, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits SudionikGrupaRoEntity's mappings</summary>
		private void InitSudionikGrupaRoEntityMappings()
		{
			this.AddElementMapping( "SudionikGrupaRoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "SudionikGrupaRo", 3 );
			this.AddElementFieldMapping( "SudionikGrupaRoEntity", "Code", "Code", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "SudionikGrupaRoEntity", "Name", "Name", false, "NVarChar", 128, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "SudionikGrupaRoEntity", "SudionikGrupaId", "SudionikGrupaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
		}
		/// <summary>Inits TrgovanjeGlavaEntity's mappings</summary>
		private void InitTrgovanjeGlavaEntityMappings()
		{
			this.AddElementMapping( "TrgovanjeGlavaEntity", @"atjanmcs301107hr2706_tn", @"dbo", "TrgovanjeGlava", 4 );
			this.AddElementFieldMapping( "TrgovanjeGlavaEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "TrgovanjeGlavaEntity", "Datum", "Datum", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			this.AddElementFieldMapping( "TrgovanjeGlavaEntity", "Komentar", "Komentar", true, "NVarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "TrgovanjeGlavaEntity", "TrgovanjeGlavaId", "TrgovanjeGlavaId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 3 );
		}
		/// <summary>Inits TrgovanjeGlavaHnbEntity's mappings</summary>
		private void InitTrgovanjeGlavaHnbEntityMappings()
		{
			this.AddElementMapping( "TrgovanjeGlavaHnbEntity", @"atjanmcs301107hr2706_tn", @"dbo", "TrgovanjeGlavaHnb", 3 );
			this.AddElementFieldMapping( "TrgovanjeGlavaHnbEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "TrgovanjeGlavaHnbEntity", "Datum", "Datum", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			this.AddElementFieldMapping( "TrgovanjeGlavaHnbEntity", "TrgovanjeGlavaHnbId", "TrgovanjeGlavaHnbId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 2 );
		}
		/// <summary>Inits TrgovanjeStavkaEntity's mappings</summary>
		private void InitTrgovanjeStavkaEntityMappings()
		{
			this.AddElementMapping( "TrgovanjeStavkaEntity", @"atjanmcs301107hr2706_tn", @"dbo", "TrgovanjeStavka", 11 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "Ponuda", "Ponuda", false, "Decimal", 0, 2, 18, false, "", null, typeof(System.Decimal), 1 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "PonudaDodatak", "PonudaDodatak", false, "Decimal", 0, 4, 10, false, "", null, typeof(System.Decimal), 2 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "Potraznja", "Potraznja", false, "Decimal", 0, 2, 18, false, "", null, typeof(System.Decimal), 3 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "PotraznjaDodatak", "PotraznjaDodatak", false, "Decimal", 0, 4, 10, false, "", null, typeof(System.Decimal), 4 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "Promet", "Promet", false, "Decimal", 0, 2, 18, false, "", null, typeof(System.Decimal), 5 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "PrometDodatak", "PrometDodatak", false, "Decimal", 0, 4, 10, false, "", null, typeof(System.Decimal), 6 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "TrgovanjeGlavaId", "TrgovanjeGlavaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "TrgovanjeStavkaId", "TrgovanjeStavkaId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 8 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "TrgovanjeVrstaId", "TrgovanjeVrstaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 9 );
			this.AddElementFieldMapping( "TrgovanjeStavkaEntity", "ValutaId", "ValutaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 10 );
		}
		/// <summary>Inits TrgovanjeStavkaHnbEntity's mappings</summary>
		private void InitTrgovanjeStavkaHnbEntityMappings()
		{
			this.AddElementMapping( "TrgovanjeStavkaHnbEntity", @"atjanmcs301107hr2706_tn", @"dbo", "TrgovanjeStavkaHnb", 6 );
			this.AddElementFieldMapping( "TrgovanjeStavkaHnbEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "TrgovanjeStavkaHnbEntity", "IznosMilijuniKn", "IznosMilijuniKn", false, "Decimal", 0, 2, 10, false, "", null, typeof(System.Decimal), 1 );
			this.AddElementFieldMapping( "TrgovanjeStavkaHnbEntity", "KamatnaStopa", "KamatnaStopa", false, "Decimal", 0, 2, 6, false, "", null, typeof(System.Decimal), 2 );
			this.AddElementFieldMapping( "TrgovanjeStavkaHnbEntity", "TrgovanjeGlavaHnbId", "TrgovanjeGlavaHnbId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
			this.AddElementFieldMapping( "TrgovanjeStavkaHnbEntity", "TrgovanjeStavkaHnbId", "TrgovanjeStavkaHnbId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 4 );
			this.AddElementFieldMapping( "TrgovanjeStavkaHnbEntity", "TrgovanjeVrstaId", "TrgovanjeVrstaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
		}
		/// <summary>Inits TrgovanjeVrstaRoEntity's mappings</summary>
		private void InitTrgovanjeVrstaRoEntityMappings()
		{
			this.AddElementMapping( "TrgovanjeVrstaRoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "TrgovanjeVrstaRo", 4 );
			this.AddElementFieldMapping( "TrgovanjeVrstaRoEntity", "Code", "Code", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "TrgovanjeVrstaRoEntity", "Name", "Name", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "TrgovanjeVrstaRoEntity", "SifraSlog", "SifraSlog", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "TrgovanjeVrstaRoEntity", "TrgovanjeVrstaId", "TrgovanjeVrstaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
		}
		/// <summary>Inits UserEntity's mappings</summary>
		private void InitUserEntityMappings()
		{
			this.AddElementMapping( "UserEntity", @"atjanmcs301107hr2706_tn", @"dbo", "User", 5 );
			this.AddElementFieldMapping( "UserEntity", "ConcurrencyGuid", "ConcurrencyGuid", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "UserEntity", "Password", "Password", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "UserEntity", "RoleId", "RoleId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "UserEntity", "UserId", "UserId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 3 );
			this.AddElementFieldMapping( "UserEntity", "Username", "Username", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits ValutaRoEntity's mappings</summary>
		private void InitValutaRoEntityMappings()
		{
			this.AddElementMapping( "ValutaRoEntity", @"atjanmcs301107hr2706_tn", @"dbo", "ValutaRo", 4 );
			this.AddElementFieldMapping( "ValutaRoEntity", "Code", "Code", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "ValutaRoEntity", "Name", "Name", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "ValutaRoEntity", "SifraSlog", "SifraSlog", false, "NVarChar", 50, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "ValutaRoEntity", "ValutaId", "ValutaId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
		}

	}
}