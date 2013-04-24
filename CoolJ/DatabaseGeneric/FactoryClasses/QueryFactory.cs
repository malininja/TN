///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: 24. travanj 2013. 16:32:46
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace NinjaSoftware.TrzisteNovca.CoolJ.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory
	{
		private int _aliasCounter = 0;

		/// <summary>Creates a new DynamicQuery instance with no alias set.</summary>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create()
		{
			return Create(string.Empty);
		}

		/// <summary>Creates a new DynamicQuery instance with the alias specified as the alias set.</summary>
		/// <param name="alias">The alias.</param>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create(string alias)
		{
			return new DynamicQuery(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}
	
		/// <summary>Creates a new EntityQuery for the entity of the type specified with no alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>()
			where TEntity : IEntityCore
		{
			return Create<TEntity>(string.Empty);
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with the alias specified as the alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <param name="alias">The alias.</param>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>(string alias)
			where TEntity : IEntityCore
		{
			return new EntityQuery<TEntity>(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}
				
		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field(string fieldName)
		{
			return Field<object>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field(string targetAlias, string fieldName)
		{
			return Field<object>(targetAlias, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value represented by the field.</typeparam>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field<TValue>(string fieldName)
		{
			return Field<TValue>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field<TValue>(string targetAlias, string fieldName)
		{
			return new EntityField2(fieldName, targetAlias, typeof(TValue));
		}
		
		/// <summary>Gets the next alias counter value to produce artifical aliases with</summary>
		private int GetNextAliasCounterValue()
		{
			_aliasCounter++;
			return _aliasCounter;
		}
		
		/// <summary>Creates and returns a new EntityQuery for the AuditInfo entity</summary>
		public EntityQuery<AuditInfoEntity> AuditInfo
		{
			get { return Create<AuditInfoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AuditInfoActionTypeRo entity</summary>
		public EntityQuery<AuditInfoActionTypeRoEntity> AuditInfoActionTypeRo
		{
			get { return Create<AuditInfoActionTypeRoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the EntityRo entity</summary>
		public EntityQuery<EntityRoEntity> EntityRo
		{
			get { return Create<EntityRoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Error entity</summary>
		public EntityQuery<ErrorEntity> Error
		{
			get { return Create<ErrorEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the HtmlPage entity</summary>
		public EntityQuery<HtmlPageEntity> HtmlPage
		{
			get { return Create<HtmlPageEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the KamatnaStopaHnb entity</summary>
		public EntityQuery<KamatnaStopaHnbEntity> KamatnaStopaHnb
		{
			get { return Create<KamatnaStopaHnbEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RepoAukcija entity</summary>
		public EntityQuery<RepoAukcijaEntity> RepoAukcija
		{
			get { return Create<RepoAukcijaEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RoleRo entity</summary>
		public EntityQuery<RoleRoEntity> RoleRo
		{
			get { return Create<RoleRoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SistemskaInstancaPodatakaRo entity</summary>
		public EntityQuery<SistemskaInstancaPodatakaRoEntity> SistemskaInstancaPodatakaRo
		{
			get { return Create<SistemskaInstancaPodatakaRoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Sudionik entity</summary>
		public EntityQuery<SudionikEntity> Sudionik
		{
			get { return Create<SudionikEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SudionikGrupaRo entity</summary>
		public EntityQuery<SudionikGrupaRoEntity> SudionikGrupaRo
		{
			get { return Create<SudionikGrupaRoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the TrgovanjeGlava entity</summary>
		public EntityQuery<TrgovanjeGlavaEntity> TrgovanjeGlava
		{
			get { return Create<TrgovanjeGlavaEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the TrgovanjeGlavaHnb entity</summary>
		public EntityQuery<TrgovanjeGlavaHnbEntity> TrgovanjeGlavaHnb
		{
			get { return Create<TrgovanjeGlavaHnbEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the TrgovanjeStavka entity</summary>
		public EntityQuery<TrgovanjeStavkaEntity> TrgovanjeStavka
		{
			get { return Create<TrgovanjeStavkaEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the TrgovanjeStavkaHnb entity</summary>
		public EntityQuery<TrgovanjeStavkaHnbEntity> TrgovanjeStavkaHnb
		{
			get { return Create<TrgovanjeStavkaHnbEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the TrgovanjeVrstaRo entity</summary>
		public EntityQuery<TrgovanjeVrstaRoEntity> TrgovanjeVrstaRo
		{
			get { return Create<TrgovanjeVrstaRoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the User entity</summary>
		public EntityQuery<UserEntity> User
		{
			get { return Create<UserEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ValutaRo entity</summary>
		public EntityQuery<ValutaRoEntity> ValutaRo
		{
			get { return Create<ValutaRoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ZakljuceniMjesec entity</summary>
		public EntityQuery<ZakljuceniMjesecEntity> ZakljuceniMjesec
		{
			get { return Create<ZakljuceniMjesecEntity>(); }
		}

	}
}