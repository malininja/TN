using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjaSoftware.TrzisteNovca.CoolJ.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace NinjaSoftware.TrzisteNovca.Models.Home
{
    public class SudionikViewModel
    {
        public SudionikViewModel(DataAccessAdapterBase adapter, long sudionikGrupaId)
        {
            this.SudionikGrupa = SudionikGrupaRoEntity.FetchSudionikGrupaRo(adapter, null, sudionikGrupaId);
            this.SudionikCollection = SudionikEntity.FetchSudionikCollection(adapter, sudionikGrupaId).OrderBy(s => s.Naziv);
        }

        public IEnumerable<SudionikEntity> SudionikCollection { get; set; }
        public SudionikGrupaRoEntity SudionikGrupa { get; set; }
    }
}