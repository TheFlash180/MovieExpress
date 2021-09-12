using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Singular.Web;

namespace MEWeb.Examples
{
    public partial class CategoryReportPage : MEPageBase<CategoryReportPageVM>
    {
    }

    public class CategoryReportPageVM : MEStatelessViewModel<CategoryReportPageVM>
    {
        public MELib.Reports.ProductCategoryList ProductCategoryList { get; set; }

        public string TestHigh { get; set; }
        public string Recommend { get; set; }
        public CategoryReportPageVM()
        {

        }

        protected override void Setup()
        {
            base.Setup();
            ProductCategoryList = MELib.Reports.ProductCategoryList.GetProductCategoryList();

            var last = ProductCategoryList.OrderBy(c => c.Total).FirstOrDefault();
            var high = ProductCategoryList.OrderBy(c => c.Total).LastOrDefault();
            var count = 0;
            foreach (var item in ProductCategoryList)
            {
                count++;
            }

            if (high != null && last != null && count > 1)
            {
                TestHigh = "The Movie Express Kiosk has sold a number of products with <b>" + high.Category + "</b> topping the list as the highest sold products with <b>" + high.Total + " sale(s)</b> and <b>" + last.Category + "</b> as the least amount sold products with <b>" + last.Total + " sale(s)</b> at the Kiosk.";
                Recommend = "It is highly recommended to stock more products in the <b>" + high.Category + "</b> category, as customers seem to like products in this range the most.";
            }
            else if (count == 1)
            {
                TestHigh = "The Movie Express Kiosk has only sold items in the <b>" + high.Category + "</b> category, with <b>" + high.Total + "</b> sale(s).";
            }
            else
                TestHigh = "No sales have been made. Please return when items have been purchased at the Kiosk.";
        }
    }
}