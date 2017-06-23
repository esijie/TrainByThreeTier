using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainByThreeTier.Common
{
    public class cGlobal
    {
        public enum OrderBy
        {
            ID=1001,
            PublishDate=1002,
            Count=1003,
        }

        public enum OrderByRole
        {
            Asc=1011,
            Desc=1012,
        }
    }
}