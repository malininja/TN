using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.Linq;
using NinjaSoftware.TrzisteNovca.CoolJ.FactoryClasses;

namespace NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses
{
    public partial class RepoAukcijaEntity
    {
        private static List<DateTime> _repoAukcijaDateCollection;

        public static List<DateTime> FetchRepoAukcijaDateCollection(DataAccessAdapterBase adapter)
        {
            if (null == _repoAukcijaDateCollection)
            {
                EntityCollection<RepoAukcijaEntity> repoAukcijaEntityCollection = new EntityCollection<RepoAukcijaEntity>(new RepoAukcijaEntityFactory());
                ExcludeIncludeFieldsList includeFieldList = new ExcludeIncludeFieldsList(false);
                includeFieldList.Add(RepoAukcijaFields.DatumAukcije);

                adapter.FetchEntityCollection(repoAukcijaEntityCollection, includeFieldList, null);

                _repoAukcijaDateCollection = repoAukcijaEntityCollection.OrderByDescending(ra => ra.DatumAukcije).Select(ra => ra.DatumAukcije).ToList();
            }

            return _repoAukcijaDateCollection;
        }

        public static RepoAukcijaEntity FetchRepoAukcija(DataAccessAdapterBase adapter, PrefetchPath2 prefetchPath, DateTime datumAukcije)
        {
            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(RepoAukcijaFields.DatumAukcije == datumAukcije);

            return FetchRepoAukcijaCollection(adapter, bucket, prefetchPath).SingleOrDefault();
        }

        public static void RefreshRepoAukcijaDateCollectionCache()
        {
            _repoAukcijaDateCollection = null;
        }
    }
}
