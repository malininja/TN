///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.CoolJ.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2<TEntity> : EntityFactoryCore2
		where TEntity : EntityBase2, IEntity2
	{
		private readonly NinjaSoftware.TrzisteNovca.CoolJ.EntityType _typeOfEntity;
		private readonly bool _isInHierarchy;
		
		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <param name="isInHierarchy">If true, the entity of this factory is in an inheritance hierarchy, false otherwise</param>
		public EntityFactoryBase2(string entityName, NinjaSoftware.TrzisteNovca.CoolJ.EntityType typeOfEntity, bool isInHierarchy) : base(entityName)
		{
			_typeOfEntity = typeOfEntity;
			_isInHierarchy = isInHierarchy;
		}
		
		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields2 object for the entity to create.</summary>
		/// <returns>Empty IEntityFields2 object.</returns>
		public override IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(_typeOfEntity);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.Create((NinjaSoftware.TrzisteNovca.CoolJ.EntityType)entityTypeValue);
		}

		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <param name="objectAlias">The object alias to use for the elements in the relations.</param>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetHierarchyRelations(this.ForEntityName, objectAlias);
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			IEntityFactory2 toReturn = (IEntityFactory2)InheritanceInfoProviderSingleton.GetInstance().GetEntityFactory(this.ForEntityName, fieldValues, entityFieldStartIndexesPerEntity);
			if(toReturn == null)
			{
				toReturn = this;
			}
			return toReturn;
		}
		
		/// <summary>Gets a predicateexpression which filters on the entity with type belonging to this factory.</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <param name="objectAlias">The object alias to use for the predicate(s).</param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if the belonging entity isn't a hierarchical type.</returns>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);
		}
						
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity which this factory belongs to.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<TEntity>(this);
		}
		
		/// <summary>Creates the hierarchy fields for the entity to which this factory belongs.</summary>
		/// <returns>IEntityFields2 object with the fields of all the entities in teh hierarchy of this entity or the fields of this entity if the entity isn't in a hierarchy.</returns>
		public override IEntityFields2 CreateHierarchyFields() 
		{
			return _isInHierarchy ? new EntityFields2(InheritanceInfoProviderSingleton.GetInstance().GetHierarchyFields(this.ForEntityName), InheritanceInfoProviderSingleton.GetInstance(), null) : base.CreateHierarchyFields();
		}
	}

	/// <summary>Factory to create new, empty AuditInfoEntity objects.</summary>
	[Serializable]
	public partial class AuditInfoEntityFactory : EntityFactoryBase2<AuditInfoEntity> {
		/// <summary>CTor</summary>
		public AuditInfoEntityFactory() : base("AuditInfoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.AuditInfoEntity, false) { }
		
		/// <summary>Creates a new AuditInfoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AuditInfoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditInfoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty AuditInfoActionTypeRoEntity objects.</summary>
	[Serializable]
	public partial class AuditInfoActionTypeRoEntityFactory : EntityFactoryBase2<AuditInfoActionTypeRoEntity> {
		/// <summary>CTor</summary>
		public AuditInfoActionTypeRoEntityFactory() : base("AuditInfoActionTypeRoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.AuditInfoActionTypeRoEntity, false) { }
		
		/// <summary>Creates a new AuditInfoActionTypeRoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new AuditInfoActionTypeRoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAuditInfoActionTypeRoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty EntityRoEntity objects.</summary>
	[Serializable]
	public partial class EntityRoEntityFactory : EntityFactoryBase2<EntityRoEntity> {
		/// <summary>CTor</summary>
		public EntityRoEntityFactory() : base("EntityRoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.EntityRoEntity, false) { }
		
		/// <summary>Creates a new EntityRoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new EntityRoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEntityRoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty ErrorEntity objects.</summary>
	[Serializable]
	public partial class ErrorEntityFactory : EntityFactoryBase2<ErrorEntity> {
		/// <summary>CTor</summary>
		public ErrorEntityFactory() : base("ErrorEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ErrorEntity, false) { }
		
		/// <summary>Creates a new ErrorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ErrorEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewErrorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty HtmlPageEntity objects.</summary>
	[Serializable]
	public partial class HtmlPageEntityFactory : EntityFactoryBase2<HtmlPageEntity> {
		/// <summary>CTor</summary>
		public HtmlPageEntityFactory() : base("HtmlPageEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.HtmlPageEntity, false) { }
		
		/// <summary>Creates a new HtmlPageEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new HtmlPageEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHtmlPageUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty KamatnaStopaHnbEntity objects.</summary>
	[Serializable]
	public partial class KamatnaStopaHnbEntityFactory : EntityFactoryBase2<KamatnaStopaHnbEntity> {
		/// <summary>CTor</summary>
		public KamatnaStopaHnbEntityFactory() : base("KamatnaStopaHnbEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.KamatnaStopaHnbEntity, false) { }
		
		/// <summary>Creates a new KamatnaStopaHnbEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new KamatnaStopaHnbEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewKamatnaStopaHnbUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty RepoAukcijaEntity objects.</summary>
	[Serializable]
	public partial class RepoAukcijaEntityFactory : EntityFactoryBase2<RepoAukcijaEntity> {
		/// <summary>CTor</summary>
		public RepoAukcijaEntityFactory() : base("RepoAukcijaEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.RepoAukcijaEntity, false) { }
		
		/// <summary>Creates a new RepoAukcijaEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RepoAukcijaEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRepoAukcijaUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty RoleRoEntity objects.</summary>
	[Serializable]
	public partial class RoleRoEntityFactory : EntityFactoryBase2<RoleRoEntity> {
		/// <summary>CTor</summary>
		public RoleRoEntityFactory() : base("RoleRoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.RoleRoEntity, false) { }
		
		/// <summary>Creates a new RoleRoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RoleRoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRoleRoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty SistemskaInstancaPodatakaRoEntity objects.</summary>
	[Serializable]
	public partial class SistemskaInstancaPodatakaRoEntityFactory : EntityFactoryBase2<SistemskaInstancaPodatakaRoEntity> {
		/// <summary>CTor</summary>
		public SistemskaInstancaPodatakaRoEntityFactory() : base("SistemskaInstancaPodatakaRoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SistemskaInstancaPodatakaRoEntity, false) { }
		
		/// <summary>Creates a new SistemskaInstancaPodatakaRoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SistemskaInstancaPodatakaRoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSistemskaInstancaPodatakaRoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty SudionikEntity objects.</summary>
	[Serializable]
	public partial class SudionikEntityFactory : EntityFactoryBase2<SudionikEntity> {
		/// <summary>CTor</summary>
		public SudionikEntityFactory() : base("SudionikEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SudionikEntity, false) { }
		
		/// <summary>Creates a new SudionikEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SudionikEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSudionikUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty SudionikGrupaRoEntity objects.</summary>
	[Serializable]
	public partial class SudionikGrupaRoEntityFactory : EntityFactoryBase2<SudionikGrupaRoEntity> {
		/// <summary>CTor</summary>
		public SudionikGrupaRoEntityFactory() : base("SudionikGrupaRoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SudionikGrupaRoEntity, false) { }
		
		/// <summary>Creates a new SudionikGrupaRoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SudionikGrupaRoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSudionikGrupaRoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty TrgovanjeGlavaEntity objects.</summary>
	[Serializable]
	public partial class TrgovanjeGlavaEntityFactory : EntityFactoryBase2<TrgovanjeGlavaEntity> {
		/// <summary>CTor</summary>
		public TrgovanjeGlavaEntityFactory() : base("TrgovanjeGlavaEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeGlavaEntity, false) { }
		
		/// <summary>Creates a new TrgovanjeGlavaEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TrgovanjeGlavaEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTrgovanjeGlavaUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty TrgovanjeGlavaHnbEntity objects.</summary>
	[Serializable]
	public partial class TrgovanjeGlavaHnbEntityFactory : EntityFactoryBase2<TrgovanjeGlavaHnbEntity> {
		/// <summary>CTor</summary>
		public TrgovanjeGlavaHnbEntityFactory() : base("TrgovanjeGlavaHnbEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeGlavaHnbEntity, false) { }
		
		/// <summary>Creates a new TrgovanjeGlavaHnbEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TrgovanjeGlavaHnbEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTrgovanjeGlavaHnbUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty TrgovanjeStavkaEntity objects.</summary>
	[Serializable]
	public partial class TrgovanjeStavkaEntityFactory : EntityFactoryBase2<TrgovanjeStavkaEntity> {
		/// <summary>CTor</summary>
		public TrgovanjeStavkaEntityFactory() : base("TrgovanjeStavkaEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeStavkaEntity, false) { }
		
		/// <summary>Creates a new TrgovanjeStavkaEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TrgovanjeStavkaEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTrgovanjeStavkaUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty TrgovanjeStavkaHnbEntity objects.</summary>
	[Serializable]
	public partial class TrgovanjeStavkaHnbEntityFactory : EntityFactoryBase2<TrgovanjeStavkaHnbEntity> {
		/// <summary>CTor</summary>
		public TrgovanjeStavkaHnbEntityFactory() : base("TrgovanjeStavkaHnbEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeStavkaHnbEntity, false) { }
		
		/// <summary>Creates a new TrgovanjeStavkaHnbEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TrgovanjeStavkaHnbEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTrgovanjeStavkaHnbUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty TrgovanjeVrstaRoEntity objects.</summary>
	[Serializable]
	public partial class TrgovanjeVrstaRoEntityFactory : EntityFactoryBase2<TrgovanjeVrstaRoEntity> {
		/// <summary>CTor</summary>
		public TrgovanjeVrstaRoEntityFactory() : base("TrgovanjeVrstaRoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeVrstaRoEntity, false) { }
		
		/// <summary>Creates a new TrgovanjeVrstaRoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TrgovanjeVrstaRoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTrgovanjeVrstaRoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty UserEntity objects.</summary>
	[Serializable]
	public partial class UserEntityFactory : EntityFactoryBase2<UserEntity> {
		/// <summary>CTor</summary>
		public UserEntityFactory() : base("UserEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.UserEntity, false) { }
		
		/// <summary>Creates a new UserEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new UserEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty ValutaRoEntity objects.</summary>
	[Serializable]
	public partial class ValutaRoEntityFactory : EntityFactoryBase2<ValutaRoEntity> {
		/// <summary>CTor</summary>
		public ValutaRoEntityFactory() : base("ValutaRoEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ValutaRoEntity, false) { }
		
		/// <summary>Creates a new ValutaRoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ValutaRoEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewValutaRoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty ZakljuceniMjesecEntity objects.</summary>
	[Serializable]
	public partial class ZakljuceniMjesecEntityFactory : EntityFactoryBase2<ZakljuceniMjesecEntity> {
		/// <summary>CTor</summary>
		public ZakljuceniMjesecEntityFactory() : base("ZakljuceniMjesecEntity", NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ZakljuceniMjesecEntity, false) { }
		
		/// <summary>Creates a new ZakljuceniMjesecEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ZakljuceniMjesecEntity(fields);
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewZakljuceniMjesecUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(NinjaSoftware.TrzisteNovca.CoolJ.EntityType entityTypeToCreate)
		{
			IEntityFactory2 factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.AuditInfoEntity:
					factoryToUse = new AuditInfoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.AuditInfoActionTypeRoEntity:
					factoryToUse = new AuditInfoActionTypeRoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.EntityRoEntity:
					factoryToUse = new EntityRoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ErrorEntity:
					factoryToUse = new ErrorEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.HtmlPageEntity:
					factoryToUse = new HtmlPageEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.KamatnaStopaHnbEntity:
					factoryToUse = new KamatnaStopaHnbEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.RepoAukcijaEntity:
					factoryToUse = new RepoAukcijaEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.RoleRoEntity:
					factoryToUse = new RoleRoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SistemskaInstancaPodatakaRoEntity:
					factoryToUse = new SistemskaInstancaPodatakaRoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SudionikEntity:
					factoryToUse = new SudionikEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.SudionikGrupaRoEntity:
					factoryToUse = new SudionikGrupaRoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeGlavaEntity:
					factoryToUse = new TrgovanjeGlavaEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeGlavaHnbEntity:
					factoryToUse = new TrgovanjeGlavaHnbEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeStavkaEntity:
					factoryToUse = new TrgovanjeStavkaEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeStavkaHnbEntity:
					factoryToUse = new TrgovanjeStavkaHnbEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.TrgovanjeVrstaRoEntity:
					factoryToUse = new TrgovanjeVrstaRoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.UserEntity:
					factoryToUse = new UserEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ValutaRoEntity:
					factoryToUse = new ValutaRoEntityFactory();
					break;
				case NinjaSoftware.TrzisteNovca.CoolJ.EntityType.ZakljuceniMjesecEntity:
					factoryToUse = new ZakljuceniMjesecEntityFactory();
					break;
			}
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
		
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
#if CF
		/// <summary>Gets the factory of the entity with the NinjaSoftware.TrzisteNovca.CoolJ.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(NinjaSoftware.TrzisteNovca.CoolJ.EntityType typeOfEntity)
		{
			return GeneralEntityFactory.Create(typeOfEntity).GetEntityFactory();
		}
#else
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			Array entityTypeValues = Enum.GetValues(typeof(NinjaSoftware.TrzisteNovca.CoolJ.EntityType));
			foreach(int entityTypeValue in entityTypeValues)
			{
				IEntity2 dummy = GeneralEntityFactory.Create((NinjaSoftware.TrzisteNovca.CoolJ.EntityType)entityTypeValue);
				_factoryPerType.Add(dummy.GetType(), dummy.GetEntityFactory());
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity)
		{
			IEntityFactory2 toReturn = null;
			_factoryPerType.TryGetValue(typeOfEntity, out toReturn);
			return toReturn;
		}

		/// <summary>Gets the factory of the entity with the NinjaSoftware.TrzisteNovca.CoolJ.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(NinjaSoftware.TrzisteNovca.CoolJ.EntityType typeOfEntity)
		{
			return GetFactory(GeneralEntityFactory.Create(typeOfEntity).GetType());
		}
#endif		
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the NinjaSoftware.TrzisteNovca.CoolJ.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue)
		{
			return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue);
		}
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity)
		{
			return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity);
		}

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields)
		{
			return new ResultsetFields(numberOfFields);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand)
		{
			return new DynamicRelation(leftOperand);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperand">The right operand.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (NinjaSoftware.TrzisteNovca.CoolJ.EntityType)Enum.Parse(typeof(NinjaSoftware.TrzisteNovca.CoolJ.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperandEntityName">Name of the entity which is used as the left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasLeftOperand">The alias of the left operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((NinjaSoftware.TrzisteNovca.CoolJ.EntityType)Enum.Parse(typeof(NinjaSoftware.TrzisteNovca.CoolJ.EntityType), leftOperandEntityName, false), joinType, (NinjaSoftware.TrzisteNovca.CoolJ.EntityType)Enum.Parse(typeof(NinjaSoftware.TrzisteNovca.CoolJ.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <summary>Obtains the inheritance info provider instance from the singleton </summary>
		/// <returns>The singleton instance of the inheritance info provider</returns>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the NinjaSoftware.TrzisteNovca.CoolJ.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue)
		{
			return EntityFactoryFactory.GetFactory((NinjaSoftware.TrzisteNovca.CoolJ.EntityType)entityTypeValue);
		}
#if !CF		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity)
		{
			return EntityFactoryFactory.GetFactory(typeOfEntity);
		}
#endif
	}
}
