///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using NinjaSoftware.TrzisteNovca.CoolJ;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.FactoryClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.RelationClasses;

namespace NinjaSoftware.TrzisteNovca.CoolJ.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((NinjaSoftware.TrzisteNovca.CoolJ.EntityType)typeOfEntity)
			{
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.AuditInfoEntity:
					toReturn = this.AuditInfo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.AuditInfoActionTypeRoEntity:
					toReturn = this.AuditInfoActionTypeRo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.EntityRoEntity:
					toReturn = this.EntityRo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ErrorEntity:
					toReturn = this.Error;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.HtmlPageEntity:
					toReturn = this.HtmlPage;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.KamatnaStopaHnbEntity:
					toReturn = this.KamatnaStopaHnb;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.RepoAukcijaEntity:
					toReturn = this.RepoAukcija;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.RoleRoEntity:
					toReturn = this.RoleRo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SistemskaInstancaPodatakaRoEntity:
					toReturn = this.SistemskaInstancaPodatakaRo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SudionikEntity:
					toReturn = this.Sudionik;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SudionikGrupaRoEntity:
					toReturn = this.SudionikGrupaRo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeGlavaEntity:
					toReturn = this.TrgovanjeGlava;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeGlavaHnbEntity:
					toReturn = this.TrgovanjeGlavaHnb;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeStavkaEntity:
					toReturn = this.TrgovanjeStavka;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeStavkaHnbEntity:
					toReturn = this.TrgovanjeStavkaHnb;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeVrstaRoEntity:
					toReturn = this.TrgovanjeVrstaRo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.UserEntity:
					toReturn = this.User;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ValutaRoEntity:
					toReturn = this.ValutaRo;
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ZakljuceniMjesecEntity:
					toReturn = this.ZakljuceniMjesec;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting AuditInfoEntity instances in the database.</summary>
		public DataSource2<AuditInfoEntity> AuditInfo
		{
			get { return new DataSource2<AuditInfoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AuditInfoActionTypeRoEntity instances in the database.</summary>
		public DataSource2<AuditInfoActionTypeRoEntity> AuditInfoActionTypeRo
		{
			get { return new DataSource2<AuditInfoActionTypeRoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting EntityRoEntity instances in the database.</summary>
		public DataSource2<EntityRoEntity> EntityRo
		{
			get { return new DataSource2<EntityRoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ErrorEntity instances in the database.</summary>
		public DataSource2<ErrorEntity> Error
		{
			get { return new DataSource2<ErrorEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting HtmlPageEntity instances in the database.</summary>
		public DataSource2<HtmlPageEntity> HtmlPage
		{
			get { return new DataSource2<HtmlPageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting KamatnaStopaHnbEntity instances in the database.</summary>
		public DataSource2<KamatnaStopaHnbEntity> KamatnaStopaHnb
		{
			get { return new DataSource2<KamatnaStopaHnbEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RepoAukcijaEntity instances in the database.</summary>
		public DataSource2<RepoAukcijaEntity> RepoAukcija
		{
			get { return new DataSource2<RepoAukcijaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleRoEntity instances in the database.</summary>
		public DataSource2<RoleRoEntity> RoleRo
		{
			get { return new DataSource2<RoleRoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SistemskaInstancaPodatakaRoEntity instances in the database.</summary>
		public DataSource2<SistemskaInstancaPodatakaRoEntity> SistemskaInstancaPodatakaRo
		{
			get { return new DataSource2<SistemskaInstancaPodatakaRoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SudionikEntity instances in the database.</summary>
		public DataSource2<SudionikEntity> Sudionik
		{
			get { return new DataSource2<SudionikEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SudionikGrupaRoEntity instances in the database.</summary>
		public DataSource2<SudionikGrupaRoEntity> SudionikGrupaRo
		{
			get { return new DataSource2<SudionikGrupaRoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TrgovanjeGlavaEntity instances in the database.</summary>
		public DataSource2<TrgovanjeGlavaEntity> TrgovanjeGlava
		{
			get { return new DataSource2<TrgovanjeGlavaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TrgovanjeGlavaHnbEntity instances in the database.</summary>
		public DataSource2<TrgovanjeGlavaHnbEntity> TrgovanjeGlavaHnb
		{
			get { return new DataSource2<TrgovanjeGlavaHnbEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TrgovanjeStavkaEntity instances in the database.</summary>
		public DataSource2<TrgovanjeStavkaEntity> TrgovanjeStavka
		{
			get { return new DataSource2<TrgovanjeStavkaEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TrgovanjeStavkaHnbEntity instances in the database.</summary>
		public DataSource2<TrgovanjeStavkaHnbEntity> TrgovanjeStavkaHnb
		{
			get { return new DataSource2<TrgovanjeStavkaHnbEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting TrgovanjeVrstaRoEntity instances in the database.</summary>
		public DataSource2<TrgovanjeVrstaRoEntity> TrgovanjeVrstaRo
		{
			get { return new DataSource2<TrgovanjeVrstaRoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource2<UserEntity> User
		{
			get { return new DataSource2<UserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ValutaRoEntity instances in the database.</summary>
		public DataSource2<ValutaRoEntity> ValutaRo
		{
			get { return new DataSource2<ValutaRoEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ZakljuceniMjesecEntity instances in the database.</summary>
		public DataSource2<ZakljuceniMjesecEntity> ZakljuceniMjesec
		{
			get { return new DataSource2<ZakljuceniMjesecEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		
		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}