using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Singular.Web;

namespace MEWeb.Examples
{
    public partial class StockReportPage : MEPageBase<StockReportPageVM>
    {
    }

    public class StockReportPageVM : MEStatelessViewModel<StockReportPageVM>
    {
        public MELib.Reports.ProductStockList ProductStockList { get; set; }

        public string TestHigh { get; set; }

        public string Recommend { get; set; }
        public StockReportPageVM()
        {

        }

        protected override void Setup()
        {
            base.Setup();
            ProductStockList = MELib.Reports.ProductStockList.GetProductStockList();

            var last = ProductStockList.OrderBy(c => c.Stock).FirstOrDefault();
            var high = ProductStockList.OrderBy(c => c.Stock).LastOrDefault();
            if (high != null && last != null)
            {
                TestHigh = "The Movie Express Kiosk has sold a number of products and this report reveals the stock available. <b>" + high.ProductName + "</b> has the most amount of stock left in the Kiosk with <b>" + high.Stock + " item(s)</b> left and <b>" + last.ProductName + "</b> has the least amount of stock left with with <b>" + last.Stock + " item(s)</b> left at the Kiosk.";
                Recommend = "It is highly recommended to restock <b>" + last.ProductName + "</b> as this product has the least amount of stock left.";
            }
            else
                TestHigh = "No stock left. Please restock items and return.";
            
        }
    }
}