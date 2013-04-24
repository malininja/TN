using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using NinjaSoftware.Api.Core;

namespace NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses
{
    public partial class ZakljuceniMjesecEntity
    {
        public override void Save(DataAccessAdapterBase adapter, bool refetchAfterSave, bool recurse)
        {
            ZakljuceniMjesecEntity zakljuceniMjesec = ZakljuceniMjesecEntity.FetchZakljuceniMjesec(adapter, this.Godina, this.Mjesec);

            if (null == zakljuceniMjesec)
            {
                base.Save(adapter, refetchAfterSave, recurse);
            }
            else
            {
                throw new UserException("Mjesec je već zaključen.");
            }
        }

        public static ZakljuceniMjesecEntity FetchZakljuceniMjesec(DataAccessAdapterBase adapter, int godina, int mjesec)
        {
            RelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(ZakljuceniMjesecFields.Godina == godina);
            bucket.PredicateExpression.Add(ZakljuceniMjesecFields.Mjesec == mjesec);
            
            return FetchZakljuceniMjesecCollection(adapter, bucket, null).SingleOrDefault();
        }
    }
}
