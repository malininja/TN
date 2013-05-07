using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.Api.CoolJ;
using NinjaSoftware.TrzisteNovca.CoolJ.DatabaseGeneric.BusinessLogic;

namespace NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses
{
    public partial class TrgovanjeStavkaHnbEntity
    {
        #region Custom properties

        public decimal? KamatnaStopaPromjenaPosto
        {
            get
            {
                decimal? kamataPromjenaPosto = null;

                if (null != this.TrgovanjeGlavaHnb.TrgovanjeGlavaHnbPrethodniDan)
                {
                    TrgovanjeStavkaHnbEntity stavkaPrethodniDan = this.TrgovanjeGlavaHnb.TrgovanjeGlavaHnbPrethodniDan.TrgovanjeStavkaHnbCollection.
                        Where(ts => ts.TrgovanjeVrstaId == this.TrgovanjeVrstaId).
                        SingleOrDefault();

                    if (null != stavkaPrethodniDan &&
                        0 != stavkaPrethodniDan.KamatnaStopa)
                    {
                        kamataPromjenaPosto = (this.KamatnaStopa / stavkaPrethodniDan.KamatnaStopa - 1) * 100;
                    }
                }

                return kamataPromjenaPosto;
            }
        }

        #endregion

        #region Static methods

        public static EntityCollection<TrgovanjeStavkaHnbEntity> FetchTrgovanjeStavkaHnbCollection(DataAccessAdapterBase adapter, int godina)
        {
            DateTime startDate = new DateTime(godina, 1, 1);
            DateTime endDate = startDate.AddYears(1);

            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.Relations.Add(TrgovanjeStavkaHnbEntity.Relations.TrgovanjeGlavaHnbEntityUsingTrgovanjeGlavaHnbId);
            
            bucket.PredicateExpression.Add(PredicateHelper.FilterValidEntities(startDate, endDate, TrgovanjeGlavaHnbFields.Datum));

            PrefetchPath2 prefetchPath = new PrefetchPath2(EntityType.TrgovanjeStavkaHnbEntity);
            prefetchPath.Add(TrgovanjeStavkaHnbEntity.PrefetchPathTrgovanjeGlavaHnb);

            EntityCollection<TrgovanjeStavkaHnbEntity> trgovanjeStavkaHnbCollection = TrgovanjeStavkaHnbEntity.FetchTrgovanjeStavkaHnbCollection(adapter, bucket, prefetchPath);

            return trgovanjeStavkaHnbCollection;
        }

        #endregion
    }
}
