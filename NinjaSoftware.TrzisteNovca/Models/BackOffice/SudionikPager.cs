using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.Api.Mvc;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ;

namespace NinjaSoftware.TrzisteNovca.Models.BackOffice
{
    public class SudionikPager : PagerBase
    {
        public override string DefaultSortField
        {
            get { return SudionikFields.Naziv.Name; }
        }

        public override bool IsDefaultSortDirectionAscending
        {
            get { return true; }
        }

        protected override void SetDataSource(DataAccessAdapterBase adapter, int pageNumber, int pageSize, string sortField, bool isSortAscending)
        {
            RelationPredicateBucket bucket = null;
            if (this.SudionikGrupaId.HasValue)
            {
                bucket = new RelationPredicateBucket(SudionikFields.SudionikGrupaId == this.SudionikGrupaId.Value);
            }

            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.SudionikEntity);
            prefetchPath.Add(SudionikEntity.PrefetchPathSudionikGrupa);

            IEnumerable<SudionikEntity> sudionikCollection = SudionikEntity.FetchSudionikCollectionForPaging(adapter, bucket, prefetchPath, pageNumber, pageSize, sortField, isSortAscending);

            this.DataSource = sudionikCollection;
            this.NoOfRecords = SudionikEntity.GetNumberOfEntities(adapter, bucket);

            this.SudionikGrupaCollection = SudionikGrupaRoEntity.FetchSudionikGrupaRoCollection(adapter, null, null).OrderBy(sg => sg.Name);
        }

        public IEnumerable<SudionikGrupaRoEntity> SudionikGrupaCollection { get; set; }
        public long? SudionikGrupaId { get; set; }
    }
}