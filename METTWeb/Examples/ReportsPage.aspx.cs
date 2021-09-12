using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Singular.Web;

namespace MEWeb.Examples
{
    public partial class ReportsPage : MEPageBase<ReportsPageVM>
    {
    }

    public class ReportsPageVM : MEStatelessViewModel<ReportsPageVM>
    {
        public MELib.Reports.ProductsSoldReportList ProductsSoldReportList { get; set; }

        public string TestHigh { get; set; }
        public string Recommend { get; set; }
        public ReportsPageVM()
        {

        }

        protected override void Setup()
        {
            base.Setup();
            ProductsSoldReportList = MELib.Reports.ProductsSoldReportList.GetProductsSoldReportList();

            var last = ProductsSoldReportList.OrderBy(c => c.Total).FirstOrDefault();
            var high = ProductsSoldReportList.OrderBy(c => c.Total).LastOrDefault();
            var count = 0;
            foreach (var item in ProductsSoldReportList)
            {
                count++;
            }

            if(high != null && last != null && count > 1)
            {
                TestHigh = "The Movie Express Kiosk has sold a number of products with <b>" + high.ProductName + "</b> topping the list as the highest sold product with <b>" + high.Total + " sale(s)</b> and <b>" + last.ProductName + "</b> as the least amount sold product with <b>" + last.Total + " sale(s)</b> at the Kiosk.";
                Recommend = "It is highly recommended to stock more <b>" + high.ProductName + "</b> as customers seem to like this product.";
            }
            else if(count == 1)
            {
                TestHigh = "The Movie Express Kiosk has sold only <b>" + high.ProductName + " </b> with <b>" + high.Total + "</b> sale(s) on this product.";
            }
            else
                TestHigh = "No sales have been made. Please return when items have been purchased at the Kiosk.";

        }
    }
}