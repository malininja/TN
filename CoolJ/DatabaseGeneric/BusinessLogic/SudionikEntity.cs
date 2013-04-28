using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using NinjaSoftware.TrzisteNovca.CoolJ.HelperClasses;
using System.ComponentModel.DataAnnotations;

namespace NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses
{
    [MetadataType(typeof(SudionikValidationMeta))]
    public partial class SudionikEntity
    {
        public class SudionikValidationMeta
        {
            [Required]
            public object Naziv;
        }

        public static EntityCollection<SudionikEntity> FetchSudionikCollection(DataAccessAdapterBase adapter, long sudionikGrupaId)
        {
            RelationPredicateBucket bucket = new RelationPredicateBucket(SudionikFields.SudionikGrupaId == sudionikGrupaId);
            return FetchSudionikCollection(adapter, bucket, null);
        }
    }
}
