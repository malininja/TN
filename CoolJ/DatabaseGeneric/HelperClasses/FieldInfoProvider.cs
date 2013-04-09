///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (18 + 0));
			InitAuditInfoEntityInfos();
			InitAuditInfoActionTypeRoEntityInfos();
			InitEntityRoEntityInfos();
			InitErrorEntityInfos();
			InitHtmlPageEntityInfos();
			InitKamatnaStopaHnbEntityInfos();
			InitRepoAukcijaEntityInfos();
			InitRoleRoEntityInfos();
			InitSistemskaInstancaPodatakaRoEntityInfos();
			InitSudionikEntityInfos();
			InitSudionikGrupaRoEntityInfos();
			InitTrgovanjeGlavaEntityInfos();
			InitTrgovanjeGlavaHnbEntityInfos();
			InitTrgovanjeStavkaEntityInfos();
			InitTrgovanjeStavkaHnbEntityInfos();
			InitTrgovanjeVrstaRoEntityInfos();
			InitUserEntityInfos();
			InitValutaRoEntityInfos();

			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits AuditInfoEntity's FieldInfo objects</summary>
		private void InitAuditInfoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AuditInfoFieldIndex), "AuditInfoEntity");
			this.AddElementFieldInfo("AuditInfoEntity", "ActionDateTime", typeof(System.DateTime), false, false, false, false,  (int)AuditInfoFieldIndex.ActionDateTime, 0, 0, 0);
			this.AddElementFieldInfo("AuditInfoEntity", "AuditInfoActionTypeId", typeof(System.Int64), false, true, false, false,  (int)AuditInfoFieldIndex.AuditInfoActionTypeId, 0, 0, 19);
			this.AddElementFieldInfo("AuditInfoEntity", "AuditInfoId", typeof(System.Int64), true, false, false, false,  (int)AuditInfoFieldIndex.AuditInfoId, 0, 0, 19);
			this.AddElementFieldInfo("AuditInfoEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)AuditInfoFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("AuditInfoEntity", "EntityId", typeof(System.Int64), false, true, false, false,  (int)AuditInfoFieldIndex.EntityId, 0, 0, 19);
			this.AddElementFieldInfo("AuditInfoEntity", "JsonData", typeof(System.String), false, false, false, false,  (int)AuditInfoFieldIndex.JsonData, 2147483647, 0, 0);
			this.AddElementFieldInfo("AuditInfoEntity", "PrimaryKeyValue", typeof(System.Int64), false, false, false, false,  (int)AuditInfoFieldIndex.PrimaryKeyValue, 0, 0, 19);
			this.AddElementFieldInfo("AuditInfoEntity", "UserId", typeof(System.Int64), false, true, false, false,  (int)AuditInfoFieldIndex.UserId, 0, 0, 19);
		}
		/// <summary>Inits AuditInfoActionTypeRoEntity's FieldInfo objects</summary>
		private void InitAuditInfoActionTypeRoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AuditInfoActionTypeRoFieldIndex), "AuditInfoActionTypeRoEntity");
			this.AddElementFieldInfo("AuditInfoActionTypeRoEntity", "AuditInfoActionTypeId", typeof(System.Int64), true, false, false, false,  (int)AuditInfoActionTypeRoFieldIndex.AuditInfoActionTypeId, 0, 0, 19);
			this.AddElementFieldInfo("AuditInfoActionTypeRoEntity", "Code", typeof(System.String), false, false, false, false,  (int)AuditInfoActionTypeRoFieldIndex.Code, 128, 0, 0);
			this.AddElementFieldInfo("AuditInfoActionTypeRoEntity", "Name", typeof(System.String), false, false, false, false,  (int)AuditInfoActionTypeRoFieldIndex.Name, 256, 0, 0);
		}
		/// <summary>Inits EntityRoEntity's FieldInfo objects</summary>
		private void InitEntityRoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(EntityRoFieldIndex), "EntityRoEntity");
			this.AddElementFieldInfo("EntityRoEntity", "Code", typeof(System.String), false, false, false, false,  (int)EntityRoFieldIndex.Code, 128, 0, 0);
			this.AddElementFieldInfo("EntityRoEntity", "EntityId", typeof(System.Int64), true, false, false, false,  (int)EntityRoFieldIndex.EntityId, 0, 0, 19);
			this.AddElementFieldInfo("EntityRoEntity", "Name", typeof(System.String), false, false, false, false,  (int)EntityRoFieldIndex.Name, 256, 0, 0);
		}
		/// <summary>Inits ErrorEntity's FieldInfo objects</summary>
		private void InitErrorEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ErrorFieldIndex), "ErrorEntity");
			this.AddElementFieldInfo("ErrorEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)ErrorFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("ErrorEntity", "ErrorDateTime", typeof(System.DateTime), false, false, false, false,  (int)ErrorFieldIndex.ErrorDateTime, 0, 0, 0);
			this.AddElementFieldInfo("ErrorEntity", "ErrorId", typeof(System.Int64), true, false, false, false,  (int)ErrorFieldIndex.ErrorId, 0, 0, 19);
			this.AddElementFieldInfo("ErrorEntity", "Message", typeof(System.String), false, false, false, false,  (int)ErrorFieldIndex.Message, 2147483647, 0, 0);
			this.AddElementFieldInfo("ErrorEntity", "ParentErrorId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)ErrorFieldIndex.ParentErrorId, 0, 0, 19);
			this.AddElementFieldInfo("ErrorEntity", "StackTrace", typeof(System.String), false, false, false, true,  (int)ErrorFieldIndex.StackTrace, 2147483647, 0, 0);
		}
		/// <summary>Inits HtmlPageEntity's FieldInfo objects</summary>
		private void InitHtmlPageEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(HtmlPageFieldIndex), "HtmlPageEntity");
			this.AddElementFieldInfo("HtmlPageEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)HtmlPageFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("HtmlPageEntity", "Html", typeof(System.String), false, false, false, false,  (int)HtmlPageFieldIndex.Html, 2147483647, 0, 0);
			this.AddElementFieldInfo("HtmlPageEntity", "HtmlPageId", typeof(System.Int64), true, false, false, false,  (int)HtmlPageFieldIndex.HtmlPageId, 0, 0, 19);
			this.AddElementFieldInfo("HtmlPageEntity", "Name", typeof(System.String), false, false, false, false,  (int)HtmlPageFieldIndex.Name, 256, 0, 0);
			this.AddElementFieldInfo("HtmlPageEntity", "SistemskaInstancaPodatakaId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)HtmlPageFieldIndex.SistemskaInstancaPodatakaId, 0, 0, 19);
		}
		/// <summary>Inits KamatnaStopaHnbEntity's FieldInfo objects</summary>
		private void InitKamatnaStopaHnbEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(KamatnaStopaHnbFieldIndex), "KamatnaStopaHnbEntity");
			this.AddElementFieldInfo("KamatnaStopaHnbEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)KamatnaStopaHnbFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("KamatnaStopaHnbEntity", "Depozit", typeof(System.Decimal), false, false, false, false,  (int)KamatnaStopaHnbFieldIndex.Depozit, 0, 2, 6);
			this.AddElementFieldInfo("KamatnaStopaHnbEntity", "Eskontna", typeof(System.Decimal), false, false, false, false,  (int)KamatnaStopaHnbFieldIndex.Eskontna, 0, 2, 6);
			this.AddElementFieldInfo("KamatnaStopaHnbEntity", "KamatnaStopaHnbId", typeof(System.Int64), true, false, false, false,  (int)KamatnaStopaHnbFieldIndex.KamatnaStopaHnbId, 0, 0, 19);
			this.AddElementFieldInfo("KamatnaStopaHnbEntity", "LombarniKredit", typeof(System.Decimal), false, false, false, false,  (int)KamatnaStopaHnbFieldIndex.LombarniKredit, 0, 2, 6);
			this.AddElementFieldInfo("KamatnaStopaHnbEntity", "Pricuva", typeof(System.Decimal), false, false, false, false,  (int)KamatnaStopaHnbFieldIndex.Pricuva, 0, 2, 6);
		}
		/// <summary>Inits RepoAukcijaEntity's FieldInfo objects</summary>
		private void InitRepoAukcijaEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RepoAukcijaFieldIndex), "RepoAukcijaEntity");
			this.AddElementFieldInfo("RepoAukcijaEntity", "BrojAukcije", typeof(System.String), false, false, false, true,  (int)RepoAukcijaFieldIndex.BrojAukcije, 20, 0, 0);
			this.AddElementFieldInfo("RepoAukcijaEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)RepoAukcijaFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("RepoAukcijaEntity", "DatumAukcije", typeof(System.DateTime), false, false, false, false,  (int)RepoAukcijaFieldIndex.DatumAukcije, 0, 0, 0);
			this.AddElementFieldInfo("RepoAukcijaEntity", "DatumReotkupa", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)RepoAukcijaFieldIndex.DatumReotkupa, 0, 0, 0);
			this.AddElementFieldInfo("RepoAukcijaEntity", "FiksnaRepoStopa", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.FiksnaRepoStopa, 0, 2, 5);
			this.AddElementFieldInfo("RepoAukcijaEntity", "GranicnaRepoStopa", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.GranicnaRepoStopa, 0, 2, 5);
			this.AddElementFieldInfo("RepoAukcijaEntity", "KoeficijentRaspodjele", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.KoeficijentRaspodjele, 0, 2, 5);
			this.AddElementFieldInfo("RepoAukcijaEntity", "NajnizaRepoStopa", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.NajnizaRepoStopa, 0, 2, 5);
			this.AddElementFieldInfo("RepoAukcijaEntity", "NajvisaRepoStopa", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.NajvisaRepoStopa, 0, 2, 5);
			this.AddElementFieldInfo("RepoAukcijaEntity", "OdbijenePonudeUkupno", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.OdbijenePonudeUkupno, 0, 2, 10);
			this.AddElementFieldInfo("RepoAukcijaEntity", "PostoPrihvacenihPoGranicnojStopi", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.PostoPrihvacenihPoGranicnojStopi, 0, 2, 5);
			this.AddElementFieldInfo("RepoAukcijaEntity", "PrihvacenePonudeUkupno", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.PrihvacenePonudeUkupno, 0, 2, 10);
			this.AddElementFieldInfo("RepoAukcijaEntity", "PristiglePonudeUkupno", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.PristiglePonudeUkupno, 0, 2, 10);
			this.AddElementFieldInfo("RepoAukcijaEntity", "RepoAukcijaId", typeof(System.Int64), true, false, false, false,  (int)RepoAukcijaFieldIndex.RepoAukcijaId, 0, 0, 19);
			this.AddElementFieldInfo("RepoAukcijaEntity", "VaganaRepoStopa", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)RepoAukcijaFieldIndex.VaganaRepoStopa, 0, 2, 5);
		}
		/// <summary>Inits RoleRoEntity's FieldInfo objects</summary>
		private void InitRoleRoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RoleRoFieldIndex), "RoleRoEntity");
			this.AddElementFieldInfo("RoleRoEntity", "Code", typeof(System.String), false, false, false, false,  (int)RoleRoFieldIndex.Code, 128, 0, 0);
			this.AddElementFieldInfo("RoleRoEntity", "Name", typeof(System.String), false, false, false, false,  (int)RoleRoFieldIndex.Name, 256, 0, 0);
			this.AddElementFieldInfo("RoleRoEntity", "RoleId", typeof(System.Int64), true, false, false, false,  (int)RoleRoFieldIndex.RoleId, 0, 0, 19);
		}
		/// <summary>Inits SistemskaInstancaPodatakaRoEntity's FieldInfo objects</summary>
		private void InitSistemskaInstancaPodatakaRoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SistemskaInstancaPodatakaRoFieldIndex), "SistemskaInstancaPodatakaRoEntity");
			this.AddElementFieldInfo("SistemskaInstancaPodatakaRoEntity", "Code", typeof(System.String), false, false, false, false,  (int)SistemskaInstancaPodatakaRoFieldIndex.Code, 64, 0, 0);
			this.AddElementFieldInfo("SistemskaInstancaPodatakaRoEntity", "Name", typeof(System.String), false, false, false, false,  (int)SistemskaInstancaPodatakaRoFieldIndex.Name, 128, 0, 0);
			this.AddElementFieldInfo("SistemskaInstancaPodatakaRoEntity", "SistemskaInstancaPodatakaId", typeof(System.Int64), true, false, false, false,  (int)SistemskaInstancaPodatakaRoFieldIndex.SistemskaInstancaPodatakaId, 0, 0, 19);
		}
		/// <summary>Inits SudionikEntity's FieldInfo objects</summary>
		private void InitSudionikEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SudionikFieldIndex), "SudionikEntity");
			this.AddElementFieldInfo("SudionikEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)SudionikFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("SudionikEntity", "Naziv", typeof(System.String), false, false, false, false,  (int)SudionikFieldIndex.Naziv, 256, 0, 0);
			this.AddElementFieldInfo("SudionikEntity", "SudionikGrupaId", typeof(System.Int64), false, true, false, false,  (int)SudionikFieldIndex.SudionikGrupaId, 0, 0, 19);
			this.AddElementFieldInfo("SudionikEntity", "SudionikId", typeof(System.Int64), true, false, false, false,  (int)SudionikFieldIndex.SudionikId, 0, 0, 19);
			this.AddElementFieldInfo("SudionikEntity", "WebAdresa", typeof(System.String), false, false, false, true,  (int)SudionikFieldIndex.WebAdresa, 512, 0, 0);
		}
		/// <summary>Inits SudionikGrupaRoEntity's FieldInfo objects</summary>
		private void InitSudionikGrupaRoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SudionikGrupaRoFieldIndex), "SudionikGrupaRoEntity");
			this.AddElementFieldInfo("SudionikGrupaRoEntity", "Code", typeof(System.String), false, false, false, false,  (int)SudionikGrupaRoFieldIndex.Code, 50, 0, 0);
			this.AddElementFieldInfo("SudionikGrupaRoEntity", "Name", typeof(System.String), false, false, false, false,  (int)SudionikGrupaRoFieldIndex.Name, 128, 0, 0);
			this.AddElementFieldInfo("SudionikGrupaRoEntity", "SudionikGrupaId", typeof(System.Int64), true, false, false, false,  (int)SudionikGrupaRoFieldIndex.SudionikGrupaId, 0, 0, 19);
		}
		/// <summary>Inits TrgovanjeGlavaEntity's FieldInfo objects</summary>
		private void InitTrgovanjeGlavaEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TrgovanjeGlavaFieldIndex), "TrgovanjeGlavaEntity");
			this.AddElementFieldInfo("TrgovanjeGlavaEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)TrgovanjeGlavaFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("TrgovanjeGlavaEntity", "Datum", typeof(System.DateTime), false, false, false, false,  (int)TrgovanjeGlavaFieldIndex.Datum, 0, 0, 0);
			this.AddElementFieldInfo("TrgovanjeGlavaEntity", "Komentar", typeof(System.String), false, false, false, true,  (int)TrgovanjeGlavaFieldIndex.Komentar, 2147483647, 0, 0);
			this.AddElementFieldInfo("TrgovanjeGlavaEntity", "TrgovanjeGlavaId", typeof(System.Int64), true, false, false, false,  (int)TrgovanjeGlavaFieldIndex.TrgovanjeGlavaId, 0, 0, 19);
		}
		/// <summary>Inits TrgovanjeGlavaHnbEntity's FieldInfo objects</summary>
		private void InitTrgovanjeGlavaHnbEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TrgovanjeGlavaHnbFieldIndex), "TrgovanjeGlavaHnbEntity");
			this.AddElementFieldInfo("TrgovanjeGlavaHnbEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)TrgovanjeGlavaHnbFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("TrgovanjeGlavaHnbEntity", "Datum", typeof(System.DateTime), false, false, false, false,  (int)TrgovanjeGlavaHnbFieldIndex.Datum, 0, 0, 0);
			this.AddElementFieldInfo("TrgovanjeGlavaHnbEntity", "TrgovanjeGlavaHnbId", typeof(System.Int64), true, false, false, false,  (int)TrgovanjeGlavaHnbFieldIndex.TrgovanjeGlavaHnbId, 0, 0, 19);
		}
		/// <summary>Inits TrgovanjeStavkaEntity's FieldInfo objects</summary>
		private void InitTrgovanjeStavkaEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TrgovanjeStavkaFieldIndex), "TrgovanjeStavkaEntity");
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)TrgovanjeStavkaFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "Ponuda", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaFieldIndex.Ponuda, 0, 2, 18);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "PonudaDodatak", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaFieldIndex.PonudaDodatak, 0, 4, 10);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "Potraznja", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaFieldIndex.Potraznja, 0, 2, 18);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "PotraznjaDodatak", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaFieldIndex.PotraznjaDodatak, 0, 4, 10);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "Promet", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaFieldIndex.Promet, 0, 2, 18);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "PrometDodatak", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaFieldIndex.PrometDodatak, 0, 4, 10);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "TrgovanjeGlavaId", typeof(System.Int64), false, true, false, false,  (int)TrgovanjeStavkaFieldIndex.TrgovanjeGlavaId, 0, 0, 19);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "TrgovanjeStavkaId", typeof(System.Int64), true, false, false, false,  (int)TrgovanjeStavkaFieldIndex.TrgovanjeStavkaId, 0, 0, 19);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "TrgovanjeVrstaId", typeof(System.Int64), false, true, false, false,  (int)TrgovanjeStavkaFieldIndex.TrgovanjeVrstaId, 0, 0, 19);
			this.AddElementFieldInfo("TrgovanjeStavkaEntity", "ValutaId", typeof(System.Int64), false, true, false, false,  (int)TrgovanjeStavkaFieldIndex.ValutaId, 0, 0, 19);
		}
		/// <summary>Inits TrgovanjeStavkaHnbEntity's FieldInfo objects</summary>
		private void InitTrgovanjeStavkaHnbEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TrgovanjeStavkaHnbFieldIndex), "TrgovanjeStavkaHnbEntity");
			this.AddElementFieldInfo("TrgovanjeStavkaHnbEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)TrgovanjeStavkaHnbFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("TrgovanjeStavkaHnbEntity", "IznosMilijuniKn", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaHnbFieldIndex.IznosMilijuniKn, 0, 2, 10);
			this.AddElementFieldInfo("TrgovanjeStavkaHnbEntity", "KamatnaStopa", typeof(System.Decimal), false, false, false, false,  (int)TrgovanjeStavkaHnbFieldIndex.KamatnaStopa, 0, 2, 6);
			this.AddElementFieldInfo("TrgovanjeStavkaHnbEntity", "TrgovanjeGlavaHnbId", typeof(System.Int64), false, true, false, false,  (int)TrgovanjeStavkaHnbFieldIndex.TrgovanjeGlavaHnbId, 0, 0, 19);
			this.AddElementFieldInfo("TrgovanjeStavkaHnbEntity", "TrgovanjeStavkaHnbId", typeof(System.Int64), true, false, false, false,  (int)TrgovanjeStavkaHnbFieldIndex.TrgovanjeStavkaHnbId, 0, 0, 19);
			this.AddElementFieldInfo("TrgovanjeStavkaHnbEntity", "TrgovanjeVrstaId", typeof(System.Int64), false, true, false, false,  (int)TrgovanjeStavkaHnbFieldIndex.TrgovanjeVrstaId, 0, 0, 19);
		}
		/// <summary>Inits TrgovanjeVrstaRoEntity's FieldInfo objects</summary>
		private void InitTrgovanjeVrstaRoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TrgovanjeVrstaRoFieldIndex), "TrgovanjeVrstaRoEntity");
			this.AddElementFieldInfo("TrgovanjeVrstaRoEntity", "Code", typeof(System.String), false, false, false, false,  (int)TrgovanjeVrstaRoFieldIndex.Code, 50, 0, 0);
			this.AddElementFieldInfo("TrgovanjeVrstaRoEntity", "Name", typeof(System.String), false, false, false, false,  (int)TrgovanjeVrstaRoFieldIndex.Name, 50, 0, 0);
			this.AddElementFieldInfo("TrgovanjeVrstaRoEntity", "SifraSlog", typeof(System.String), false, false, false, false,  (int)TrgovanjeVrstaRoFieldIndex.SifraSlog, 50, 0, 0);
			this.AddElementFieldInfo("TrgovanjeVrstaRoEntity", "TrgovanjeVrstaId", typeof(System.Int64), true, false, false, false,  (int)TrgovanjeVrstaRoFieldIndex.TrgovanjeVrstaId, 0, 0, 19);
		}
		/// <summary>Inits UserEntity's FieldInfo objects</summary>
		private void InitUserEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserFieldIndex), "UserEntity");
			this.AddElementFieldInfo("UserEntity", "ConcurrencyGuid", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.ConcurrencyGuid, 50, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Password", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Password, 50, 0, 0);
			this.AddElementFieldInfo("UserEntity", "RoleId", typeof(System.Int64), false, true, false, false,  (int)UserFieldIndex.RoleId, 0, 0, 19);
			this.AddElementFieldInfo("UserEntity", "UserId", typeof(System.Int64), true, false, false, false,  (int)UserFieldIndex.UserId, 0, 0, 19);
			this.AddElementFieldInfo("UserEntity", "Username", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Username, 50, 0, 0);
		}
		/// <summary>Inits ValutaRoEntity's FieldInfo objects</summary>
		private void InitValutaRoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ValutaRoFieldIndex), "ValutaRoEntity");
			this.AddElementFieldInfo("ValutaRoEntity", "Code", typeof(System.String), false, false, false, false,  (int)ValutaRoFieldIndex.Code, 50, 0, 0);
			this.AddElementFieldInfo("ValutaRoEntity", "Name", typeof(System.String), false, false, false, false,  (int)ValutaRoFieldIndex.Name, 50, 0, 0);
			this.AddElementFieldInfo("ValutaRoEntity", "SifraSlog", typeof(System.String), false, false, false, false,  (int)ValutaRoFieldIndex.SifraSlog, 50, 0, 0);
			this.AddElementFieldInfo("ValutaRoEntity", "ValutaId", typeof(System.Int64), true, false, false, false,  (int)ValutaRoFieldIndex.ValutaId, 0, 0, 19);
		}
		
	}
}




