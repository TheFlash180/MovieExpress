using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using Singular.Web;
using Csla;

namespace MEWeb
{
    public class ReportsVM : MEStatelessViewModel<ReportsVM>
    {
        public MELib.Reports.ProductsSoldReportList ProductsSoldReportList { get; set; }
        public ReportsVM()
        {

        }

        protected override void Setup()
        {
            base.Setup();
            ProductsSoldReportList = MELib.Reports.ProductsSoldReportList.GetProductsSoldReportList();
        }
    }
}